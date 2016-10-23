using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Data;
using DevExpress.XtraEditors;

namespace Входящие.Forms
{
    public partial class SelectForce : DevExpress.XtraEditors.XtraForm
    {
        public string Caption
        {
            set { layoutControlItem1.Text = value; }
        }

        public КомуАдресован Force
        {
            get { return (cbe_Force.SelectedItem as КомуАдресован); }
            set
            {
                if (cbe_Force.Properties.Items.Count == 0)
                {
                    if (GlobalClass.Dc.КомуАдресованs != null) cbe_Force.Properties.Items.AddRange(GlobalClass.Dc.КомуАдресованs.Where(p => p.Удален == false).ToArray());
                    cbe_Force.EditValue = value;
                }
            }
        }

        public SelectForce()
        {
            InitializeComponent();
           
        }

        public КомуАдресован OpenDialog(string caption, КомуАдресован force)
        {
            Caption = caption;
            Force = force;
            var dr = ShowDialog();
            return Force;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}