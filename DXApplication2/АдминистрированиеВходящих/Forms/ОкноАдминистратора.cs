using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using DevExpress.XtraEditors;
using АдминистрированиеВходящих.Controls;
using Входящие;
using Входящие.Classes;

namespace АдминистрированиеВходящих
{
    public partial class ОкноАдминистратора : DevExpress.XtraEditors.XtraForm
    {
        public ОкноАдминистратора()
        {
            InitializeComponent();
        }

        private void nbi_Roles_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) { OpenRoles(); }

        private void OpenRoles()
        {
            GlobalClass.ОбновитьDc();
            var configureTheRoles = new ConfigureTheRoles();
            Methods.SetInPanelControl(panelAdmin, configureTheRoles);
        }
    }
}