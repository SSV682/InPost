using System.Drawing;
using Data;
using DevExpress.XtraReports.UI;

namespace Входящие.Print
{
    public partial class Card : XtraReport
    {
        public Card(bool printReportFooter=false)
        {
            InitializeComponent();
            ReportFooter.Visible = printReportFooter;
        }

        private void Card_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           // xrLabel7.Font = new Font(StaticMembers.FontName, StaticMembers.FontSize, FontStyle.Bold);
            xrRichText17.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);

            xrLabel11.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
            xrLabel12.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
            xrLabel13.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
            xrLabel14.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
            xrLabel15.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
            xrLabel7.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);

            xrTableCell12.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
            xrTableCell13.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
            xrTableCell9.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
            xrTableCell10.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
            xrTableCell11.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
            xrTableCell3.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
        }

        private void xrRichText17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var xrLabel = sender as XRRichText;
            if (xrLabel != null) xrLabel.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
        }

        private void xrRichText17_TextChanged(object sender, System.EventArgs e)
        {
            var xrLabel = sender as XRLabel;
            if (xrLabel != null) xrLabel.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
        }
    }
}
