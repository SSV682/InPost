using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MyStart.Контролы;

namespace MyStart.Формы
{
    public partial class Печать : DevExpress.XtraEditors.XtraForm
    {
        
        private MyData.Журналы журнал;
        public Печать(MyData.Журналы _журнал)
        {
            InitializeComponent();
            журнал = _журнал;
            
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            splitContainerControl1.Panel2.Controls.Clear();
            Контролы.ПечатьЖурнала лист1= new ПечатьЖурнала(журнал);
            лист1.Dock = DockStyle.Fill;
            лист1.Parent = splitContainerControl1.Panel2;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {  
            splitContainerControl1.Panel2.Controls.Clear();
            Контролы.ПечатьДиапозонаСтраниц лист1 = new ПечатьДиапозонаСтраниц(журнал);
            лист1.Dock = DockStyle.Fill;
            лист1.Parent = splitContainerControl1.Panel2;
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            splitContainerControl1.Panel2.Controls.Clear();
            Контролы.Допечатывание лист1 = new Допечатывание(журнал);
            лист1.Dock = DockStyle.Fill;
            лист1.Parent = splitContainerControl1.Panel2;
            лист1.Refresh();

        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Close();
        }
    }

    public enum ТипПечати{ПечатьЦеликом,Допечатывание,ДиапозонСтраниц};
}