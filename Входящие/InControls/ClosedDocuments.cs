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

namespace Входящие.InControls
{
    public partial class ClosedDocuments : DevExpress.XtraEditors.XtraUserControl
    {
        private int _year;
        public int Year
        {
            get
            {
                if (_year == 0)
                {
                    _year = GlobalClass.YearSearch;
                }
                return _year;
            }
            set { _year = value; }
        }
        public string Executor { get; set; }
        private BindingSource _bs;

        public ClosedDocuments()
        {
            InitializeComponent();
            gridControl1.DataSource = GlobalClass.Dc.КоличествоЗакрытыхДокументовs;
            LoadDate();
        }

        private void LoadDate()
        {
            if (GlobalClass.SeesAllDocuments)
            {
                gridView1.Columns["КоличествоДокументов"].Visible = true;
                Reload(Year);
            }
            else if (GlobalClass.SeesDocumentsDepartament)
            {
                gridView1.Columns["КоличествоДокументов"].Visible = false;
                DowloadForDepartament();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            Year = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows().FirstOrDefault(), colГод).ToString());
            LoadDate();
        }

        private void Reload(int yearSorting)
        {
            gridControl2.DataSource = GlobalClass.Dc.КоличествоЗакрытыхДокументовИсполнителемs.Where(p => p.Год == yearSorting);
        }

        private void DowloadForDepartament()
        {
            _bs = new BindingSource();

            var списокПодразделенийВидимости = GlobalClass.Dc.ВидимостьПольномочийПользователяs.Where(p => p.id_пользователя == GlobalClass.CurrentUser.id_пользователя).Select(p=>p.id_подразделения);
            foreach (var executor in списокПодразделенийВидимости.Select(номерПодразделения => GlobalClass.Dc.Исполнителиs.Where(p => p.id_подразделения == номерПодразделения)).SelectMany(списокЛицОтдела => списокЛицОтдела)) {
                Reload(Year, executor.Исполнитель);
            }
            //var подразделениеПользователя = GlobalClass.Dc.Исполнителиs.Where(p => p.id_исполнителя == GlobalClass.CurrentUser.id_исполнителя).Select(p => p.НомерПодразделения).FirstOrDefault();
            //var списокЛицОтдела = GlobalClass.Dc.Исполнителиs.Where(p => p.НомерПодразделения == подразделениеПользователя);
            //foreach (var executor in списокЛицОтдела)
            //{
            //    Reload(Year,executor.Исполнитель);
            //}
            gridControl2.DataSource = _bs;
        }

        private void Reload(int yearSorting, string executor)
        {
             _bs.Add(GlobalClass.Dc.КоличествоЗакрытыхДокументовИсполнителемs.Where(p => p.Год == yearSorting & p.Исполнитель == executor));

        }

       
        private void bbi_view_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDate();
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e) { DowloadClosedDocuments(); }


        private void DowloadClosedDocuments()
        {
            Executor = gridView2.GetRowCellValue(gridView2.GetSelectedRows().FirstOrDefault(), colИсполнитель).ToString();

            var id_exec = GlobalClass.Dc.Исполнителиs.Where(p => p.Исполнитель == Executor).Select(p => p.id_исполнителя).FirstOrDefault();
            var searchQuery = new StringBuilder("Select d.* from Документы as d Join ИсполненыеДокументы as i ON i.id_документа = d.id_документа Where i.id_исполнителя = ");
            searchQuery.Append(id_exec);
            var docs = GlobalClass.Dc.ExecuteQuery<Документы>(searchQuery.ToString());
            var par = this.Parent as PanelControl;
            par.Controls.Clear();
            var журнал = new Journal(docs.ToList()) { Dock = DockStyle.Fill, Parent = par };
            par.Controls.Add(журнал);
        }
       
    }
}
