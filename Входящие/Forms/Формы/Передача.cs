using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MyData;

namespace MyStart.Формы
{
    public partial class Передача : DevExpress.XtraEditors.XtraForm
    {
        short codOp;
        private MyData.Документы doc;
        private ТипПередачи тип;
        private MyData.ЖурналОпераций op;

        public delegate void ReturnDataDelegate(object sender, EventArgs e);

        public event ReturnDataDelegate changeHostDelegate;

        public Передача(MyData.Документы _doc, ТипПередачи _тип)
        {
            InitializeComponent();
            dateEdit1.EditValue = DateTime.Today;
            doc = _doc;
            тип = _тип;
            switch (тип)
            {
                case (ТипПередачи.отправка):
                    {

                        IQueryable<MyData.Подразделения> список = MyData.StaticMembers.dc.Подразделенияs;
                        foreach (var словарноеЗначение in список)
                        {
                            comboBoxEdit1.Properties.Items.Add(словарноеЗначение.НазваниеПодразделения);
                        }
                        codOp = 2;
                        break;
                    }
                case (ТипПередачи.передача):
                    {
                        IQueryable<MyData.Исполнители> список = MyData.StaticMembers.dc.Исполнителиs;
                        foreach (var словарноеЗначение in список)
                        {
                            comboBoxEdit1.Properties.Items.Add(словарноеЗначение.Исполнитель);
                        }
                        codOp = 1;
                        break;
                    }
                default:
                    break;
            }
            checkBox1.Checked = MyData.StaticMembers.добавлятьСтрокиВРезолюции;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Pass();
            if (changeHostDelegate != null)
                changeHostDelegate(sender, e);
        }

        private void comboBoxEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            Pass();
            if (changeHostDelegate != null)
                changeHostDelegate(sender, e);
        }

        private void Pass()
        {
            if (dateEdit1.DateTime != DateTime.Parse("01.01.0001") &&
                (MyData.StaticMembers.dc.Исполнителиs.Where(p => p.Исполнитель == comboBoxEdit1.Text).Count() != 0 ||
                 MyData.StaticMembers.dc.Подразделенияs.Where(p => p.НазваниеПодразделения == comboBoxEdit1.Text)
                     .Count() != 0))
            {

                MyData.ЖурналОпераций jЖурналОпераций =
                    MyData.StaticMembers.dc.ЖурналОперацийs.Where(p => p.id_записи == MyData.StaticMembers.dc.МестоположениеДокументаs.Where(q => q.id_документа == doc.id_документа).Select(q => q.id_записи).FirstOrDefault()).FirstOrDefault();
                if (jЖурналОпераций != null)
                {
                    jЖурналОпераций.датаКонцаОперации = dateEdit1.DateTime;
                }


                if (тип == ТипПередачи.передача)
                {
                    MyData.ЖурналОпераций op = new ЖурналОпераций();
                    op.id_операции = codOp; //передан
                    op.id_пользователя =
                        MyData.StaticMembers.dc.Пользователиs.Where(
                            p => p.Логин == MyData.StaticMembers.пользователь.Логин)
                            .Select(p => p.id_пользователя)
                            .FirstOrDefault();
                    op.id_исполнителя = MyData.StaticMembers.dc.Исполнителиs.Where(p => p.Исполнитель == comboBoxEdit1.EditValue).Select(p => p.id_исполнителя).FirstOrDefault();
                    op.датаНачалаОперации = dateEdit1.DateTime;
                    StringBuilder sb = new StringBuilder();
                    sb.Append(dateEdit1.DateTime.ToShortDateString());
                    sb.Append(" передан ");
                    sb.Append(comboBoxEdit1.EditValue);
                    if (!string.IsNullOrEmpty(textEdit1.Text))
                    {
                        sb.Append(" ");
                        sb.Append(textEdit1.Text);
                    }
                    op.Комментарий = sb.ToString();
                    op.id_документа = doc.id_документа;
                    MyData.StaticMembers.dc.ЖурналОперацийs.InsertOnSubmit(op);
                    doc.Наличие = false;

                    if (checkBox1.Checked)
                    {
                        MyData.Резолюция rez = new Резолюция();
                        rez.ПризнакПечати = false;
                        rez.Текст = sb.ToString();
                        rez.НомерСтроки = doc.Резолюцияs.Count;
                        rez.id_документа = doc.id_документа;
                        MyData.StaticMembers.dc.Резолюцияs.InsertOnSubmit(rez);
                        doc.Резолюцияs.Add(rez);
                    }
                    MyData.StaticMembers.dc.SubmitChanges();

                    Close();
                }
                if (тип == ТипПередачи.отправка)
                {
                    MyData.ЖурналОпераций op = new ЖурналОпераций();
                    op.id_операции = codOp; //передан
                    op.id_пользователя =
                        MyData.StaticMembers.dc.Пользователиs.Where(
                            p => p.Логин == MyData.StaticMembers.пользователь.Логин)
                            .Select(p => p.id_пользователя)
                            .FirstOrDefault();
                    op.id_исполнителя = MyData.StaticMembers.dc.Подразделенияs.Where(p => p.НазваниеПодразделения == comboBoxEdit1.EditValue).Select(p => p.id_подразделения).FirstOrDefault();
                    op.датаНачалаОперации = dateEdit1.DateTime;
                    StringBuilder sb = new StringBuilder();
                    sb.Append(dateEdit1.DateTime.ToShortDateString());
                    sb.Append(" отправлен в ");
                    sb.Append(comboBoxEdit1.EditValue);
                    if (!string.IsNullOrEmpty(textEdit1.Text))
                    {
                        sb.Append(" ");
                        sb.Append(textEdit1.Text);
                    }
                    op.Комментарий = sb.ToString();
                    op.id_документа = doc.id_документа;
                    MyData.StaticMembers.dc.ЖурналОперацийs.InsertOnSubmit(op);
                    doc.Наличие = false;
                    if (checkBox1.Checked)
                    {
                        MyData.Резолюция rez = new Резолюция();
                        rez.ПризнакПечати = false;
                        rez.Текст = sb.ToString();
                        rez.НомерСтроки = doc.Резолюцияs.Count;
                        rez.id_документа = doc.id_документа;
                        MyData.StaticMembers.dc.Резолюцияs.InsertOnSubmit(rez);
                        doc.Резолюцияs.Add(rez);
                    }
                    MyData.StaticMembers.dc.SubmitChanges();
                    Close();
                }
            }
        }
    }

    public enum ТипПередачи { передача, отправка }
}