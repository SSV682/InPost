using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Входящие.Classes;
using Входящие.Forms;

namespace Входящие.InControls
{
    public partial class ChoiceAct : DevExpress.XtraEditors.XtraUserControl
    {
        
        public delegate void ReturnData();
        public virtual event ReturnData ReturnAct;
        private readonly ChooiseMode _mode;
    
        public ChoiceAct(ChooiseMode mode)
        {
            InitializeComponent();
            this._mode = mode;
        }

        private void ChoiceAct_Load(object sender, EventArgs e) {
            DownloadActs();
        }

        private void DownloadActs()
        {
            if (_mode == ChooiseMode.Edit)
            {
                Methods.DowloadDataToGrid(gridControl1, GlobalClass.Dc.АктыНаУничтожениеs.Where(p => !p.АктИсполнен));
                bbi_changeActNumber.Visibility = BarItemVisibility.Always;
            }
            if (_mode == ChooiseMode.DontEdit)
            {
                Methods.DowloadDataToGrid(gridControl1, GlobalClass.Dc.АктыНаУничтожениеs.Where(p => p.АктИсполнен));
                bbi_changeActNumber.Visibility = BarItemVisibility.Never;
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var main = this.Parent.Parent.Parent.Parent as Main;
            if (main != null) main._act = gridView1.GetFocusedRow() as АктыНаУничтожение;
            if (ReturnAct != null) ReturnAct();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(@"Удалить акт(ы)?", @"Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var p in gridView1.GetSelectedRows())
                {
                    var act = gridView1.GetRow(p) as АктыНаУничтожение;
                    if (act != null)
                    {
                        if (!GlobalClass.Dc.Документыs.Any(q => q.Код_акта == act.Код_акта)) { Methods.DeleteAct(act); }
                        else{ MessageBox.Show(@"В акте" + act.НомерАкта + @"находятся документы. Данный акт удален не будет.", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                    }
                }
                DownloadActs();
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var act = gridView1.GetFocusedRow() as АктыНаУничтожение;
            var textForm = new TextForm("Номер акта");
            if (act != null) textForm.EnteredText= act.НомерАкта;
            if (act != null) act.НомерАкта = textForm.OpenDialog();
            GlobalClass.Dc.SubmitChanges();
        }
    }
}
