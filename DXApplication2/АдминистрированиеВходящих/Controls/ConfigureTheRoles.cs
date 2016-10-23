using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Data;
using DevExpress.XtraEditors;
using АдминистрированиеВходящих.Forms;

namespace АдминистрированиеВходящих.Controls
{
    public partial class ConfigureTheRoles : DevExpress.XtraEditors.XtraUserControl
    {
        private BindingSource _currentBs;

        public ConfigureTheRoles()
        {
            InitializeComponent();
            InitRoles();
        }

        private void InitRoles()
        {
            _currentBs = new BindingSource{ DataSource = GlobalClass.Dc.РолиПолномочийПользователейs};
            gridControl1.DataSource= _currentBs;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var role = (РолиПолномочийПользователей)_currentBs.Current;
            var form = new EditRole(role);
            form.Show();
        }
    }
}
