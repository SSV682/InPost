using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;

namespace Входящие.InControls
{
    public partial class ReturnedDocuments : DevExpress.XtraEditors.XtraUserControl
    {

        private bool UseDateControl{get { return GlobalClass.ShowDateControl; }}
        private bool UseDateReturn {get { return GlobalClass.TrackTheReturn; }}

        public ReturnedDocuments()
        {
            InitializeComponent();
            if (!UseDateReturn)
            {
                layoutControlItem1.Visibility=LayoutVisibility.Never;
            }
            else if(!UseDateControl)
            {
                layoutControlItem1.Visibility = LayoutVisibility.Never;
            }
        }

        private void cbe_TypeControl_EditValueChanged(object sender, EventArgs e)
        {
            if (cbe_TypeControl.EditValue == cbe_TypeControl.Properties.Items[1])
            {
                LoadData_ReturnedDocuments();
            }
            if (cbe_TypeControl.EditValue == cbe_TypeControl.Properties.Items[0])
            {
                LoadData_ControlDocuments();
            }
        }

        private void LoadData_ReturnedDocuments()
        {
            gridView1.Columns["ДатаКонтроля"].Visible = false;
            gridView1.Columns["ДатаВозврата"].Visible = true;
            var bsDocuments = new BindingSource { DataSource = GlobalClass.Dc.Документыs.Where(p => p.Вернуть && p.ДатаВозврата.HasValue && p.Закрыт == false).OrderBy(p => p.ДатаВозврата) };
            grid_DocsControl.DataSource = bsDocuments;
        }

        private void LoadData_ControlDocuments()
        {
            gridView1.Columns["ДатаВозврата"].Visible = false;
            gridView1.Columns["ДатаКонтроля"].Visible = true;
            var bsDocuments = new BindingSource { DataSource = GlobalClass.Dc.Документыs.Where(p => p.ДатаКонтроля.HasValue && p.Закрыт==false).OrderBy(p => p.ДатаКонтроля) };
            grid_DocsControl.DataSource = bsDocuments;
        }

        private void ReturnedDocuments_Load(object sender, EventArgs e)
        {
            if (UseDateControl && UseDateReturn) { layoutControlItem1.Visibility = LayoutVisibility.Always; }
            else
            {
                layoutControlItem1.Visibility = LayoutVisibility.Never;
                if(UseDateReturn){LoadData_ReturnedDocuments();}
                if(UseDateControl){LoadData_ControlDocuments();}
            }
            
        }

        private void grid_DocsControl_Load(object sender, EventArgs e)
        {
            SaveGrid.SaveSettings.ВосстановитьГрид(grid_DocsControl);
        }

        private void gridView1_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            SaveGrid.SaveSettings.СохранитьГрид(grid_DocsControl);
        }
    }
}
