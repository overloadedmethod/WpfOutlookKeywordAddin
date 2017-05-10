using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace OutlookFilterAddin
{
    public class HighlightViewModel : INotifyPropertyChanged
    {
        private IEnumerable<MailItem> _Mails;
        
        public ICommand AddNewKeywordsRow { get; set; }
        public ICommand RemoveKeywordsRow { get; set; }
        public ICommand FindOccurences { get; set; }

        public ObservableCollection<KeywordsRow> Keywords { get; set; }
        public ObservableCollection<MailResult> ResultMails { get; set; }

        public HighlightViewModel()
        {
            Keywords = new ObservableCollection<KeywordsRow>();
            Keywords.Add(new KeywordsRow { PickedColor = Color.FromRgb(255,0,0)});
            ResultMails = new ObservableCollection<MailResult>();

            AddNewKeywordsRow = new RelayCommand(onAddNewKeywordsRow);
            RemoveKeywordsRow = new RelayCommand(onRemoveKeyWordRow);
            FindOccurences = new RelayCommand(onFindOccurences);
        }

        public HighlightViewModel(IEnumerable<MailItem> mails):this()
        {
            _Mails = mails;
        }

        private void onAddNewKeywordsRow(object _)
        {
            Keywords.Add(new KeywordsRow { PickedColor = Color.FromRgb(255, 0, 0) });
        }

        private void onRemoveKeyWordRow(object row)
        {
            var rowVM = row as KeywordsRow;
            Keywords.Remove(rowVM);
        }

        private void onFindOccurences(object _)
        {
            var keys = Keywords.Where(k => k.WordsRow.Any());
            if (keys.Any())
            {
                ResultMails.Clear();
                foreach (var mail in _Mails)
                    ResultMails.Add(MailParser.ParseMailItem(keys, mail));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void raisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
