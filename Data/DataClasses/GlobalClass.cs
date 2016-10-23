using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;


namespace Data
{
    public class GlobalClass
    {
        private static DataModelDataContext _dc;
        public static DataModelDataContext Dc
        {
            get
            {
                if (_dc != null)
                    return _dc;
                _dc = new DataModelDataContext(MetaUtils.Config.MainConnectString);
                return _dc;
            }
            set
            {
                _dc = value;
            }
        }

        public static DataModelDataContext ConnectDc(DbConnection con)
        {
            return new DataModelDataContext();
        }

        public static void ОбновитьDc() //обновляет дата контекст
        {
            _dc = new DataModelDataContext(MetaUtils.Config.MainConnectString);
        }

        private static bool? _fastModePrinting;
        public static bool FastModePrinting
        {
            get
            {
                if (_fastModePrinting.HasValue)
                {
                    return _fastModePrinting.Value;
                }
                bool use;
                if (bool.TryParse(MetaUtils.Config.ReadSettingsString("Быстрая_печать_карточки"), out use))
                    _fastModePrinting = use;
                else
                    _fastModePrinting = false;
                return _fastModePrinting.Value;
            }
            set { _fastModePrinting = value; }
        }

        private static int _numberCopies;
        public static int NumbersCopies 
        {
            get
            {
                if (_conductSurvey.HasValue)
                {
                    return _numberCopies;
                }
                int use = MetaUtils.Config.ReadSettingsInt("Количество_копий_печати");
                _numberCopies = use;
                return _numberCopies;
            }
            set { _numberCopies = value; }
        }

        private static bool? _conductSurvey;
        public static bool ConductSurvey
        {
            get
            {
                if (_conductSurvey.HasValue)
                {
                    return _conductSurvey.Value;
                }
                bool use;
                _conductSurvey = bool.TryParse(MetaUtils.Config.ReadSettingsString("Проведение_опроса_количества_карточек"), out use) && use;
                return _conductSurvey.Value;
            }
            set { _conductSurvey = value; }
        }

        private static bool? _prefixViaVulture;
        public static bool PrefixViaVulture
        {
            get
            {
                if (_prefixViaVulture.HasValue)
                {
                    return _prefixViaVulture.Value;
                }
                bool use;

                if (bool.TryParse(MetaUtils.Config.ReadSettingsString("Формирование_префикса_через_гриф"), out use))
                    _prefixViaVulture = use;
                else
                    _prefixViaVulture = false;
               
                return _prefixViaVulture.Value;
            }
            set { _prefixViaVulture = value; }
        }

        private static bool? _printingReverseSide;
        public static bool PrintingReverseSide
        {
            get
            {
                if (_printingReverseSide.HasValue)
                {
                    return _printingReverseSide.Value;
                }
                bool use;
                if (bool.TryParse(MetaUtils.Config.ReadSettingsString("Печать_оборотной_стороный_карточки"), out use))
                    _printingReverseSide = use;
                else
                    _printingReverseSide = false;
                return _printingReverseSide.Value;
            }
            set { _printingReverseSide = value; }
        }

        private static bool? _showDateControl;
        public static bool ShowDateControl
        {
            get
            {
                if (_showDateControl.HasValue)
                {
                    return _showDateControl.Value;
                }
                bool use;
                if (bool.TryParse(MetaUtils.Config.ReadSettingsString("Показывать_дату_контроля"), out use))
                    _showDateControl = use;
                else
                    _showDateControl = false;
                return _showDateControl.Value;
            }
            set { _showDateControl = value; }
        }

        private static bool? _serverModeFunctioning;
        public static bool ServerModeFunctioning
        {
            get
            {
                if (_serverModeFunctioning.HasValue)
                {
                    return _serverModeFunctioning.Value;
                }
                bool use;
                if (bool.TryParse(MetaUtils.Config.ReadSettingsString("Серверный_режим"), out use))
                    _serverModeFunctioning = use;
                else
                    _serverModeFunctioning = false;
                return _serverModeFunctioning.Value;
            }
            set { _serverModeFunctioning = value; }
        }

        private static bool? _monitorMode;
        public static bool MonitorMode
        {
            get
            {
                if (_monitorMode.HasValue)
                {
                    return _monitorMode.Value;
                }
                bool use;
                if (bool.TryParse(MetaUtils.Config.ReadSettingsString("Режим_отслеживания_судьбы_документа"), out use))
                    _monitorMode = use;
                else
                    _monitorMode = false;
                return _monitorMode.Value;
            }
            set { _monitorMode = value; }
        }

        private static bool? _showComments;
        public static bool ShowComments
        {
            get
            {
                if (_showComments.HasValue)
                {
                    return _showComments.Value;
                }
                bool use;
                _showComments = bool.TryParse(MetaUtils.Config.ReadSettingsString("Показывать_комментарии"), out use) && use;
                return _showComments.Value;
            }
            set { _showComments = value; }
        }

        private static bool? _showView;
        public static bool ShowView
        {
            get
            {
                if (_showView.HasValue)
                {
                    return _showView.Value;
                }
                bool use;
                _showView = bool.TryParse(MetaUtils.Config.ReadSettingsString("Показывать_вид_документа"), out use) && use;
                return _showView.Value;
            }
            set { _showView = value; }
        }

        private static bool? _showIndex;
        public static bool ShowIndex
        {
            get
            {
                if (_showIndex.HasValue)
                {
                    return _showIndex.Value;
                }
                bool use;
                if (bool.TryParse(MetaUtils.Config.ReadSettingsString("Показывать_индекс"), out use))
                    _showIndex = use;
                else
                    _showIndex = false;
                return _showIndex.Value;
            }
            set { _showIndex = value; }
        }

        private static bool? _highlite;
        public static bool Highlite
        {
            get
            {
                if (_highlite.HasValue)
                {
                    return _highlite.Value;
                }
                bool use;
                if (bool.TryParse(MetaUtils.Config.ReadSettingsString("Подсветка_строк"), out use))
                    _highlite = use;
                else
                    _highlite = false;
                return _highlite.Value;
            }
            set { _highlite = value; }
        }

        private static bool? _showWorking;
        public static bool ShowWorking
        {
            get
            {
                if (_showWorking.HasValue)
                {
                    return _showWorking.Value;
                }
                bool use;
                if (bool.TryParse(MetaUtils.Config.ReadSettingsString("Показывать_рабочие_документы"), out use))
                    _showWorking = use;
                else
                    _showWorking = false;
                return _showWorking.Value;
            }
            set { _showWorking = value; }
        }

        private static bool? _showClosing;
        public static bool ShowClosing
        {
            get
            {
                if (_showClosing.HasValue)
                {
                    return _showClosing.Value;
                }
                bool use;
                _showClosing = bool.TryParse(MetaUtils.Config.ReadSettingsString("Показывать_закрытые_документы"), out use) && use;
                return _showClosing.Value;
            }
            set { _showClosing = value; }
        }

        private static bool? _modeAccounting;
        public static bool ModeAccounting
        {
            get
            {
                if (_modeAccounting.HasValue)
                {
                    return _modeAccounting.Value;
                }
                bool use;
                _modeAccounting = bool.TryParse(MetaUtils.Config.ReadSettingsString("Однопользовательский_режим_работы"), out use) && use;
                return _modeAccounting.Value;
            }
            set { _modeAccounting = value; }
        }

        private static string _prefix;
        public static string Prefix
        {
            get
            {
                string use = MetaUtils.Config.ReadSettingsString("Префикс");
                _prefix = use;
                return _prefix;
            }
            set { _prefix = value; }
            
        }

        private static int _yearSearch;
        public static int YearSearch
        {
            get
            {
                if (_yearSearch == 0)
                {
                    int use = MetaUtils.Config.ReadSettingsInt("Год_поиска");
                    _yearSearch = use;
                }
                return _yearSearch;
            }
            set { _yearSearch = value; }
        }

        private static string _fontName;
        public static string FontName
        {
            get
            {
                if (_fontName == null)
                {
                    string use = MetaUtils.Config.ReadSettingsString("Название_шрифта_карточки");
                    _fontName = use;
                }
                return _fontName;
            }
            set { _fontName = value; }
            
        }

        private static int _fontSize;
        public static int FontSize
        {
            get
            {
                if (_fontSize == 0)
                {
                    int use = MetaUtils.Config.ReadSettingsInt("Размер_шрифта_карточки");
                    _fontSize = use;
                }
                return _fontSize;
            }
            set { _fontSize = value; }
        }

        private static string _fontNameMainForm;
        public static string FontNameMainForm
        {
            get
            {
                if (_fontNameMainForm == null)
                {
                    string use = MetaUtils.Config.ReadSettingsString("Название_шрифта_программы");
                    _fontNameMainForm = use;
                }
                return _fontNameMainForm;
            }
            set { _fontNameMainForm = value; }

        }

        private static int _fontSizeMainForm;
        public static int FontSizeMainForm
        {
            get
            {
                if (_fontSizeMainForm == 0)
                {
                    int use = MetaUtils.Config.ReadSettingsInt("Размер_шрифта_программы");
                    _fontSizeMainForm = use;
                }
                return _fontSizeMainForm;
            }
            set { _fontSizeMainForm = value; }
        }

        private static string _colorTransfer;
        public static string ColorTransfer
        {
            get
            {
                if (!string.IsNullOrEmpty(_colorTransfer))
                {
                    return _colorTransfer;
                }
                else
                {
                    string use = MetaUtils.Config.ReadSettingsString("Цвет_подсветки_передачи");
                    _colorTransfer = use;
                    return _colorTransfer;
                }
            }
            set { _colorTransfer = value; }
        }

        private static string _colorClose;
        public static string ColorClose
        {
            get
            {
                if (!string.IsNullOrEmpty(_colorClose))
                {
                    return _colorClose;
                }
                else
                {
                    string use = MetaUtils.Config.ReadSettingsString("Цвет_подсветки_закрытых");
                    _colorClose = use;
                    return _colorClose;
                }
            }
            set { _colorClose = value; }
        }

        private static string _colorDestruction;
        public static string ColorDestruction
        {
            get
            {
                if (!string.IsNullOrEmpty(_colorDestruction))
                {
                    return _colorDestruction;
                }
                else
                {
                    string use = MetaUtils.Config.ReadSettingsString("Цвет_подсветки_на_удаление");
                    _colorDestruction = use;
                    return _colorDestruction;
                }
            }
            set { _colorDestruction = value; }
        }

        private static bool? _trackTheReturn;
        public static bool TrackTheReturn
        {
            get
            {
                if (_trackTheReturn.HasValue)
                {
                    return _trackTheReturn.Value;
                }
                bool use;
                _trackTheReturn = bool.TryParse(MetaUtils.Config.ReadSettingsString("Функция_возврата"), out use) && use;
                return _trackTheReturn.Value;
            }
            set { _trackTheReturn = value; }
        }

        private static bool? _interactionWithTheEDMS;
        public static bool InteractionWithTheEDMS
        {
            get
            {
                if (_interactionWithTheEDMS.HasValue)
                {
                    return _interactionWithTheEDMS.Value;
                }
                bool use;
                _interactionWithTheEDMS = bool.TryParse(MetaUtils.Config.ReadSettingsString("Совместно_с_СЭД"), out use) && use;
                return _interactionWithTheEDMS.Value;
            }
            set { _interactionWithTheEDMS = value; }
        }

        private static bool? _viewMode;
        public static bool ViewMode
        {
            get
            {
                if (_viewMode.HasValue)
                {
                    return _viewMode.Value;
                }
                bool use;
                _viewMode = bool.TryParse(MetaUtils.Config.ReadSettingsString("Режим_просмотра"), out use) && use;
                return _viewMode.Value;
            }
            set { _viewMode = value; }
        }

        private static bool? _theModeOfFormationOfTheAct;
        public static bool TheModeOfFormationOfTheAct
        {
            get
            {
                if (_theModeOfFormationOfTheAct.HasValue)
                {
                    return _theModeOfFormationOfTheAct.Value;
                }
                bool use;
                _theModeOfFormationOfTheAct = bool.TryParse(MetaUtils.Config.ReadSettingsString("Режим_создания_актов"), out use) && use;
                return _theModeOfFormationOfTheAct.Value;
            }
            set { _theModeOfFormationOfTheAct = value; }
        }

        private static int _timePeriodDowload;
        public static int TimePeriodDowload
        {
            get
            {
                if (_timePeriodDowload == 0)
                {
                    int use = MetaUtils.Config.ReadSettingsInt("Врменной_интервал_загрузки_документов");
                    _timePeriodDowload = use;
                }
                return _timePeriodDowload;
            }
            set { _timePeriodDowload = value; }
        }

        public static Пользователи CurrentUser
        {
            get 
            {
                try
                {
                    return Dc.Пользователиs.FirstOrDefault(p => p.id_пользователя == GlobalClass.Dc.ПолучитьIDПользователя());
                }
                catch (InvalidCastException ex)
                {
                    return new Пользователи();
                }
            }
        }

        private static bool? _saveGrid;
        public static bool SaveGrid
        {
            get
            {
                if (_saveGrid.HasValue)
                {
                    return _saveGrid.Value;
                }
                bool use;
                _saveGrid = bool.TryParse(MetaUtils.Config.ReadSettingsString("Сохранять_изменения_грида"), out use) && use;
                return _saveGrid.Value;
            }
            set { _saveGrid = value; }
        }

        private static bool? _printJournal;
        public static bool FuctionPrintJournal
        {
            get
            {
                if (_printJournal.HasValue)
                {
                    return _printJournal.Value;
                }
                bool use;
                _printJournal = bool.TryParse(MetaUtils.Config.ReadSettingsString("Печать_жернала"), out use) && use;
                return _printJournal.Value;
            }
            set { _printJournal = value; }
        }


        private static bool? _closesTheWindowAfterPrinting;
        public static bool ClosesTheWindowAfterPrinting
        {
            get
            {
                if (_closesTheWindowAfterPrinting.HasValue)
                {
                    return _closesTheWindowAfterPrinting.Value;
                }
                bool use;
                _closesTheWindowAfterPrinting = bool.TryParse(MetaUtils.Config.ReadSettingsString("Закрытие_карточки_после_печати"), out use) && use;
                return _closesTheWindowAfterPrinting.Value;
            }
            set { _closesTheWindowAfterPrinting = value; }
        }


        #region Свойства полномочий
        private static РолиПолномочийПользователей Role
        {
            get { return GlobalClass.Dc.РолиПолномочийПользователейs.FirstOrDefault(p=>p.id_роли==CurrentUser.id_роли); }
        }
        
        public static bool CanRegister
        {
            get { return Role.Регистрация; }
        }
        public static bool CanEdit
        {
            get { return Role.Редактирвоание; }
        }
        public static bool SeesTheirDocuments
        {
            get { return Role.ПросмотрСобственныхДокументов; }
        }
        public static bool SeesAllDocuments
        {
            get { return Role.ПросмотрВсехДокументов; }
        }
        public static bool SeesDocumentsDepartament
        {
            get { return Role.ПросмотрДокументовОтдела; }
        }
        public static bool PrintCard
        {
            get { return Role.ПечатьКарточек; }
        }
        public static bool PrintStatements
        {
            get { return Role.ПечатьВедомостей; }
        }
        public static bool PrintJournal
        {
            get
            {
                return Role.ПечатьЖурнала;
            }
        }
        public static bool WorkingWithActs
        {
            get { return Role.РаботатьСАктами; }
        }
        public static bool CanEditDictionary
        {
            get { return Role.РедактироватьСловари; }
        }
        public static bool SeesStatistics
        {
            get { return Role.СмотретьСтатистику; }
        }

        private static int _widthSpliter;
        public static int WidthSpliter
        {
            get
            {
                if (_widthSpliter != 0) return _widthSpliter;
                var use = MetaUtils.Config.ReadSettingsInt("ШиринаСплитера");
                _widthSpliter = use;
                return _widthSpliter;
            }
            set { _widthSpliter = value; }
        }

        private static string _colorOfFocus;
        public static string ColorOfFocus
        {
            get
            {
                if (!string.IsNullOrEmpty(_colorOfFocus))
                {
                    return _colorOfFocus;
                }
                else
                {
                    string use = MetaUtils.Config.ReadSettingsString("Цвет_подсвечиваемого_поля");
                    _colorOfFocus = use;
                    return _colorOfFocus;
                }
            }
            set { _colorOfFocus = value; }
        }

        private static bool? _useTheSideMenu;
        public static bool UseTheSideMenu
        {
            get
            {
                if (_useTheSideMenu.HasValue)
                {
                    return _useTheSideMenu.Value;
                }
                bool use;
                _useTheSideMenu = bool.TryParse(MetaUtils.Config.ReadSettingsString("Использовать_боковое_меню"), out use) && use;
                return _useTheSideMenu.Value;
            }
            set { _useTheSideMenu = value; }
        }


        private static int _widthExpandNavBar;
        public static int WidthExpandNavBar
        {
            get
            {
                if (_widthExpandNavBar != 0) return _widthExpandNavBar;
                var use = MetaUtils.Config.ReadSettingsInt("ШиринаМенюОпераций");
                _widthExpandNavBar = use;
                return _widthExpandNavBar;
            }
            set { _widthExpandNavBar = value; }
        }

        #endregion


    }
}
