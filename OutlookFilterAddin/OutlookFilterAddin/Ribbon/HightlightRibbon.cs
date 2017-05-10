using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop;


using System.Windows;
using Microsoft.Office.Interop.Word;

namespace OutlookFilterAddin
{
    public partial class HighlightRibbon
    {
        private void TestRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void HighlightBtn_Click(object sender, RibbonControlEventArgs e)
        {
            var application = Globals.ThisAddIn.Application;
            var selectedMails = application.ActiveExplorer().Selection.OfType<Microsoft.Office.Interop.Outlook.MailItem>();

            if (selectedMails.Any())
            {
                var viewmodel = new HighlightViewModel(selectedMails);
                var window = new HighlightControl();
                window.DataContext = viewmodel;
                window.Show();
            }
            else
            {
                MessageBox.Show("Please select atleast one mail in the list");
            }

        }
    }
}
