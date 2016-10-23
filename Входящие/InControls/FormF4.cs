using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Classes;
using Data.Properties;
using DevExpress.CodeParser;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Paint;
using DevExpress.XtraBars.Utils;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraRichEdit;
using Data;
using Входящие.Forms;
using StringsF4 = Входящие.Classes.StringsF4;


namespace Входящие.InControls
{
    
    public partial class FormF4 : DevExpress.XtraEditors.XtraUserControl
    {
        private AddDocForm parent;
        private Документы Документ;
        private readonly bool _readOnly;

        public DateTime ДатаРегистрации
        {
            get { return deДатаРег.DateTime.Date; }
            set { this.deДатаРег.DateTime = value; }
        }
        public string ВходящийНомер
        {
            get
            {
                return teIncomingNumber.Text;
            }
            set { this.teIncomingNumber.Text = value.ToString().Trim(); }
        }
        public DateTime ДатаПодписи
        {
            get { return deDateSignature.DateTime.Date; }
            set { this.deDateSignature.DateTime = value; }
        }
        public DateTime ДатаКонтроля
        {
            get { return deDateControl.DateTime.Date; }
            set { this.deDateControl.DateTime = value; }
        }
        public string РегНомер
        {
            get { return teRegNomer.Text; }
            set { this.teRegNomer.Text = value.ToString().Trim(); }
        }
        public Подразделения ОткудаПоступил
        {
            get { return (cbeFrom.SelectedItem as Подразделения); }
            set
            {
                if (cbeFrom.Properties.Items.Count == 0)
                {
                    if (GlobalClass.Dc.Подразделенияs != null) cbeFrom.Properties.Items.AddRange(GlobalClass.Dc.Подразделенияs.Where(p=>p.Удален==false).ToArray());
                }
                if (Документ.Подразделения != default (Подразделения))
                {
                    cbeFrom.Properties.Items.Add(Документ.Подразделения);
                    cbeFrom.SelectedItem = Документ.Подразделения;
                }
            }
        }
        public КомуАдресован КомуПоступил
        {
            get { return (cbeWhere.SelectedItem as КомуАдресован); }
            set
            {
                if (cbeWhere.Properties.Items.Count == 0)
                { cbeWhere.Properties.Items.AddRange(GlobalClass.Dc.КомуАдресованs.Where(p => p.Удален == false).ToArray()); }
                if (Документ.КомуАдресован != default(КомуАдресован))
                {cbeWhere.SelectedItem = Документ.КомуАдресован;}
            }
        }
        public ВидДокумента ВидПоступившегоДокумента
        {
            get { return (cbeView.SelectedItem as ВидДокумента); }
            set
            {
                if (cbeView.Properties.Items.Count == 0)
                { cbeView.Properties.Items.AddRange(GlobalClass.Dc.ВидДокументаs.ToArray()); }
                if (Документ.ВидДокумента != default(ВидДокумента))
                { cbeView.SelectedItem = Документ.ВидДокумента; }
            }
        }
        public Грифы Гриф
        {
            get { return (cbeGrif.SelectedItem as Грифы); }
            set
            {
                if (cbeGrif.Properties.Items.Count == 0)
                { cbeGrif.Properties.Items.AddRange(GlobalClass.Dc.Грифыs.ToArray()); }
                if (Документ.Грифы != default(Грифы))
                {cbeGrif.SelectedItem = Документ.Грифы;}
            }
        }
        public string Исполнение
        {
            get { return te_perfomance.Text; }
            set { this.te_perfomance.Text = value.ToString().Trim(); }
        }
        public string Дело
        {
            get { return te_case.Text; }
            set { this.te_case.Text = value.ToString().Trim(); }
        }
        public string ТомНомер
        {
            get { return te_volume.Text; }
            set { this.te_volume.Text = value.ToString().Trim(); }
        }
        public string Лист
        {
            get { return te_page.Text; }
            set { this.te_page.Text = value.ToString().Trim(); }
        }
        public string От
        {
            get { return te_from_case.Text; }
            set { this.te_from_case.Text = value.ToString().Trim(); }
        }
        public string Материалы
        {
            get { return te_materials.Text; }
            set { this.te_materials.Text = value.ToString(CultureInfo.InvariantCulture).Trim(); }
        }
        public string НомерЭкземпляра
        {
            get { return teNomerEkz.Text; }
            set { this.teNomerEkz.Text = value.ToString(CultureInfo.InvariantCulture).Trim(); }
        }
        public string КоличестовЛистов
        {
            get { return  ceList.Text; }
            set { ceList.Text = value; }
        }
        public string КоличествоПриложений
        {
            get { return  cePril.Text; }
            set { cePril.Text = value; }
        }
        public string НомераПриложений
        {
            get { return tePrilNumber.Text; }
            set { this.tePrilNumber.Text = value; }
        }
        public string Акт
        {
            get { return te_act.Text; }
            set { this.te_act.Text = value.ToString(CultureInfo.InvariantCulture).Trim(); }
        }
        public string ДатаАкта
        {
            get { return te_actFrom.Text; }
            set { this.te_actFrom.Text = value.ToString(CultureInfo.InvariantCulture).Trim(); }
        }
        public bool ТребуетсяВернуть
        {
            get { return ts_return.IsOn; }
            set { this.ts_return.IsOn = value; }
        }
        public DateTime? ДатаВозврата
        {
            get { return de_dateReturn.DateTime.Date; }
            set { de_dateReturn.EditValue = value; }
        }
        public string КомментарийОткуда
        {
            get { return teCommentFrom.Text; }
            set { this.teCommentFrom.Text = value; }
        }
        public string КомментарийКуда
        {
            get { return teCommentWhere.Text; }
            set { this.teCommentWhere.Text = value; }
        }
        private BindingSource _bsResolution, _bsView;
        public List<StringsF4> StringsViewF4S = new List<StringsF4>();
        public List<StringsF4> StringsResolutionF4S = new List<StringsF4>();
        

        public FormF4(Документы doc ,bool readOnly)
        {
            InitializeComponent();
            FieldSetup();
            Документ = doc;
            _readOnly = readOnly;
            InitForm(Документ);
           
        }

        public void InitForm(Документы документ)
        {
            if (документ.ДатаРегистрации != null) ДатаРегистрации = (DateTime)документ.ДатаРегистрации;
            if (документ.ПолныйВходящийНомер != null) ВходящийНомер = документ.ПолныйВходящийНомер;
            if (документ.ДатаПодписи != null) ДатаПодписи = (DateTime)документ.ДатаПодписи;
            if (документ.РегНомер != null) РегНомер = документ.РегНомер;
            if (документ.ВидДокумента != null) ВидПоступившегоДокумента = документ.ВидДокумента;
            if (документ.Грифы != null) Гриф = документ.Грифы;
            if (документ.НомерЭкземпляра != null) НомерЭкземпляра = документ.НомерЭкземпляра;
            if (документ.КоличествоЛистовЭкзепляра != null) КоличестовЛистов = документ.КоличествоЛистовЭкзепляра;
            if (документ.КоличествоЛистовПриложения != null) КоличествоПриложений = документ.КоличествоЛистовПриложения;
            if (документ.НомераПриложений != null) НомераПриложений = документ.НомераПриложений;
            if (документ.Акт != null) Акт = документ.Акт;
            if (документ.от2 != null) ДатаАкта = документ.от2;
            if (документ.ДатаВозврата!=null) ДатаВозврата = (DateTime)документ.ДатаВозврата;
            if (документ.КомментарийОткуда != null) КомментарийОткуда = документ.КомментарийОткуда;
            if (документ.КомментарийКому != null) КомментарийКуда = документ.КомментарийКому;
            ТребуетсяВернуть = документ.Вернуть;

            InitDictionary(документ);
            LoadCase(документ);
            LoadView(документ);
            LoadResolution(документ);
            LoadAct(документ);
            
            if (Документ.ДатаКонтроля.HasValue){ if (документ.ДатаКонтроля != null) ДатаКонтроля = (DateTime)документ.ДатаКонтроля; }
        }

        private void InitDictionary(Документы документ)
        {
            if (документ.Подразделения != null) ОткудаПоступил = документ.Подразделения;
            if (документ.КомуАдресован != null) КомуПоступил = документ.КомуАдресован;
            if (документ.ВидДокумента != null) ВидПоступившегоДокумента = документ.ВидДокумента;
        }

        private void bsResolution_AddingNew(object sender, AddingNewEventArgs e)
        {
            var str = new StringsF4();
            int maxNum = 0;
            try
            {
                maxNum = StringsViewF4S.Max(p => p.НомерСтроки);
            }
            catch (Exception)
            {

            }
            str.НомерСтроки = maxNum == 0 ? 0 : maxNum + 1;
            StringsViewF4S.Add(str);
            e.NewObject = str;
        }
        private void bsView_AddingNew(object sender, AddingNewEventArgs e)
        {
            var str = new StringsF4();
            int maxNum = 0;
            try
            {
                maxNum = StringsViewF4S.Max(p=>p.НомерСтроки);
            }
            catch (Exception)
            {
              
            }
            str.НомерСтроки = maxNum == 0 ? 0 : maxNum + 1;
            StringsViewF4S.Add(str);
            e.NewObject = str;
        }
        private void repositoryItemTextEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as DevExpress.XtraEditors.TextEdit).Text.Length == 54)
            {
                (_bsResolution.Current as StringsF4).Текст = (sender as DevExpress.XtraEditors.TextEdit).Text;
                (grid_resolution.MainView as DevExpress.XtraGrid.Views.Grid.GridView).UpdateCurrentRow();
                (grid_resolution.MainView as DevExpress.XtraGrid.Views.Grid.GridView).AddNewRow();
            }
        }
        private void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as DevExpress.XtraEditors.TextEdit).Text.Length == 54)
            {
                (_bsView.Current as StringsF4).Текст = (sender as DevExpress.XtraEditors.TextEdit).Text;
                (grid_summary.MainView as DevExpress.XtraGrid.Views.Grid.GridView).UpdateCurrentRow();
                (grid_summary.MainView as DevExpress.XtraGrid.Views.Grid.GridView).AddNewRow();
            }
        }

        private void FieldSetup()
        {
            this.cbeView.Properties.Items.AddRange(GlobalClass.Dc.ВидДокументаs.ToArray());
            this.cbeFrom.Properties.Items.AddRange(GlobalClass.Dc.Подразделенияs.Where(p=>p.Удален==false).ToArray());
            this.cbeWhere.Properties.Items.AddRange(GlobalClass.Dc.КомуАдресованs.Where(p => p.Удален == false).ToArray());
            this.cbeGrif.Properties.Items.AddRange(GlobalClass.Dc.Грифыs.ToArray());
            layoutControlItem9.Visibility = GlobalClass.ShowIndex ? LayoutVisibility.Always : LayoutVisibility.Never;
            layoutControlItem33.Visibility = GlobalClass.ShowComments ? LayoutVisibility.Always : LayoutVisibility.Never;
            layoutControlItem34.Visibility = GlobalClass.ShowComments ? LayoutVisibility.Always : LayoutVisibility.Never;
            layoutControlItem36.Visibility = GlobalClass.ShowDateControl? LayoutVisibility.Always : LayoutVisibility.Never;
            layoutControlItem37.Visibility = GlobalClass.ShowView ? LayoutVisibility.Always : LayoutVisibility.Never;
            
            layoutControlItem16.Visibility = GlobalClass.TrackTheReturn ? LayoutVisibility.Always : LayoutVisibility.Never;
            
            layoutControlItem38.Visibility = ТребуетсяВернуть? LayoutVisibility.Always : LayoutVisibility.Never;
        }
        private void LoadView(Документы документ)
        {
            _bsView = new BindingSource();
            foreach (var view in документ.ВидИКраткоеСодержаниеs.ToList())
            {
                if (!string.IsNullOrEmpty(view.Текст))
                {
                    var str = new StringsF4 {НомерСтроки = view.НомерСтроки, ПризнакПечати = view.ПризнакПечати, Текст = view.Текст};
                    StringsViewF4S.Add(str);
                }
            }
            _bsView.DataSource = StringsViewF4S;
            _bsView.AddingNew += bsView_AddingNew;
            grid_summary.DataSource = _bsView;
            repositoryItemTextEdit1.EditValueChanged += repositoryItemTextEdit1_EditValueChanged;
        }
        public void LoadResolution(Документы документ)
        {
            grid_resolution.DataSource = null;
            _bsResolution = new BindingSource();
            StringsResolutionF4S.Clear();
            foreach (var str in документ.Резолюцияs.ToList().Select(resolution => new StringsF4 {НомерСтроки = resolution.НомерСтроки, ПризнакПечати = resolution.ПризнакПечати, Текст = resolution.Текст})) {
                StringsResolutionF4S.Add(str);
            }
            _bsResolution.DataSource = StringsResolutionF4S;
            _bsResolution.AddingNew += bsResolution_AddingNew;
            grid_resolution.DataSource = _bsResolution;
            repositoryItemTextEdit2.EditValueChanged += repositoryItemTextEdit2_EditValueChanged;
            
        }
        public void LoadCase(Документы документ)
        {
            if (документ.ИсполнениеНомер != null) Исполнение = документ.ИсполнениеНомер;
            if (документ.ДелоНомер != null) Дело = документ.ДелоНомер;
            if (документ.Том != null) ТомНомер = документ.Том;
            if (документ.Лист != null) Лист = документ.Лист;
            if (документ.от != null) От = документ.от;
            if (документ.ДопМатериалы != null) Материалы = документ.ДопМатериалы;
        }
        public void LoadAct(Документы документ)
        {
            if (документ.Акт != null) Акт = документ.Акт;
            if (документ.от2 != null) ДатаАкта = документ.от2;
            
        }
        public void DeleteLastResolution(Документы документ,int idOperation)
        {
            foreach (var resolution in документ.Резолюцияs.ToList().Where(resolution => resolution.id_записи_операции == idOperation)) 
            {
                документ.Резолюцияs.Remove(resolution);
                GlobalClass.Dc.Резолюцияs.DeleteOnSubmit(resolution);
            }
            GlobalClass.Dc.SubmitChanges();
            LoadResolution(документ);
        }

        public void ClearCase(Документы документ)
        {
            if (документ.ИсполнениеНомер != null) Исполнение ="";
            if (документ.ДелоНомер != null) Дело = "";
            if (документ.Том != null) ТомНомер = "";
            if (документ.Лист != null) Лист = "";
            if (документ.от != null) От = "";
        }

        public void ClearAct(Документы документ)
        {
            if (документ.Акт != null) Акт = "";
            if (документ.от2 != null) ДатаАкта = "";
        }
        public void ClearMaterial(Документы документ)
        {
            if (документ.ДопМатериалы != null) Материалы = "";
        }
        

        private void ts_return_Toggled(object sender, EventArgs e)
        {
            if(!ТребуетсяВернуть)
            {
                layoutControlItem38.Visibility = LayoutVisibility.Never;
                if (ДатаВозврата == default(DateTime)) return;
                if (MessageBox.Show(@"Документ не будет возвращен. Дата возврата будет удалена.", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ДатаВозврата = null;
                }
            }
            else
            {
                layoutControlItem38.Visibility = LayoutVisibility.Always;
            }
        }

        private void cbeFrom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index != 1) return;
            var frm = new AddValueDictionary(AddValueDictionary.TypeValueDictionary.From);
            frm.InsertValueinDictionary();
            FieldSetup();
            Документ.Подразделения = GlobalClass.Dc.Подразделенияs.OrderByDescending(p=>p.id_подразделения).FirstOrDefault();
            InitDictionary(Документ);
        }

        private void cbeWhere_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index != 1) return;
            var frm = new AddValueDictionary(AddValueDictionary.TypeValueDictionary.Where);
            frm.InsertValueinDictionary();
            FieldSetup();
            Документ.КомуАдресован = GlobalClass.Dc.КомуАдресованs.OrderByDescending(p => p.id_получателя).FirstOrDefault();
            InitDictionary(Документ);
        }
        #region Подсвечивание полей при вводе

        private void teRegNomer_Enter(object sender, EventArgs e) { teRegNomer.BackColor = Color.FromName(GlobalClass.ColorOfFocus); }
        private void teRegNomer_Leave(object sender, EventArgs e){teRegNomer.BackColor = Color.White; }
        private void cbeGrif_Enter(object sender, EventArgs e) { cbeGrif.BackColor = Color.FromName(GlobalClass.ColorOfFocus); }
        private void cbeGrif_Leave(object sender, EventArgs e) { cbeGrif.BackColor = Color.White; }
        private void deDateSignature_Leave(object sender, EventArgs e) { deDateSignature.BackColor = Color.White; }
        private void deDateSignature_Enter(object sender, EventArgs e) { deDateSignature.BackColor = Color.FromName(GlobalClass.ColorOfFocus); }
        private void teIncomingNumber_Enter(object sender, EventArgs e) { teIncomingNumber.BackColor = Color.FromName(GlobalClass.ColorOfFocus); }
        private void teIncomingNumber_Leave(object sender, EventArgs e) { teIncomingNumber.BackColor = Color.White; }
        private void deДатаРег_Enter(object sender, EventArgs e){deДатаРег.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void deДатаРег_Leave(object sender, EventArgs e){deДатаРег.BackColor = Color.White;}
        private void cbeIndex_Enter(object sender, EventArgs e){cbeIndex.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void cbeIndex_Leave(object sender, EventArgs e){cbeIndex.BackColor = Color.White;}
        private void teNomerEkz_Enter(object sender, EventArgs e){teNomerEkz.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void teNomerEkz_Leave(object sender, EventArgs e){teNomerEkz.BackColor = Color.White;}
        private void ceList_Enter(object sender, EventArgs e){ceList.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void ceList_Leave(object sender, EventArgs e){ceList.BackColor = Color.White;}
        private void cePril_Enter(object sender, EventArgs e){cePril.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void cePril_Leave(object sender, EventArgs e){cePril.BackColor = Color.White;}
        private void tePrilNumber_Enter(object sender, EventArgs e){tePrilNumber.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void tePrilNumber_Leave(object sender, EventArgs e){tePrilNumber.BackColor = Color.White;}
        private void cbeFrom_Enter(object sender, EventArgs e){cbeFrom.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void cbeFrom_Leave(object sender, EventArgs e){cbeFrom.BackColor = Color.White;}
        private void teCommentFrom_Enter(object sender, EventArgs e){teCommentFrom.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void teCommentFrom_Leave(object sender, EventArgs e){teCommentFrom.BackColor = Color.White;}
        private void cbeWhere_Enter(object sender, EventArgs e){cbeWhere.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void cbeWhere_Leave(object sender, EventArgs e){cbeWhere.BackColor = Color.White;}
        private void teCommentWhere_Enter(object sender, EventArgs e){teCommentWhere.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void teCommentWhere_Leave(object sender, EventArgs e){teCommentWhere.BackColor = Color.White;}
        private void deDateControl_Enter(object sender, EventArgs e){deDateControl.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void deDateControl_Leave(object sender, EventArgs e){deDateControl.BackColor = Color.White;}
        private void cbeView_Enter(object sender, EventArgs e){cbeView.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void cbeView_Leave(object sender, EventArgs e){cbeView.BackColor = Color.White;}
        private void de_dateReturn_Enter(object sender, EventArgs e){de_dateReturn.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void de_dateReturn_Leave(object sender, EventArgs e){de_dateReturn.BackColor = Color.White;}
        private void grid_summary_Enter(object sender, EventArgs e){grid_summary.BackColor = Color.FromName(GlobalClass.ColorOfFocus);}
        private void grid_summary_Leave(object sender, EventArgs e){grid_summary.BackColor = Color.White;}
        
        #endregion

        private void deДатаРег_Validating(object sender, CancelEventArgs e)
        {
            if (ДатаПодписи != default(DateTime))
            {
                if (ДатаПодписи > ДатаРегистрации)
                    e.Cancel = true;
            }
        }

        

      

    }
}
