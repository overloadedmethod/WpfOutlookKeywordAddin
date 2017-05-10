using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OutlookFilterAddin
{
    class MailParser
    {
        public static MailResult ParseMailItem(IEnumerable<KeywordsRow> Keywords, MailItem mail)
        {
            var result = new MailResult();

            var DelimeteredBody = mail.Body.Split(new char[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var wordGroups = DelimeteredBody.GroupBy(w => w);

            result.Subject = mail.Subject;
            result.Body = mail.HTMLBody;
            result.ResultNumbers = new List<ColoredNum>();

            foreach (var color in Keywords.Where(r => r.Keywords.Any() && r.PickedColor != null))
            {
                var keywords = color.Keywords;
                var occurences = 0;
                result.Body = result.Body.Replace("<head>", "<head><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>");
                foreach (var key in color.Keywords)
                {
                   var occurence = wordGroups.FirstOrDefault(g => g.Key.ToLowerInvariant().Trim().Equals(key.ToLowerInvariant().Trim()));
                    if (occurence != null)
                    {
                        occurences += occurence.Count();
                        result.Body = result.Body.Replace(occurence.Key, "<span style=\"color:" + color.PickedColor.ToString().Remove(1,2) + "\">" + occurence.Key + "</span>");
                    }
                        

                    
                }
                result.ResultNumbers.Add(new ColoredNum { Number = occurences, Color = color.PickedColor });
            }

            return result;
        }
    }
}
