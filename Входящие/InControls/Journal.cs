using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Data;
using Data.Classes;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Office.Utils;
using DevExpress.Utils.Paint;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Import.Doc;
using Входящие.Classes;
using Входящие.Forms;
using AppearanceSetter;

namespace Входящие.InControls
{
    public partial class Journal : UserControl
    {
        private Журналы _journal;
        private BindingSource bsDocuments;
        public bool UpdateTheData { get; set; }

        public Journal(Data.Журналы journal)
        {
            if (journal == null) throw new ArgumentNullException("journal");
            UpdateTheData = true;
            InitializeComponent();
            this._journal = journal;
        }


         public Journal(IEnumerable<Документы> docs)
        {
            InitializeComponent();
            UpdateTheData = false;
            UpdateBs(docs);
        }
        

        //protected override void DestroyHandle()
        //{
        //    ОбработкаLayout.ОбработчикLayout.СохранитьGridView(gridView_journal, true, "gridView_journal");
        //    base.DestroyHandle();
        //}

        private void InitOfAuthority()
        {
            buttonAdd.Enabled = GlobalClass.CanRegister;
            buttonAdd.Visibility = GlobalClass.CanRegister ? BarItemVisibility.Always : BarItemVisibility.Never;

            buttonDelete.Enabled = GlobalClass.CanRegister;
            buttonDelete.Visibility = GlobalClass.CanRegister ? BarItemVisibility.Always : BarItemVisibility.Never;

            if (!GlobalClass.CanEdit) { buttonEdit.Caption = @"Просмотр"; }
        }

        private void InitComponent()
        {
            splitContainer1.SplitterDistance = 283;
            splitContainer1.Panel1Collapsed = true;
            cbe_yearSearch.Properties.Items.AddRange(GlobalClass.Dc.Документыs.Select(p=>p.ДатаРегистрации.Value.Year).Distinct().ToArray());
            cbe_yearSearch.EditValue = GlobalClass.YearSearch;
        }

        private void CheckBd()
        {
            var docs = GlobalClass.Dc.Документыs.Where(p => p.РегНомер == null);
            foreach (var doc in docs )
            {
                Delete(doc);
            }
        }

        private void Delete(Документы docДокументы)
        {
            Methods.DeleteDocument(docДокументы);
            bsDocuments.Remove(docДокументы);
        }

        private void UpdateBs()
        {
            if (GlobalClass.SeesAllDocuments) { DowloadAllDocuments(); }
            else if(GlobalClass.SeesDocumentsDepartament)
            {
                DowloadDocumentsDepartament();
            }
            else if (GlobalClass.SeesTheirDocuments) { DowloadTheirDocuments();}
        }

        private void DowloadDocumentsDepartament()
        {
            bsDocuments = new BindingSource();
            var номераЗагружаемыхДокументов = new List<long>();
            var documents = new List<Документы>();
            var списокПодразделенийВидимости = GlobalClass.Dc.ВидимостьПольномочийПользователяs.Where(p => p.id_пользователя == GlobalClass.CurrentUser.id_пользователя).Select(p => p.id_подразделения);
            if (GlobalClass.ShowClosing == false)
            {
                foreach (var списокНомеровДокументовИсполнителя in списокПодразделенийВидимости.Select(номерПодразделения => GlobalClass.Dc.Исполнителиs.Where(p => p.id_подразделения == номерПодразделения)).SelectMany(списокЛицОтдела => списокЛицОтдела.Select(executor => GlobalClass.Dc.Документыs.Where(p => p.id_исполнителя == executor.id_исполнителя).Select(p => p.id_документа))))
                {
                    documents.AddRange(списокНомеровДокументовИсполнителя.Select(номер => GlobalClass.Dc.Документыs.First(p => p.id_документа == номер)));
                }
                bsDocuments = DefineDowloadableDocuments(documents);
            }
            else
            {
                foreach (var списокНомеровДокументовИсполнителя in списокПодразделенийВидимости.Select(номерПодразделения => GlobalClass.Dc.Исполнителиs.Where(p => p.id_подразделения == номерПодразделения)).SelectMany(списокЛицОтдела => списокЛицОтдела.Select(executor => GlobalClass.Dc.ЖурналОперацийs.Where(p => p.id_исполнителя == executor.id_исполнителя && p.id_операции==1).Select(p => p.id_документа).Distinct())))
                {
                    documents.AddRange(списокНомеровДокументовИсполнителя.Select(номер => GlobalClass.Dc.Документыs.First(p => p.id_документа == номер)));
                }
                bsDocuments = DefineDowloadableDocuments(documents);   
            }
            gridJournal.DataSource = bsDocuments;
        }

        private void DowloadTheirDocuments()
        {
            try
            {
                bsDocuments = new BindingSource();

                var списокНомеров = GlobalClass.Dc.МестоположениеДокументаs.Where(p => p.id_операции == 1).Where(p => p.id_исполнителя == GlobalClass.CurrentUser.id_исполнителя).Select(p => p.id_документа);
                
                foreach (var номер in списокНомеров)
                {
                    bsDocuments.Add(GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа == номер));
                }
                gridJournal.DataSource = bsDocuments;
            }
            catch (Exception)
            {

            }
        }

        private void DowloadAllDocuments()
        {
            bsDocuments = new BindingSource();
            var documents = GlobalClass.Dc.Документыs.Where(p => p.ДатаРегистрации.Value.Year == GlobalClass.YearSearch).OrderByDescending(p => p.ДатаРегистрации);

            bsDocuments = DefineDowloadableDocuments(documents);
            gridJournal.DataSource = bsDocuments;
        }

        private BindingSource DefineDowloadableDocuments(IEnumerable<Документы> documents) 
        {
            var bsDowloadableDocuments = new BindingSource();
            foreach (var document in documents.OrderByDescending(p=>p.ДатаРегистрации))
            {
               
                if (document.ДатаРегистрации != null && document.ДатаРегистрации.Value.DayOfYear >= (DateTime.Now.DayOfYear - GlobalClass.TimePeriodDowload))
                {
                    if (document.Закрыт == GlobalClass.ShowClosing)
                    {
                        bsDowloadableDocuments.Add(document);
                    }
                    else if (document.Закрыт != GlobalClass.ShowWorking)
                    {
                        bsDowloadableDocuments.Add(document);
                    }
                    continue;
                }
                if (document.ДатаРегистрации != null && (document.ДатаРегистрации != null || document.ДатаРегистрации.Value.DayOfYear < (DateTime.Now.DayOfYear - GlobalClass.TimePeriodDowload)))
                {
                    break;
                }
                
            }
            return bsDowloadableDocuments;

        }

        private void UpdateBs(int yearSearch)
        {
            bsDocuments = new BindingSource {DataSource = GlobalClass.Dc.Документыs.Where(p => p.ДатаРегистрации.Value.Year == yearSearch)};
            gridJournal.DataSource = bsDocuments;
        }

        private void UpdateBs(IEnumerable<Документы> docs)
        {
            bsDocuments = new BindingSource();
            foreach (Документы doc in docs)
            {
                bsDocuments.Add(doc);
            }
            gridJournal.DataSource = bsDocuments;
        }

        private void gridJournal_DoubleClick(object sender, EventArgs e) {EditDocument();}

        private void EditDocument()
        {
            var document = (Документы) bsDocuments.Current;
            var form = new AddDocForm(document);
            form.Show();
            form.UpdateBsForJournal+=UpdateBs;
        }
        public void EditDocument(Документы _document)
        {
            var document = _document;
            var form = new AddDocForm(document);
            form.Show();
            form.UpdateBsForJournal += UpdateBs;
        }
        private void buttonReftresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateBs();
            FontSetter.НастроитьШрифтВГриде(gridView_journal, GlobalClass.FontSizeMainForm, FontStyle.Regular, GlobalClass.FontSizeMainForm, FontStyle.Regular, GlobalClass.FontSizeMainForm, FontStyle.Regular);
        }

        private void buttonAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var document = new Документы {ДатаРегистрации = DateTime.Today, ПризнакПечати = false, Код_акта = 0, запретИзменения = false, Вернуть = false};
            if (GlobalClass.ModeAccounting){document = Methods.InitIncommingNumber(document);}
            var form = new AddDocForm(document);
            form.Show();
            form.UpdateBsForJournal += UpdateBs;

        }

        private void buttonEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
            EditDocument(); 
        }

        private void buttonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(@"Удалить документ(ы)?", @"Удаление", MessageBoxButtons.YesNo) ==DialogResult.Yes)
            {
                foreach (var document in gridView_journal.GetSelectedRows().Select(p => gridView_journal.GetRow(p) as Документы)) {Methods.DeleteDocument(document);}
            }
            UpdateBs();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            LoadSearchResult();
        }

        private void buttonPanelSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearSearch();
            if (splitContainer1.Panel1Collapsed)
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.SplitterDistance = 283;
                te_incNum.Focus();
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
            }
        }

        private void LoadSearchResult()
        {
         
            var docss = Data.DataMethods.DataMethods.GetDocumentsByDetails((int)cbe_yearSearch.EditValue, te_content.Text, null, te_regNum.Text, te_incNum.Text, de_reg.EditValue == null ? null : ((DateTime)(de_reg.EditValue)).ToShortDateString());
            UpdateBs(docss);
            if (docss.Any()) { if(docss.Count==1){EditDocument(docss.FirstOrDefault());} }
            else
            { XtraMessageBox.Show("Документов, с заданными параметрами, не найдено.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void ClearSearch()
        {
            cbe_yearSearch.EditValue = GlobalClass.YearSearch;
            te_incNum.Text = !string.IsNullOrEmpty(GlobalClass.Prefix) ? GlobalClass.Prefix : null;
            te_regNum.Text = null;
            de_reg.EditValue = null;
            de_Control.EditValue = null;
            te_Pril.Text = null;
            te_content.Text = null;
        }

        private void te_incNum_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            LoadSearchResult();
        }

        private void cbe_yearSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadSearchResult();
        }

        private void te_regNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadSearchResult();
        }

        private void de_reg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadSearchResult();
        }

        private void de_Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadSearchResult();
        }

        private void te_Pril_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadSearchResult();
        }

        private void te_content_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadSearchResult();
        }

        private void buttonSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (gridView_journal as DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowAutoFilterRow = !(gridView_journal as DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowAutoFilterRow;
        }

       
        private void Journal_Load(object sender, EventArgs e)
        {
            InitComponent();
            CheckBd();
            if (UpdateTheData){UpdateBs();}
            InitOfAuthority();
        }
        
        private void gridJournal_Load(object sender, EventArgs e)
        {
            if (GlobalClass.SaveGrid){SaveGrid.SaveSettings.ВосстановитьГрид(gridJournal);}
        }

       
        private void gridView_journal_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            SaveGrid.SaveSettings.СохранитьГрид(gridJournal);
        }

        private void togglePreview_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            try
            {
                (gridView_journal as DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowPreview =
                !(gridView_journal as DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowPreview;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toggleClosePanel_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            (this.Parent.Parent.Parent.Parent as Main).HideThePanel();
        }

        private void toggleColor_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            var searchString = te_content.Text;

        }

        private void toggleGroup_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            try
            {
                (gridView_journal as DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowGroupPanel =
                !(gridView_journal as DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowGroupPanel;
                SaveGrid.SaveSettings.ПередвижениеКолонокГрида(gridJournal, (gridView_journal as DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowGroupPanel);
                ReadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ReadData()
        {
            try
            {
                Action action = () =>
                {
                    var control = new AlertControl {FormLocation = AlertFormLocation.BottomRight};
                    control.Show(this.Parent.Parent.Parent.Parent as Main, @"Пришло сообщение", @"Включен режим группировки");
                };
                Invoke(action);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        private void gridView_journal_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (view == null || e.RowHandle != view.FocusedRowHandle) return;
            e.Appearance.BackColor = Color.FromName(GlobalClass.ColorOfFocus);
            e.Appearance.ForeColor = Color.MidnightBlue;
        }

        
    }
}
