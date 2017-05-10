using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace OutlookFilterAddin
{
    public class KeywordsRow
    {
        //TODO: Add caching
        public Color PickedColor { get; set; }
        public string WordsRow { get; set; }
        public IEnumerable<string> Keywords { get { return WordsRow.Split(','); } }

        public KeywordsRow()
        {
            WordsRow = string.Empty;
        }
    }

    public class MailResult
    {
        public string Body { get; set; }
        public string Subject { get; set; }
        public ICollection<ColoredNum> ResultNumbers { get; set; }

        public MailResult()
        {
            Body = string.Empty;
            Subject = string.Empty;
            ResultNumbers = new Collection<ColoredNum>();
        }
    }

    public class ColoredNum
    {
        public Color Color { get; set; }
        public int Number { get; set; }
    }
}
