using System.Drawing;
using Data;
using DevExpress.XtraReports.UI;

namespace Входящие.Print
{
    public partial class CardPartially : XtraReport
    {
        public CardPartially()
        {
            InitializeComponent();
        }

        private void CardPartially_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTableCell3.Font = new Font(GlobalClass.FontName, GlobalClass.FontSize, FontStyle.Bold);
        
        }
    }
}
