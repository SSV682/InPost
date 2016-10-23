using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Data;
using DevExpress.XtraEditors;
using Входящие.Classes;


namespace Входящие
{
    public partial class SettingsForm : DevExpress.XtraEditors.XtraForm
    {
        #region Свойства настройки программы
        public string YearSearch
        {
            get { return teYearSearch.Text; }
            set { this.teYearSearch.Text = value.ToString(CultureInfo.InvariantCulture).Trim(); }
        }
        public bool ModeAccouning
        {
            get { return tsModeAccounting.IsOn; }
            set { this.tsModeAccounting.IsOn = value; }
        }
        public bool ModeMonitor
        {
            get { return tsMonitorMode.IsOn;}
            set { this.tsMonitorMode.IsOn = value; }
        }
        public bool ServerModeFunction
        {
            get { return tsServerModeFunctioning.IsOn; }
            set { this.tsServerModeFunctioning.IsOn = value; }
        }
        public bool ShowClosing
        {
            get { return tsClosing.IsOn; }
            set { this.tsClosing.IsOn = value; }
        }
        public bool ShowWorking
        {
            get { return tsWorking.IsOn; }
            set { this.tsWorking.IsOn = value; }
        }
        public bool HighLite
        {
            get { return tsHighlite.IsOn; }
            set { this.tsHighlite.IsOn = value; }
        }
        public string ColorTransfer
        {
            get { return ПереданныйcolorEdit.Color.Name.ToString(CultureInfo.InvariantCulture); }
            set { ПереданныйcolorEdit.Color = Color.FromName(value); }
        }
        public string ColorClose
        {
            get { return ЗакрытыйcolorEdit.Color.Name.ToString(CultureInfo.InvariantCulture); }
            set { ЗакрытыйcolorEdit.Color = Color.FromName(value); }
        }
        public string ColorDestruction
        {
            get { return ДобавленныйcolorEdit.Color.Name.ToString(CultureInfo.InvariantCulture); }
            set { ДобавленныйcolorEdit.Color = Color.FromName(value); }
        }

        public bool InteractionWithTheEDMS
        {
            get { return tsEDMS.IsOn; }
            set { this.tsEDMS.IsOn = value; }
        }

        public bool SaveGrid
        {
            get { return tsSaveGrid.IsOn; }
            set { this.tsSaveGrid.IsOn = value; }
        }


        #endregion

        #region Свойства карточки

        public bool ShowIndex
        {
            get { return tsIndex.IsOn; }
            set { this.tsIndex.IsOn = value; }
        }
        public bool ShowView
        {
            get { return tsView.IsOn; }
            set { this.tsView.IsOn = value; }
        }
        public bool ShowDateControl
        {
            get { return tsDateControl.IsOn; }
            set { this.tsDateControl.IsOn = value; }
        }
        public bool ShowComments
        {
            get { return tsComments.IsOn; }
            set { this.tsComments.IsOn = value; }
        }
        public string Prefix
        {
            get { return tePrefix.Text; }
            set { this.tePrefix.Text = value; }
        }
        public bool PrefixViaVulture
        {
            get { return tsPrefixViaVulture.IsOn; }
            set { this.tsPrefixViaVulture.IsOn = value; }
        }
        public bool TrackTheReturn
        {
            get { return TrackReturnSwitch.IsOn; }
            set { this.TrackReturnSwitch.IsOn = value; }
        }

        public string ColorOfFocus
        {
            get { return ce_Focus.Color.Name.ToString(CultureInfo.InvariantCulture); }
            set { ce_Focus.Color = Color.FromName(value); }
        }

        #endregion

        #region Свойства печати

        public bool PrintingReverseSide
        {
            get { return ts_reverside.IsOn; }
            set { this.ts_reverside.IsOn = value; }
        }
        public string FontName
        {
            get { return cbe_Font_Name.EditValue.ToString(); }
            set { cbe_Font_Name.EditValue = value; }
        }
        public int FontSize 
        {
            get { return (int)cbe_Font_Size.EditValue; }
            set { cbe_Font_Size.EditValue = value; }
        }

        public string FontNameMainForm
        {
            get { return cbe_fontName.EditValue.ToString(); }
            set { cbe_fontName.EditValue = value; }
        }
        public int FontSizeMainForn
        {
            get { return int.Parse(cbe_fontSize.EditValue.ToString()); }
            set { cbe_fontSize.EditValue = value; }
        }

        public int NumbersCopies
        {
            get { return int.Parse(КолвоЭкземпляров.Text); }
            set { КолвоЭкземпляров.Text = value.ToString(CultureInfo.InvariantCulture); }
        }
        public bool ConductSurvey
        {
            get { return ОпросSwitch.IsOn; }
            set { ОпросSwitch.IsOn = value; }
        }

        public bool TheModeOfFormationOfTheAct
        {
            get { return tsFormationOfTheAct.IsOn; }
            set { tsFormationOfTheAct.IsOn = value; }
        }

        public int TimePeriodDowload
        {
            get { return (int)ceTimePeriod.Value; }
            set { ceTimePeriod.Value = value; }
        }

        public bool FunctionPrintJournal
        {
            get { return tsPrintJournal.IsOn; }
            set { tsPrintJournal.IsOn = value; }
        }

        public bool ClosesTheWindowAfterPrinting
        {
            get { return ЗакрытиеПослеПечатиSwitch.IsOn; }
            set { ЗакрытиеПослеПечатиSwitch.IsOn = value; }
        }

        public bool FastModePrinting
        {
            get { return tsFastModePrinting.IsOn; }
            set { tsFastModePrinting.IsOn = value; }
        }


        #endregion
        
        
        public SettingsForm()
        {
            InitializeComponent();
            
            InitSettings();
        }
      
        private void InitSettings()
        {
            InitCbe();
            SetSettingsOfAct();
            ShowIndex = GlobalClass.ShowIndex;
            ShowView = GlobalClass.ShowView;
            ShowComments = GlobalClass.ShowComments;
            ShowDateControl = GlobalClass.ShowDateControl;
            Prefix = GlobalClass.Prefix;
            PrefixViaVulture = GlobalClass.PrefixViaVulture;
            FontNameMainForm = GlobalClass.FontNameMainForm;
            FontSizeMainForn = GlobalClass.FontSizeMainForm;
            ConductSurvey = GlobalClass.ConductSurvey;
            NumbersCopies = GlobalClass.NumbersCopies;
            FontName = GlobalClass.FontName;
            FontSize = GlobalClass.FontSize;
            YearSearch = GlobalClass.YearSearch.ToString(CultureInfo.InvariantCulture);
            ModeAccouning = GlobalClass.ModeAccounting;
            ModeMonitor = GlobalClass.MonitorMode;
            ServerModeFunction = GlobalClass.ServerModeFunctioning;
            ShowClosing = GlobalClass.ShowClosing;
            ShowWorking = GlobalClass.ShowWorking;
            HighLite = GlobalClass.Highlite;
            PrintingReverseSide = GlobalClass.PrintingReverseSide;
            ColorClose = GlobalClass.ColorClose;
            ColorDestruction = GlobalClass.ColorDestruction;
            ColorTransfer = GlobalClass.ColorTransfer;
            TrackTheReturn = GlobalClass.TrackTheReturn;
            InteractionWithTheEDMS = GlobalClass.InteractionWithTheEDMS;
            FontNameMainForm = GlobalClass.FontNameMainForm;
            FontSizeMainForn = GlobalClass.FontSizeMainForm;
            TheModeOfFormationOfTheAct = GlobalClass.TheModeOfFormationOfTheAct;
            TimePeriodDowload = GlobalClass.TimePeriodDowload;
            ColorOfFocus = GlobalClass.ColorOfFocus;
            SaveGrid = GlobalClass.SaveGrid;
            FastModePrinting = GlobalClass.FastModePrinting;
            FunctionPrintJournal = GlobalClass.FuctionPrintJournal;
            ClosesTheWindowAfterPrinting=GlobalClass.ClosesTheWindowAfterPrinting;

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            SetSettingsInGlobalClass();
            SaveSettings();
            Close();
        }

        private void SetSettingsInGlobalClass()
        {
            GlobalClass.ShowIndex = ShowIndex;
            GlobalClass.ShowDateControl = ShowDateControl;
            GlobalClass.ShowView = ShowView;
            GlobalClass.ShowComments = ShowComments;
            GlobalClass.Prefix = Prefix;
            GlobalClass.PrefixViaVulture = PrefixViaVulture;
            GlobalClass.TrackTheReturn = TrackTheReturn;
            GlobalClass.InteractionWithTheEDMS = InteractionWithTheEDMS;
            GlobalClass.SaveGrid = SaveGrid;

            GlobalClass.ConductSurvey = ConductSurvey;
            GlobalClass.YearSearch = int.Parse(YearSearch);
            GlobalClass.NumbersCopies = NumbersCopies;
            GlobalClass.ModeAccounting = ModeAccouning;
            GlobalClass.MonitorMode = ModeMonitor;
            GlobalClass.ServerModeFunctioning = ServerModeFunction;
            GlobalClass.ShowClosing = ShowClosing;
            GlobalClass.ShowWorking = ShowWorking;
            GlobalClass.Highlite = HighLite;
            GlobalClass.PrintingReverseSide = PrintingReverseSide;

            GlobalClass.FontNameMainForm = FontNameMainForm;
            GlobalClass.FontSizeMainForm = FontSizeMainForn;
            GlobalClass.ColorOfFocus = ColorOfFocus;
            GlobalClass.FontName = FontName;
            GlobalClass.FontSize = FontSize;
            GlobalClass.ColorTransfer = ColorTransfer;
            GlobalClass.ColorDestruction = ColorDestruction;
            GlobalClass.ColorClose = ColorClose;
            GlobalClass.TheModeOfFormationOfTheAct = TheModeOfFormationOfTheAct;
            GlobalClass.TimePeriodDowload = TimePeriodDowload;
            GlobalClass.FastModePrinting = FastModePrinting;
            GlobalClass.FuctionPrintJournal = FunctionPrintJournal;
            GlobalClass.ClosesTheWindowAfterPrinting = ClosesTheWindowAfterPrinting;
        }

        private void InitCbe()
        {
            var fontsCollections = new InstalledFontCollection();
            var fontsFamily = fontsCollections.Families;
            foreach (var font in fontsFamily)
            {
                cbe_Font_Name.Properties.Items.Add(font.Name);
                cbe_fontName.Properties.Items.Add(font.Name);
            }
            for (int i=8; i < 13; i++)
            {
                cbe_Font_Size.Properties.Items.Add(i);
            }
            for (int i = 11; i < 16; i++)
            {
                cbe_fontSize.Properties.Items.Add(i);
            }
        }

        private void СбросБлокировкиButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveSettings()
        {
            Methods.StoreValueInConfig("Название_шрифта_карточки", GlobalClass.FontNameMainForm);
            Methods.StoreValueInConfig("Размер_шрифта_программы", GlobalClass.FontSizeMainForm);
            Methods.StoreValueInConfig("Функция_возврата", GlobalClass.TrackTheReturn);
            Methods.StoreValueInConfig("Быстрая_печать_карточки", GlobalClass.FastModePrinting);
            Methods.StoreValueInConfig("Количество_копий_печати", GlobalClass.NumbersCopies);
            Methods.StoreValueInConfig("Проведение_опроса_количества_карточек", GlobalClass.ConductSurvey);
            Methods.StoreValueInConfig("Префикс", GlobalClass.Prefix);
            Methods.StoreValueInConfig("Формирование_префикса_через_гриф", GlobalClass.PrefixViaVulture);
            Methods.StoreValueInConfig("Год_поиска", GlobalClass.YearSearch);
            Methods.StoreValueInConfig("Серверный_режим", GlobalClass.ServerModeFunctioning);
            Methods.StoreValueInConfig("Режим_отслеживания_судьбы_документа", GlobalClass.MonitorMode);
            Methods.StoreValueInConfig("Печать_оборотной_стороный_карточки", GlobalClass.PrintingReverseSide);
            Methods.StoreValueInConfig("Показывать_индекс", GlobalClass.ShowIndex);
            Methods.StoreValueInConfig("Показывать_дату_контроля", GlobalClass.ShowDateControl);
            Methods.StoreValueInConfig("Показывать_комментарии", GlobalClass.ShowComments);
            Methods.StoreValueInConfig("Подсветка_строк", GlobalClass.Highlite);
            Methods.StoreValueInConfig("Показывать_рабочие_документы", GlobalClass.ShowWorking);
            Methods.StoreValueInConfig("Показывать_закрытые_документы", GlobalClass.ShowClosing);
            Methods.StoreValueInConfig("Однопользовательский_режим_работы", GlobalClass.ModeAccounting);
            Methods.StoreValueInConfig("Размер_шрифта_карточки", GlobalClass.FontSize);
            Methods.StoreValueInConfig("Название_шрифта_карточки", GlobalClass.FontName);
            Methods.StoreValueInConfig("Цвет_подсветки_передачи", GlobalClass.ColorTransfer);
            Methods.StoreValueInConfig("Цвет_подсветки_закрытых", GlobalClass.ColorClose);
            Methods.StoreValueInConfig("Цвет_подсветки_на_удаление", GlobalClass.ColorDestruction);
            Methods.StoreValueInConfig("Показывать_вид_документа", GlobalClass.ShowView);
            Methods.StoreValueInConfig("Совместно_с_СЭД", GlobalClass.InteractionWithTheEDMS);
            Methods.StoreValueInConfig("Режим_просмотра",GlobalClass.ViewMode);
            Methods.StoreValueInConfig("Режим_создания_актов", GlobalClass.TheModeOfFormationOfTheAct);
            Methods.StoreValueInConfig("Врменной_интервал_загрузки_документов", GlobalClass.TimePeriodDowload);
            Methods.StoreValueInConfig("Цвет_подсвечиваемого_поля", GlobalClass.ColorOfFocus);
            Methods.StoreValueInConfig("Сохранять_изменения_грида", GlobalClass.SaveGrid);
            Methods.StoreValueInConfig("Печать_жернала",GlobalClass.FuctionPrintJournal);
            Methods.StoreValueInConfig("Закрытие_карточки_после_печати", ClosesTheWindowAfterPrinting);
            
        }

        private void tsFormationOfTheAct_Toggled(object sender, EventArgs e)
        {
            SetSettingsOfAct();
        }

        private void SetSettingsOfAct()
        {
            if (TheModeOfFormationOfTheAct)
            {
                tsEDMS.Enabled = true;
                label28.Enabled = true;
            }
            else
            {
                tsEDMS.Enabled = false;
                label28.Enabled = false;
            }
        }
    }
}