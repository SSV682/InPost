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
using Входящие.Classes;

namespace Входящие.Forms
{
    public partial class ChooseDocuments : DevExpress.XtraEditors.XtraForm
    {
        private readonly List<Документы> _docs; 
        public List<Документы> SelectedDocuments
        {
            get { return _docs.Where(p => p.InAct).ToList(); }
        }


        public ChooseDocuments(List<Документы> docs)
        {
            InitializeComponent();
            _docs = docs;
            foreach (var doc in docs)
            {
                doc.InAct = false;
            }
            gridControl1.DataSource = docs;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
           Close();
        }

        public List<Документы> ReturnData()
        {
            ShowDialog();
            return SelectedDocuments;
        }
    }
}