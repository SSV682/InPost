using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Mvvm.Native;
using DevExpress.XtraEditors;
using MyData;
using формаФ4;

namespace MyStart.Формы
{
    public partial class ВДело : DevExpress.XtraEditors.XtraForm
    {
        private Ф4УК doc;
        private Ф4АДС doc2;
        private Ф4ЦПИС doc3;
        private Ф4ЦПУК doc4;
        private Ф4С doc5;

        public delegate void ReturnDataDelegate(object sender, EventArgs e);

        public event ReturnDataDelegate inFolderDelegate;

        public ВДело(Ф4УК _doc = null)
        {
            InitializeComponent();
            doc = _doc;
            textEdit1.DataBindings.Add("EditValue", doc, "ИсполнениеНомер", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit6.DataBindings.Add("EditValue", doc, "От", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit5.DataBindings.Add("EditValue", doc, "ДопМатериалы", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit2.DataBindings.Add("EditValue", doc, "N_дела", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit3.DataBindings.Add("EditValue", doc, "N_Тома", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit4.DataBindings.Add("EditValue", doc, "N_Листов", true, DataSourceUpdateMode.OnPropertyChanged);

        }

        public ВДело(Ф4С _doc5 = null)
        {
            InitializeComponent();
            doc5 = _doc5;
            textEdit1.DataBindings.Add("EditValue", doc5, "ИсполнениеНомер", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit6.DataBindings.Add("EditValue", doc5, "От", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit5.DataBindings.Add("EditValue", doc5, "ДопМатериалы", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit2.DataBindings.Add("EditValue", doc5, "N_дела", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit3.DataBindings.Add("EditValue", doc5, "N_Тома", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit4.DataBindings.Add("EditValue", doc5, "N_Листов", true, DataSourceUpdateMode.OnPropertyChanged);

        }

        public ВДело(Ф4ЦПУК _doc4 = null)
        {
            InitializeComponent();
            doc4 = _doc4;
            textEdit1.DataBindings.Add("EditValue", doc4, "ИсполнениеНомер", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit6.DataBindings.Add("EditValue", doc4, "От", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit5.DataBindings.Add("EditValue", doc4, "ДопМатериалы", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit2.DataBindings.Add("EditValue", doc4, "N_дела", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit3.DataBindings.Add("EditValue", doc4, "N_Тома", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit4.DataBindings.Add("EditValue", doc4, "N_Листов", true, DataSourceUpdateMode.OnPropertyChanged);

        }

        public ВДело(Ф4АДС _doc2 = null)
        {
            InitializeComponent();
            doc2 = _doc2;
            textEdit1.Text = doc2.ИсполнениеНомер;
            textEdit2.Text = doc2.N_дела;
            textEdit3.Text = doc2.N_Тома;
            textEdit4.Text = doc2.N_Листов;
            textEdit6.Text = doc2.От;
        }

        public ВДело(Ф4ЦПИС _doc3 = null)
        {
            InitializeComponent();
            doc3 = _doc3;
            textEdit1.DataBindings.Add("EditValue", doc3, "ИсполнениеНомер", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit6.DataBindings.Add("EditValue", doc3, "От", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit5.DataBindings.Add("EditValue", doc3, "ДопМатериалы", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit2.DataBindings.Add("EditValue", doc3, "N_дела", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit3.DataBindings.Add("EditValue", doc3, "N_Тома", true, DataSourceUpdateMode.OnPropertyChanged);
            textEdit4.DataBindings.Add("EditValue", doc3, "N_Листов", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Сохранить();
            if (inFolderDelegate != null)
                inFolderDelegate(sender, e);
            Close();
        }

        private void Сохранить()
        {
            if (doc2 != null)
            {
                doc2.ИсполнениеНомер = textEdit1.Text;
                doc2.N_Листов = textEdit4.Text;
                doc2.N_Тома = textEdit3.Text;
                doc2.N_дела = textEdit2.Text;
                doc2.От = textEdit6.Text;
                doc2.От2 = textEdit7.Text;
                if (!string.IsNullOrEmpty(doc2.N_дела))
                {
                    MyData.Документы dok = (MyData.Документы)doc2.Сохранить();
                    if (
                        MyData.StaticMembers.dc.ЖурналОперацийs.Where(p => p.id_документа == dok.id_документа)
                            .Where(p => p.id_операции == 6)
                            .FirstOrDefault() == null)
                    {
                        MyData.ЖурналОпераций jЖурналОпераций =
                        MyData.StaticMembers.dc.ЖурналОперацийs.Where(p => p.id_записи == MyData.StaticMembers.dc.МестоположениеДокументаs.Where(q => q.id_документа == dok.id_документа).Select(q => q.id_записи).FirstOrDefault()).FirstOrDefault();
                        if (jЖурналОпераций != null)
                        {
                            jЖурналОпераций.датаКонцаОперации = DateTime.Now;
                        }
                        MyData.ЖурналОпераций oper = new ЖурналОпераций();
                        oper.id_документа = dok.id_документа;
                        oper.id_исполнителя = 0;
                        oper.id_пользователя =MyData.StaticMembers.dc.Пользователиs.Where(p => p.Логин == MyData.StaticMembers.пользователь.Логин).Select(p => p.id_пользователя).FirstOrDefault();
                        oper.id_операции = 6;
                        oper.датаНачалаОперации = DateTime.Today;
                        oper.Комментарий = MyData.StaticMembers.dc.Операцииs.Where(p => p.id_операции == 6).Select(p => p.НаименованиеОперации).FirstOrDefault() + " № " + doc2.N_дела;
                        MyData.StaticMembers.dc.ЖурналОперацийs.InsertOnSubmit(oper);
                    }
                }
            }

            if (doc3 != null)
            {
                doc3.ИсполнениеНомер = textEdit1.Text;
                doc3.N_Листов = textEdit4.Text;
                doc3.N_Тома = textEdit3.Text;
                doc3.N_дела = textEdit2.Text;
                doc3.От = textEdit6.Text;
                doc3.От2 = textEdit7.Text;
                if (!string.IsNullOrEmpty(doc3.N_дела))
                {
                    MyData.Документы dok = (MyData.Документы)doc3.Сохранить();
                    if (
                        MyData.StaticMembers.dc.ЖурналОперацийs.Where(p => p.id_документа == dok.id_документа)
                            .Where(p => p.id_операции == 6)
                            .FirstOrDefault() == null)
                    {
                        MyData.ЖурналОпераций jЖурналОпераций =
                        MyData.StaticMembers.dc.ЖурналОперацийs.Where(p => p.id_записи == MyData.StaticMembers.dc.МестоположениеДокументаs.Where(q => q.id_документа == dok.id_документа).Select(q => q.id_записи).FirstOrDefault()).FirstOrDefault();
                        if (jЖурналОпераций != null)
                        {
                            jЖурналОпераций.датаКонцаОперации = DateTime.Now;
                        }
                        MyData.ЖурналОпераций oper = new ЖурналОпераций();
                        oper.id_документа = dok.id_документа;
                        oper.id_исполнителя = 0;
                        oper.id_пользователя = MyData.StaticMembers.dc.Пользователиs.Where(p => p.Логин == MyData.StaticMembers.пользователь.Логин).Select(p => p.id_пользователя).FirstOrDefault();
                        oper.id_операции = 6;
                        oper.датаНачалаОперации = DateTime.Today;
                        oper.Комментарий = MyData.StaticMembers.dc.Операцииs.Where(p => p.id_операции == 6).Select(p => p.НаименованиеОперации).FirstOrDefault() + " № " + doc3.N_дела;
                        MyData.StaticMembers.dc.ЖурналОперацийs.InsertOnSubmit(oper);
                    }
                }
            }

            MyData.StaticMembers.dc.SubmitChanges();
            
        }

      
    }
}