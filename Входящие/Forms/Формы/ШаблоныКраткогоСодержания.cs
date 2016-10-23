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
    public partial class ШаблоныКраткогоСодержания : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bs = new BindingSource();
        public ШаблоныКраткогоСодержания()
        {
            InitializeComponent();
            ЗагрузитьШаблоны();

        }

        public string ОткрытьДиалог()
        {
             return ((MyData.ШаблоныКратСод) bs.Current).Шаблон;
        }

        private void ЗагрузитьШаблоны()
        {
            IQueryable<MyData.ШаблоныКратСод> шаблоныКратСодs = MyData.StaticMembers.dc.ШаблоныКратСодs;
            foreach (var шаблоныКратСод in шаблоныКратСодs)
            {
                bs.Clear();
                bs.Add(шаблоныКратСодs);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}