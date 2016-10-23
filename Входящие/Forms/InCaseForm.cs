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
using Входящие.Classes;

namespace Входящие.Forms
{
    public partial class InCaseForm : DevExpress.XtraEditors.XtraForm
    {
        public Документы Документы { get; set; }
        public event AddDocForm.ChangeTheFate changeCase;
      
        public string Исполнение
        {
            get { return te_performance.Text; }
            set { this.te_performance.Text = value.ToString().Trim(); }
        }
        public string Дело
        {
            get { return te_case.Text; }
            set { this.te_case.Text = value.ToString().Trim(); }
        }
        public string ТомНомер
        {
            get { return te_volume.Text; }
            set { this.te_volume.Text = value.ToString().Trim(); }
        }
        public string Лист
        {
            get { return te_pages.Text; }
            set { this.te_pages.Text = value.ToString().Trim(); }
        }
        public string От
        {
            get { return te_from.Text; }
            set { this.te_from.Text = value.ToString().Trim(); }
        }
        public InCaseForm(Документы документы)
        {
            InitializeComponent();
            Документы = документы;
            InitForm(Документы);
        }
        
        public Документы MakeDataCase()
        {
            DialogResult dr = ShowDialog();
            SaveChanges();
            return Документы;

        }
        private void InitForm(Документы документ)
        {
            if (документ.ИсполнениеНомер!=null) Исполнение = документ.ИсполнениеНомер;
            if (документ.ДелоНомер != null) Дело = документ.ДелоНомер;
            if (документ.Том != null) ТомНомер = документ.Том;
            if (документ.Лист != null) Лист = документ.Лист;
            if (документ.от != null) От = документ.от;
        }
        private void SaveChanges()
        {
            if (GlobalClass.Dc.ЖурналОперацийs.Where(p => p.id_документа == Документы.id_документа).OrderByDescending(p => p.датаНачалаОперации).ThenByDescending(p => p.id_записи).Select(p => p.id_операции).FirstOrDefault() != 6)
            {
                Methods.CloseDistiny(Документы,DateTime.Today);
                Methods.AddNewDistiny(Документы, 0, Operations.InCase, DateTime.Today.ToShortDateString() + " " + GlobalClass.Dc.Операцииs.Where(p => p.id_операции == 6).Select(p => p.НаименованиеОперации).FirstOrDefault() + " " + Документы.ДелоНомер, DateTime.Today);
            }
            SetCase(Документы);
            GlobalClass.Dc.SubmitChanges();
            if (changeCase != null) changeCase();
        }

        private void SetCase(Документы документ)
        {
            документ.ДелоНомер = Дело;
            документ.от = От;
            документ.Том = ТомНомер;
            документ.Лист = Лист;
            документ.ИсполнениеНомер = Исполнение;
            документ.Закрыт = true;
        }

        private void te_case_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control || e.KeyCode != Keys.Enter) return;
            SaveChanges();
            Close();
        }

        private void te_volume_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control || e.KeyCode != Keys.Enter) return;
            SaveChanges();
            Close();
        }

        private void te_pages_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control || e.KeyCode != Keys.Enter) return;
            SaveChanges();
            Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
        

    }
}