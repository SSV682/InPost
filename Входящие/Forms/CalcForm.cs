using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Входящие.Forms
{
    public partial class CalcForm : DevExpress.XtraEditors.XtraForm
    {
        public decimal Number
        {
            get { return ce_number.Value; }
            set { ce_number.Value = value; }
        }

        public CalcForm(string caption, int number)
        {
            InitializeComponent();
            la_number.Text = caption;
            Number = number;
        }

        public CalcForm(string caption)
        {
            InitializeComponent();
            la_number.Text = caption;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
        }

        public int OpenDialog()
        {
            ShowDialog();
            return (int)Number;
        }
    }
}