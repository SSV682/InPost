using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyStart.Формы
{
    public partial class СудьбаДокумента : DevExpress.XtraEditors.XtraForm
    {
        private MyData.Документы документ;
        BindingSource bs = new BindingSource();
        public СудьбаДокумента(MyData.Документы _документ)
        {
            InitializeComponent();
            документ = _документ;
            labelControl1.Text = "Регистрационный номер "+ документ.РегНомер;
            IQueryable<MyData.ЖурналОпераций> ops =
                MyData.StaticMembers.dc.ЖурналОперацийs.Where(p => p.id_документа == документ.id_документа)
                    .OrderBy(p => p.id_записи);
            foreach (var op in ops)
            {
                bs.Add(op);
            }
            gridControl1.DataSource = bs;
        }

        private void СудьбаДокумента_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inPostDataSet.ЖурналОпераций' table. You can move, or remove it, as needed.
            this.журналОперацийTableAdapter.Fill(this.inPostDataSet.ЖурналОпераций);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}