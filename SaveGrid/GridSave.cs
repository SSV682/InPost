using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Extensions;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Xml.Serialization;
using Data;


namespace SaveGrid
{
    
    public static class SaveSettings
    {
        private static string GridName { get; set; }
        private static string ВернутьИмяГрида(Control userControl, GridView userGrid) { return userControl.Name + "-" + userGrid.Name; }

       
        private static void ЗаполнитьТаблицуКолонкамиГрида(ColumnView grid)
        {
            foreach (GridColumn c in grid.Columns)
            {
                РазмерыГрида columnGrid = Data.GlobalClass.Dc.РазмерыГридаs.FirstOrDefault(p => p.название_грида == GridName && p.название_колонки == c.Name && p.id_пользователя == GlobalClass.CurrentUser.id_пользователя);
                if (columnGrid == null)
                {
                    columnGrid = new РазмерыГрида {название_колонки = c.Name, ширина_колонки = c.Width, id_пользователя = GlobalClass.CurrentUser.id_пользователя, название_грида = GridName};
                    columnGrid.ширина_колонки = c.Width;
                    GlobalClass.Dc.РазмерыГридаs.InsertOnSubmit(columnGrid);
                }
                columnGrid.ширина_колонки = c.Width;
                

            }
        }
        
        private static void ВосстановитьРазмерыКолонок(ColumnView grid)
        {
            if (grid == null) throw new ArgumentNullException("grid");
            var списокКолонокГрида = GlobalClass.Dc.РазмерыГридаs.Where(p => p.название_грида == GridName && p.id_пользователя == Data.GlobalClass.CurrentUser.id_пользователя);
            foreach (var r in списокКолонокГрида)
            {
                try
                {
                    var column = grid.Columns.First(p => p.Name == r.название_колонки);
                    column.Width = (r.ширина_колонки);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }

        public static void ВосстановитьГрид(Control sender)
        {
            var senderControl = (GridControl)sender;
            foreach (GridView view in senderControl.Views)
            {
                if (view == null) continue;
                GridName = ВернутьИмяГрида(senderControl, view);
                ВосстановитьРазмерыКолонок(view);
            }
        }

        public static void СохранитьГрид(Control sender)
        {
            var senderControl = sender;
            try
            {
                var gridControl = senderControl as GridControl;
                if (gridControl == null) return;
                foreach (var view in gridControl.Views)
                {
                    var gridView = view as GridView;
                    if (gridView != null)
                    {
                        var grid = gridView;
                        GridName = ВернутьИмяГрида(senderControl, grid);
                        ЗаполнитьТаблицуКолонкамиГрида(grid);
                        Data.GlobalClass.Dc.SubmitChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);

            }
            
        }

        public static void ПередвижениеКолонокГрида(Control sender, bool allowMove)
        {
            var senderControl = (GridControl)sender;
            foreach (GridView view in senderControl.Views)
            {
                if (view == null) continue;
                РазрешитьДвигатьКолонки(view, allowMove);
            }
        }

        private static void РазрешитьДвигатьКолонки(ColumnView grid, bool allowMove)
        {
            if (grid == null) throw new ArgumentNullException("grid");
            var списокКолонокГрида = GlobalClass.Dc.РазмерыГридаs.Where(p => p.название_грида == GridName && p.id_пользователя == Data.GlobalClass.CurrentUser.id_пользователя);
            foreach (var r in списокКолонокГрида)
            {
                try
                {
                    var column = grid.Columns.First(p => p.Name == r.название_колонки);
                    column.OptionsColumn.AllowMove = allowMove;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

    }
}
