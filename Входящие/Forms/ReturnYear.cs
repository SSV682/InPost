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
    public partial class ReturnYear : DevExpress.XtraEditors.XtraForm
    {
        public int Year
        {
            get { return (int)calcEdit1.Value; }
        }

        public ReturnYear()
        {
            InitializeComponent();
            calcEdit1.Value = DateTime.Now.Year;
        }

        public int OpenDialog() {ShowDialog(); return Year; }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}