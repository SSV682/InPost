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
    public partial class ReRegistr : DevExpress.XtraEditors.XtraForm
    {
        public ReType ReType { get; set; }
    
        public ReRegistr()
        {
            InitializeComponent();

        }

        private void simpleButton1_Click(object sender, EventArgs e) { ReType = ReType.NewDocument;
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e) { ReType = ReType.ExistingDocument; Close(); }

        private void simpleButton3_Click(object sender, EventArgs e) { ReType = Forms.ReType.WithoutReRegistration; Close(); }

        public ReType OpenDialog()
        {
            ShowDialog();
            return ReType;
        }
    }
}