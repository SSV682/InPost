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

namespace Входящие.Forms
{
    public partial class SetAct : DevExpress.XtraEditors.XtraForm
    {
        public string Number
        {
            get { return te_number.Text; }
            set { te_number.Text = value; }
        }
        public string DateAct
        {
            get { return de_dateAct.DateTime.ToShortDateString(); }
        }

        public Документы Document { get; set; }

        public SetAct(Документы _документы)
        {
            InitializeComponent();
            Document = _документы;
            de_dateAct.DateTime = DateTime.Today;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
           Close();
        }

        public Документы MakeDataAct()
        {
            DialogResult dr = ShowDialog();
            SaveChanges();
            return Document;
        }

        private void SaveChanges()
        {
            Document.Акт = Number;
            Document.от2 = DateAct;
            Document.Закрыт = true;
           
        }
    }
}