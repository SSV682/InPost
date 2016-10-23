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
    public partial class TextForm : DevExpress.XtraEditors.XtraForm
    {
        public string EnteredText
        {
            get { return te_text.Text; }
            set { te_text.Text = value.Trim(); }
        }
        public TextForm(string caption)
        {
            InitializeComponent();
            lo_text.Text = caption;
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
        public string OpenDialog()
        {
            var dr = ShowDialog();
            return EnteredText;
        }
    }
}