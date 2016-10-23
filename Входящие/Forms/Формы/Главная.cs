using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Word;
using MyData;
using MyStart.Контролы;
using Application = System.Windows.Forms.Application;

namespace MyStart.Формы
{
    public partial class Главная : DevExpress.XtraEditors.XtraForm
    {
        private Журналы печатыемыйЖурнал;
        public Главная()
        {
            InitializeComponent();
            InitializeForce();
            ПроверкаБД();
            ОткрытьЖурнал();
        }

        private void ОткрытьЖурнал()
        {
            MyData.Журналы жжук = MyData.StaticMembers.dc.Журналыs.Where(p => !p.Окончен.HasValue).FirstOrDefault();
            печатыемыйЖурнал = жжук;
            Журнал журнал = new Журнал(жжук);
            SetInPanelControl(panelControl1, журнал);
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ОткрытьЖурнал();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MyData.Журналы жж = MyData.StaticMembers.dc.Журналыs.Where(p => p.Окончен == null).Where(p => p.Тип_Журнала == 79).FirstOrDefault();

            if (жж != null)
            {
                MessageBox.Show("Журнал уже создан. Он будет открыт.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                печатыемыйЖурнал = жж;
                Журнал журнал = new Журнал(жж);
                SetInPanelControl(panelControl1, журнал);
                return;
            }
            else
            {
                MyData.Журналы жур = new MyData.Журналы();
                жур.КоличествоЛистов = 1;
                жур.ТекущаяСтраница = 2;
                жур.Тип_Журнала = 79;
                EditJournal frm = new EditJournal(жур);
                жур = frm.СоздатьЖурнал();
                if (жур != null)
                {
                    MyData.StaticMembers.dc.Журналыs.InsertOnSubmit(жур);
                    MyData.StaticMembers.dc.SubmitChanges();
                }
            }
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Формы.Настройки настройки = new Настройки();
            настройки.Show();
        }

        public void СкрытьПанель()
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if(MyData.StaticMembers.Force ==НазваниеПодразделения.АппаратДиректора)
            {
                Контролы.РедактированиеСловарейАДС редактированиеСловарей = new Контролы.РедактированиеСловарейАДС();
                SetInPanelControl(panelControl1, редактированиеСловарей);
            }
           else
           {
               Контролы.РедактированиеСловарей редактированиеСловарей = new Контролы.РедактированиеСловарей();
               SetInPanelControl(panelControl1, редактированиеСловарей);
           }
           
           
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Application.Exit();
        }

        private void Method(object sender, EventArgs e)
        {
            int ChoosedID = MyData.StaticMembers.choosedId;
            MyData.АктыНаУничтожение act =MyData.StaticMembers.dc.АктыНаУничтожениеs.Where(p => p.Код_акта == ChoosedID).FirstOrDefault();
            if (act != null)
            {
                Контролы.Акт frmАкт;
                if (!act.АктИсполнен)
                {
                    frmАкт = new Контролы.Акт(act, РежимыРаботыАкта.Редактирование);
                }
                else
                {
                    frmАкт = new Контролы.Акт(act, РежимыРаботыАкта.Просмотр);
                }
                SetInPanelControl(panelControl1, frmАкт);
                frmАкт.myexecutionAct += Method;
            }
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            BindingSource bs = new BindingSource();
            IQueryable<MyData.АктыНаУничтожение> docs =MyData.StaticMembers.dc.АктыНаУничтожениеs.Where(p => p.АктИсполнен == false).OrderBy(p => p.Год);
            foreach (var doc in docs)
            {
                bs.Add(doc);
            }
            var контролВыбора = new КонтролВыбора(bs,РежимыРаботыСАктом.Редактирование);
            SetInPanelControl(panelControl1, контролВыбора);
            контролВыбора.returnDataDelegate += Method;
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            BindingSource bs = new BindingSource();
            IQueryable<MyData.АктыНаУничтожение> docs =
                MyData.StaticMembers.dc.АктыНаУничтожениеs.Where(p => p.АктИсполнен).OrderBy(p => p.Год);
            foreach (var doc in docs)
            {
                bs.Add(doc);
            }
            var контролВыбора = new КонтролВыбора(bs, РежимыРаботыСАктом.Просмотр);

            SetInPanelControl(panelControl1, контролВыбора);
            контролВыбора.returnDataDelegate += Method;
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            IQueryable<MyData.АктыНаУничтожение> docs =
                MyData.StaticMembers.dc.АктыНаУничтожениеs.Where(p => p.АктИсполнен == false).OrderBy(p => p.Год);
            if (docs.Count() != 0)
            {
                if (MessageBox.Show("Имеются редактируемые акты. Хотите использовать один из них?", "Внимание", MessageBoxButtons.YesNo) ==
                    System.Windows.Forms.DialogResult.No)
                {
                    MyData.АктыНаУничтожение act = new АктыНаУничтожение();
                    act.АктИсполнен = false;
                    НомерАКта нмр = new НомерАКта();
                    act.НомерАкта = нмр.ОткрытьДиалог();
                    DateTime date = DateTime.Now;
                    act.ДатаСоздания = date.ToShortDateString();
                    act.Дата = date;
                    MyData.StaticMembers.dc.АктыНаУничтожениеs.InsertOnSubmit(act);
                    MyData.StaticMembers.dc.SubmitChanges();
                    MyData.StaticMembers.choosedId =
                        MyData.StaticMembers.dc.АктыНаУничтожениеs.Where(p => p.Дата == date)
                            .Select(p => p.Код_акта)
                            .FirstOrDefault();
                    Method(sender, e);
                }
                else
                {
                    panelControl1.Controls.Clear();
                    BindingSource bs = new BindingSource();
                    docs = MyData.StaticMembers.dc.АктыНаУничтожениеs.Where(p => p.АктИсполнен == false).OrderBy(p => p.Год);
                    foreach (var doc in docs)
                    {
                        bs.Add(doc);
                    }
                    var контролВыбора = new КонтролВыбора(bs, РежимыРаботыСАктом.Редактирование);
                    контролВыбора.Dock = DockStyle.Fill;
                    контролВыбора.Parent = panelControl1;
                    контролВыбора.returnDataDelegate += Method;
                }

            }
            else
            {
                MyData.АктыНаУничтожение act = new АктыНаУничтожение();
                act.АктИсполнен = false;
                НомерАКта formНомерАКта = new НомерАКта();
                act.НомерАкта = formНомерАКта.ОткрытьДиалог();
                DateTime date = DateTime.Now;
                act.ДатаСоздания = date.ToShortDateString();
                MyData.StaticMembers.dc.АктыНаУничтожениеs.InsertOnSubmit(act);
                MyData.StaticMembers.dc.SubmitChanges();
                MyData.StaticMembers.choosedId =
                    MyData.StaticMembers.dc.АктыНаУничтожениеs.Where(p => p.Дата == date)
                        .Select(p => p.Код_акта)
                        .FirstOrDefault();
                Method(sender, e);

                panelControl1.Controls.Clear();
                BindingSource bs = new BindingSource();
                docs = MyData.StaticMembers.dc.АктыНаУничтожениеs.Where(p => p.АктИсполнен == false).OrderBy(p => p.Год);
                foreach (var doc in docs)
                {
                    bs.Add(doc);
                }
                var контролВыбора = new КонтролВыбора(bs, РежимыРаботыСАктом.Редактирование);
                контролВыбора.Dock = DockStyle.Fill;
                контролВыбора.Parent = panelControl1;
                контролВыбора.returnDataDelegate += Method;
            }
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ОтчетЖурнала отчет = new ОтчетЖурнала();
            SetInPanelControl(panelControl1, отчет);
        }

        private void ПроверкаБД()
        {
            IQueryable<long> badids =
                MyData.StaticMembers.dc.Документыs.Where(p => p.РегНомер == null).Select(p => p.id_документа);
            foreach (var badid in badids)
            {
                MyData.Документы doc =
                    MyData.StaticMembers.dc.Документыs.Where(p => p.id_документа == badid).FirstOrDefault();
                MyData.StaticMembers.dc.Видs.DeleteAllOnSubmit((doc).Видs);
                MyData.StaticMembers.dc.Резолюцияs.DeleteAllOnSubmit((doc).Резолюцияs);
                MyData.StaticMembers.dc.Документыs.DeleteOnSubmit(doc);
                MyData.StaticMembers.dc.SubmitChanges();
            }
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MyStart.Контролы.КонтролДокументыРедактора  frm = new Контролы.КонтролДокументыРедактора();
            SetInPanelControl(panelControl1, frm);
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MyStart.Контролы.ПереданныеДокументы frm = new Контролы.ПереданныеДокументы();
            SetInPanelControl(panelControl1, frm);
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MyStart.Контролы.Статистика frm = new Контролы.Статистика();
            SetInPanelControl(panelControl1,frm);
        }

        private void SetInPanelControl(PanelControl panel,UserControl control)
        {
            panel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.Parent = panel;
        }

        private void InitializeForce()
        {
            if (MyData.StaticMembers.ModeПрограммы == РежимПрограммы.Серверный)
            {
                navBarItem10.Visible = false;
                navBarItem10.Enabled = false;
            }
            if (MyData.StaticMembers.Force == НазваниеПодразделения.УправлениеС)
            {
                navBarGroup3.Visible = false;
            }
            if (MyData.StaticMembers.Force == НазваниеПодразделения.АппаратДиректора)
            {
                navBarItem12.Visible = false;
                navBarItem11.Visible = false;
            }
            if (MyData.StaticMembers.Force == НазваниеПодразделения.ЦПИС)
            {
                navBarGroup4.Visible = false;
                navBarGroup3.Visible = false;
            }
        }

        public enum РежимыРаботыАкта { Редактирование, Просмотр };
        public enum ТипПечати { ПечатьЦеликом, Допечатывание, ДиапозонСтраниц };

    }
}