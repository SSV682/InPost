using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Входящие.Forms
{
    public partial class PrintPersonalBusiness : DevExpress.XtraEditors.XtraForm
    {
        public PrintPersonalBusiness()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public PrintForPersonalBusienss OpenDialog()
        {
            var str = new PrintForPersonalBusienss();
            
            //var itm = cbl_print.Items[0];
            //str.DateSignature = i
            return str;
        }

    }
}