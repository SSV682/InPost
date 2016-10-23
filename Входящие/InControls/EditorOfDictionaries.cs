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
using Data;
using DevExpress.XtraEditors;
using Входящие.Classes;
using Входящие.Forms;

namespace Входящие.InControls
{
    public partial class EditorOfDictionaries : DevExpress.XtraEditors.XtraUserControl
    {
        private BindingSource bsUnitFrom;
        private BindingSource bsUnitWhere;



        public EditorOfDictionaries()
        {
            InitializeComponent();
            InitDictionary();
            InitComponent();

        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl.Name == "grid_from")
                {
                    var frm = new AddValueDictionary(AddValueDictionary.TypeValueDictionary.From);
                    frm.Show();
                    frm.UpdateBsForDistionery += frm_UpdateBsForDistionery;
                }
                if (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl.Name == "grid_where")
                {
                    var frm = new AddValueDictionary(AddValueDictionary.TypeValueDictionary.Where);
                    frm.Show();
                    frm.UpdateBsForDistionery += frm_UpdateBsForDistionery;
                }
                if (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl.Name == "grid_view")
                {
                    var frm = new AddValueDictionary(AddValueDictionary.TypeValueDictionary.View);
                    frm.Show();
                    frm.UpdateBsForDistionery += frm_UpdateBsForDistionery;
                }
                if (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl.Name == "grid_executor")
                {
                    var frm = new AddValueDictionary(AddValueDictionary.TypeValueDictionary.Executor);
                    frm.Show();
                    frm.UpdateBsForDistionery+=frm_UpdateBsForDistionery;
                }
            }
            catch
            {
                
            }
        }

        private void frm_UpdateBsForDistionery()
        {
            InitDictionary();
        }

        private void InitDictionary()
        {
            Methods.DowloadDataToGrid(grid_from,GlobalClass.Dc.Подразделенияs.Where(p=>p.Удален==false));
            Methods.DowloadDataToGrid(grid_where, GlobalClass.Dc.КомуАдресованs.Where(p => p.Удален == false));
            Methods.DowloadDataToGrid(grid_view, GlobalClass.Dc.ВидДокументаs);
            Methods.DowloadDataToGrid(grid_executor, GlobalClass.Dc.Исполнителиs.Where(p => p.Удален == false));
        }

        private void InitComponent()
        {
            
            gridView1.Columns["Индекс"].Visible = GlobalClass.ShowIndex;
            gridView1.Columns["Префикс"].Visible = GlobalClass.ShowIndex;
            xtp_view.PageVisible= GlobalClass.ShowView;

        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e) { InitDictionary(); }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl.Name == "grid_from")
            {
                var unit = gridView1.GetFocusedRow() as Подразделения;
                if (!(unit == null || MessageBox.Show(@"Удалить исполнителя - " + unit.НазваниеПодразделения + @"?", @"Удаление", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes))
                {
                    unit.Удален = true;
                    GlobalClass.Dc.SubmitChanges();
                }
            }
            if (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl.Name == "grid_where")
            {
                var recipient = gridView2.GetFocusedRow() as КомуАдресован;
                if (!(recipient == null || MessageBox.Show(@"Удалить исполнителя - " + recipient.КомуАдресован1 + @"?", @"Удаление", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes))
                {
                    IQueryable<long> listOfNumbers = GlobalClass.Dc.МестоположениеДокументаs.Where(p => p.id_операции == 1).Where(p => p.id_исполнителя == recipient.id_исполнителя).Select(p => p.id_документа).Distinct();
                    if (!listOfNumbers.Any())
                    {
                        if (GlobalClass.Dc.КомуАдресованs.Any(p => p.id_исполнителя == recipient.id_исполнителя))
                        {
                            var executor = GlobalClass.Dc.Исполнителиs.FirstOrDefault(p => p.id_исполнителя == recipient.id_исполнителя);
                            if (executor != null) executor.Удален = true;
                            recipient.Удален = true;
                        }
                        else
                        {
                            recipient.Удален = true;
                        }
                        GlobalClass.Dc.SubmitChanges();
                    }
                    else
                    { MessageBox.Show(@"За данным исполнителем числятся документы. Удалить исполнителя невозможно, пока с него не буду списаны документы. Чтобы перейти к списку документов, числящихся у исполнителя, зайдите во вкладу 'Переданные документы'.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                }
            }
            if (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl.Name == "grid_view")
            {
                var view = gridView3.GetFocusedRow() as ВидДокумента;
                if (!(view == null || MessageBox.Show(@"Удалить - " + view.Вид + @"?", @"Удаление", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes))
                {
                    IQueryable<long> listOfNumbers = GlobalClass.Dc.Документыs.Where(p => p.id_виддокумента == +view.id_видДокумента).Select(p => p.id_документа).Distinct();
                    if (!listOfNumbers.Any())
                    {
                        if (GlobalClass.Dc.ВидДокументаs.Any(p => p.id_видДокумента == view.id_видДокумента))
                        {
                            var recipient = GlobalClass.Dc.ВидДокументаs.FirstOrDefault(p => p.id_видДокумента == view.id_видДокумента);
                            if (recipient != null) GlobalClass.Dc.ВидДокументаs.DeleteOnSubmit(recipient);
                        }

                        GlobalClass.Dc.SubmitChanges();
                    }
                    else
                    { MessageBox.Show(@"За данным исполнителем числятся документы. Удалить исполнителя невозможно, пока с него не буду списаны документы. Чтобы перейти к списку документов, числящихся у исполнителя, зайдите во вкладу 'Переданные документы'.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                }
            }
            if (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl.Name == "grid_executor")
            {
                var executor = gridView4.GetFocusedRow() as Исполнители;
                if (!(executor == null || MessageBox.Show(@"Удалить исполнителя - " + executor.Исполнитель + @"?", @"Удаление", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes))
                {
                    IQueryable<long> listOfNumbers = GlobalClass.Dc.МестоположениеДокументаs.Where(p => p.id_операции == 1).Where(p => p.id_исполнителя == executor.id_исполнителя).Select(p => p.id_документа).Distinct();
                    if (!listOfNumbers.Any())
                    {
                        if (GlobalClass.Dc.КомуАдресованs.Any(p => p.id_исполнителя == executor.id_исполнителя))
                        {
                            var recipient = GlobalClass.Dc.КомуАдресованs.FirstOrDefault(p => p.id_исполнителя == executor.id_исполнителя);
                            if (recipient != null) recipient.Удален = true;
                            executor.Удален = true;
                        }
                        else
                        {
                            executor.Удален = true;
                        }
                        GlobalClass.Dc.SubmitChanges();
                    }
                    else
                    {MessageBox.Show(@"За данным исполнителем числятся документы. Удалить исполнителя невозможно, пока с него не буду списаны документы. Чтобы перейти к списку документов, числящихся у исполнителя, зайдите во вкладу 'Переданные документы'.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);}
                }
            }
            
        }

       
    }
}
