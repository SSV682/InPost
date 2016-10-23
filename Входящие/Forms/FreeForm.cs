using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Входящие.Classes;

namespace Входящие.Forms
{
    public partial class FreeForm : DevExpress.XtraEditors.XtraForm
    {
        public FreeForm()
        {
            InitializeComponent();
        }

        public FreeForm(string caption, UserControl control)
        {
            InitializeComponent();
            this.Text = caption;
            Methods.SetInPanelControl(panelFree,control);
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}