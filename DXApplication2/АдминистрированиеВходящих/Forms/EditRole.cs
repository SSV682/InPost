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

namespace АдминистрированиеВходящих.Forms
{
    public partial class EditRole : DevExpress.XtraEditors.XtraForm
    {

        private РолиПолномочийПользователей _ролиПолномочийПользователей;
        private bool МожетРегистрировать
        {
            get { return ts_canReg.IsOn; }
            set { this.ts_canReg.IsOn = value; }
        }
        private bool МожетРедактировать
        {
            get { return ts_canEdit.IsOn; }
            set { this.ts_canEdit.IsOn = value; }
        }
        private bool МожетПечататьКарточку
        {
            get { return ts_canPrintCard.IsOn; }
            set { this.ts_canPrintCard.IsOn = value; }
        }
        private bool МожетРедактироватьСловари
        {
            get { return ts_canEditDictionary.IsOn; }
            set { this.ts_canEditDictionary.IsOn = value; }
        }
        private bool МожетПечатьЖурнал
        {
            get { return ts_canPrintJournal.IsOn; }
            set { this.ts_canPrintJournal.IsOn = value; }
        }
        private bool МожетПечататьВедомости
        {
            get { return ts_canPrintReport.IsOn; }
            set { this.ts_canPrintReport.IsOn = value; }
        }
        private bool МожетРаботатьСАктами
        {
            get { return ts_canWorkingWithTheAct.IsOn; }
            set { this.ts_canWorkingWithTheAct.IsOn = value; }
        }
        private bool МожетВидетьСтатистику
        {
            get { return ts_canSeeStat.IsOn; }
            set { this.ts_canSeeStat.IsOn = value; }
        }
        private string НазваниеРоли
        {
            get { return te_Name.Text; }
            set { this.te_Name.Text = value; }
        }
        
        public EditRole(РолиПолномочийПользователей role)
        {
            InitializeComponent();
            _ролиПолномочийПользователей = role;
            InitRole();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
           SaveRole(); 
            Close();
        }

        private void SaveRole()
        {
            var role = _ролиПолномочийПользователей != default(РолиПолномочийПользователей) ? _ролиПолномочийПользователей : new РолиПолномочийПользователей();
            role.Регистрация = МожетРегистрировать;
            role.Редактирвоание = МожетРедактировать;
            role.ПечатьКарточек = МожетПечататьКарточку;
            role.ПечатьЖурнала = МожетПечатьЖурнал;
            role.ПечатьВедомостей = МожетПечататьВедомости;
            role.Название_роли = НазваниеРоли;
            role.РаботатьСАктами = МожетРаботатьСАктами;
            role.РедактироватьСловари = МожетРедактироватьСловари;
            role.СмотретьСтатистику = МожетВидетьСтатистику;
            switch (comboBoxEdit1.SelectedIndex)
            {
                case(0):
                {
                    role.ПросмотрСобственныхДокументов = true;
                    role.ПросмотрДокументовОтдела = false;
                    role.ПросмотрВсехДокументов = false;
                    break;
                }
                case(1):
                {
                    role.ПросмотрСобственныхДокументов = false;
                    role.ПросмотрДокументовОтдела = true;
                    role.ПросмотрВсехДокументов = false;
                    break;
                }
                case(2):
                {
                    role.ПросмотрСобственныхДокументов = false;
                    role.ПросмотрДокументовОтдела = false;
                    role.ПросмотрВсехДокументов = true;
                    break;
                }
            }
            GlobalClass.Dc.SubmitChanges();
        }

        private void InitRole()
        {
            var role = _ролиПолномочийПользователей != default(РолиПолномочийПользователей) ? _ролиПолномочийПользователей : new РолиПолномочийПользователей();
            МожетРегистрировать = role.Регистрация;
            МожетРедактировать= role.Редактирвоание;
            МожетПечататьКарточку =role.ПечатьКарточек;
            МожетПечатьЖурнал =role.ПечатьЖурнала;
            МожетПечататьВедомости = role.ПечатьВедомостей ;
            НазваниеРоли= role.Название_роли;
            МожетРаботатьСАктами= role.РаботатьСАктами;
            МожетРедактироватьСловари= role.РедактироватьСловари;
            МожетВидетьСтатистику=role.СмотретьСтатистику;
            if (role.ПросмотрСобственныхДокументов)
            {
                comboBoxEdit1.SelectedIndex = 0;
            }
            if (role.ПросмотрДокументовОтдела)
            {
                comboBoxEdit1.SelectedIndex = 1;
            }
            if (role.ПросмотрВсехДокументов)
            {
                comboBoxEdit1.SelectedIndex = 2;
            }
                   
        }
    }
}