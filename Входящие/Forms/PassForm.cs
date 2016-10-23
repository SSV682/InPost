using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Data;
using Data.Classes;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Layout;
using Входящие.Classes;

namespace Входящие.Forms
{
    public partial class PassForm : DevExpress.XtraEditors.XtraForm
    {
        private Документы _документы;
        private TransmissionsType _transmissionsType;
        public event AddDocForm.ChangeTheFate changeHost;

        public PassForm(Документы документ, TransmissionsType transmissionsType)
        {
            InitializeComponent();
            _документы = документ;
            _transmissionsType = transmissionsType;
            InitForm();
        }

        private void SaveChanges()
        {
            Methods.CloseDistiny(_документы,de_when_pass.DateTime);
            switch (_transmissionsType)
            {
                case(TransmissionsType.Transfer):
                {
                   
                    var comment = new StringBuilder();
                    comment.Append(de_when_pass.DateTime.ToShortDateString());
                    comment.Append(" ");
                    comment.Append(cbe_where_pass.EditValue);
                    if (!string.IsNullOrWhiteSpace(te_comment.Text))
                    {
                        comment.Append(" ");
                        comment.Append(te_comment.Text);
                    }
                    
                    var bindOperation = Methods.AddNewDistiny(_документы, GlobalClass.Dc.Исполнителиs.Where(p => (p.Исполнитель == (string) cbe_where_pass.EditValue)).Select(p => p.id_исполнителя).FirstOrDefault(),Operations.Transfer, comment.ToString(), de_when_pass.DateTime);

                    var list = Methods.BrokenLines(comment.ToString(), 60);
                    foreach (var currentString in list)
                    {
                        Methods.AddNewResolution(_документы, currentString, bindOperation);
                    }
                    _документы.Наличие = false;
                    GlobalClass.Dc.SubmitChanges();
                    break;
                }
                case (TransmissionsType.Send):
                {
                    Methods.SendInUnit(_документы,(string)cbe_where_pass.EditValue,string.IsNullOrEmpty(te_comment.Text)?"":te_comment.Text,de_when_pass.DateTime);
                    break;
                }
            }
            changeHost();
        }

        private void InitForm()
        {
            de_when_pass.EditValue = DateTime.Today;
            switch (_transmissionsType)
            {
                case (TransmissionsType.Send):
                    {
                        IQueryable<Подразделения> список = GlobalClass.Dc.Подразделенияs.Where(p => p.Удален == false).OrderBy(p => p.НазваниеПодразделения);
                        foreach (var словарноеЗначение in список)
                        {
                            cbe_where_pass.Properties.Items.Add(словарноеЗначение.НазваниеПодразделения);
                        }
                        break;
                    }
                case (TransmissionsType.Transfer):
                    {
                        IQueryable<Исполнители> список = GlobalClass.Dc.Исполнителиs.Where(p => p.Удален == false).OrderBy(p => p.Исполнитель);
                        foreach (var словарноеЗначение in список)
                        {
                            cbe_where_pass.Properties.Items.Add(словарноеЗначение.Исполнитель);
                        }
                        break;
                    }
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            SaveChanges();
            Close();
        }
        private void cbe_where_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveChanges();
            }
        }
        private void de_when_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveChanges();
            }

        }
        private void te_comment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveChanges();
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public enum TransmissionsType { Transfer, Send }
    public enum PrintMode {Full,Partially}
    public enum ChooiseMode {Edit,DontEdit}
    public enum ModeEditor {Journal,Debetors,CheckAct,Act}
    public enum TypeControl {Control,Return}
    public struct PrintForPersonalBusienss
    {
        public bool RegNumber;
        public bool DateSignature;
        public bool Instance;
        public bool SheetsInstance;

    }
    public enum ReType {NewDocument,ExistingDocument,WithoutReRegistration}
    
}