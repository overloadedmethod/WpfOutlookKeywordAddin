namespace OutlookFilterAddin
{
    partial class HighlightRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public HighlightRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Highlight = this.Factory.CreateRibbonTab();
            this.HighlightContent = this.Factory.CreateRibbonGroup();
            this.HighlightBtn = this.Factory.CreateRibbonButton();
            this.Highlight.SuspendLayout();
            this.HighlightContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // Highlight
            // 
            this.Highlight.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.Highlight.ControlId.OfficeId = "TabMail";
            this.Highlight.Groups.Add(this.HighlightContent);
            this.Highlight.Label = "TabMail";
            this.Highlight.Name = "Highlight";
            this.Highlight.Position = this.Factory.RibbonPosition.AfterOfficeId("TabMail");
            // 
            // HighlightContent
            // 
            this.HighlightContent.Items.Add(this.HighlightBtn);
            this.HighlightContent.Label = "Highlight Content";
            this.HighlightContent.Name = "HighlightContent";
            this.HighlightContent.Position = this.Factory.RibbonPosition.AfterOfficeId("TabMail");
            // 
            // HighlightBtn
            // 
            this.HighlightBtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.HighlightBtn.Image = global::OutlookFilterAddin.Properties.Resources.Martz90_Circle_Addon1_Flashlight_app;
            this.HighlightBtn.Label = "Highlight";
            this.HighlightBtn.Name = "HighlightBtn";
            this.HighlightBtn.ShowImage = true;
            this.HighlightBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.HighlightBtn_Click);
            // 
            // HighlightRibbon
            // 
            this.Name = "HighlightRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer, Microsoft.Outlook.Mail.Compose, Microsoft.Outlook.Mai" +
    "l.Read";
            this.Tabs.Add(this.Highlight);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.TestRibbon_Load);
            this.Highlight.ResumeLayout(false);
            this.Highlight.PerformLayout();
            this.HighlightContent.ResumeLayout(false);
            this.HighlightContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Highlight;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup HighlightContent;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton HighlightBtn;
    }

    partial class ThisRibbonCollection
    {
        internal HighlightRibbon TestRibbon
        {
            get { return this.GetRibbon<HighlightRibbon>(); }
        }
    }
}
