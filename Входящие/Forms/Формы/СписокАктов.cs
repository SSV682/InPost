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
    public partial class СписокАктов : DevExpress.XtraEditors.XtraForm
    {
        private MyData.АктыНаУничтожение actSelected;
        private BindingSource bs = new BindingSource();
        public СписокАктов()
        {
            InitializeComponent();
            IQueryable<MyData.АктыНаУничтожение> acts = MyData.StaticMembers.dc.АктыНаУничтожениеs.Where(p=>p.АктИсполнен==false);
            foreach (var act in acts)
            {
                bs.Add(act);
            }
            gridControl1.DataSource = bs;

        }

        private void СписокАктов_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inPostDataSet.АктыНаУничтожение' table. You can move, or remove it, as needed.
            this.актыНаУничтожениеTableAdapter.Fill(this.inPostDataSet.АктыНаУничтожение);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            actSelected = ((MyData.АктыНаУничтожение) bs.Current);
            this.Close();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            actSelected = ((MyData.АктыНаУничтожение)bs.Current);
            this.Close();
        }

        public MyData.АктыНаУничтожение ОткрытьДиалог()
        {
            DialogResult dr = ShowDialog();
            return actSelected;
        }
    }
}