using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Security.Permissions;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Charts.Native;
using DevExpress.CodeParser.Patterns;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraRichEdit.Model;
using MetaDataPlus;
using Входящие.Forms;
using Входящие.InControls;
using Data;

using ParagraphAlignment = DevExpress.XtraRichEdit.API.Native.ParagraphAlignment;
using Редактор = ФормированиеВедомостей.Редактор;

namespace Входящие
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {

        public АктыНаУничтожение _act;
        private bool _формаЗагружена;
        public bool ФормаЗагружена
        {
            get { return _формаЗагружена; }
            set { _формаЗагружена = value; }
        }

        public Main()
        {
            ФормаЗагружена = false;
            InitializeComponent();
            InitOfAuthority();
            CheckUserPermissions();
            //ChangeMessage();
        }

        

        private void InitOfAuthority()
        {
            nb_working_with_act.Visible = GlobalClass.WorkingWithActs && GlobalClass.TheModeOfFormationOfTheAct;
            nb_reports.Visible = GlobalClass.PrintJournal && GlobalClass.FuctionPrintJournal;
            nb_clodsed_documents.Visible = GlobalClass.SeesStatistics;
            nb_uploaded_documents.Visible = GlobalClass.SeesStatistics;
            nb_returned_documents.Visible = GlobalClass.SeesAllDocuments && (GlobalClass.ShowDateControl||GlobalClass.TrackTheReturn);
            nb_edit_dictionary.Visible = GlobalClass.CanEditDictionary;
            //nb_settings.Visible = GlobalClass.CanEdit;
        }

        private void OpenJournal()
        {
            GlobalClass.ОбновитьDc();
            var journal =  GlobalClass.Dc.Журналыs.FirstOrDefault(p => !p.Окончен.HasValue); 
            var controlJournal = new Journal(journal);
            Classes.Methods.SetInPanelControl(panelMain, controlJournal);
        }

        private void nb_open_journal_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OpenJournal();
        }

        private void nb_settings_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (GlobalClass.SeesAllDocuments)
            {
                var form = new SettingsForm();
                form.Show();
            }
            else
            {
                var form = new LimitedSettingsForm();
                form.Show();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            OpenJournal();
            this.Text = Text +" - "+ GlobalClass.CurrentUser.Логин;
            splitContainer1.SplitterDistance = GlobalClass.WidthSpliter;
            nb_editor.Visible = GlobalClass.InteractionWithTheEDMS;
            nb_working_with_act.Visible = GlobalClass.TheModeOfFormationOfTheAct;
            ФормаЗагружена = true;
        }

        private void nb_uploaded_documents_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelMain.Controls.Clear();
            new UploadedDocuments {Dock = DockStyle.Fill, Parent = panelMain};
        }


        private void nb_clodsed_documents_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelMain.Controls.Clear();
            new ClosedDocuments {Dock = DockStyle.Fill, Parent = panelMain};
        }

        private void nb_edit_dictionary_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelMain.Controls.Clear();
            new EditorOfDictionaries {Dock = DockStyle.Fill, Parent = panelMain};
        }

        private void nb_print_journal_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PrintJournal();
        }


        private void PrintJournal()
        {
            var returnDate = new ReturnDate();
            var date = returnDate.OpenDialog();
            if (date != default(DateTime))
            {
                var docs = GlobalClass.Dc.Документыs.Where(p => p.ДатаРегистрации == date);

                var max = docs.Max(p => p.ВходящийНомер);
                var min = docs.Min(p => p.ВходящийНомер);
                if (max != null && min != null)
                {
                    var rangeOfNumbers = new RangeOfNumbers(min.Value, max.Value);
                    var range = rangeOfNumbers.OpenDialog();
                    var listId = new List<long>();
                    for (int i = range[0]; i <= range[1]; i++)
                    {
                        listId.Add(GlobalClass.Dc.Документыs.Where(p => p.ВходящийНомер == i && p.ДатаРегистрации == date).Select(p => p.id_документа).FirstOrDefault());
                    }

                    var размер_столбцов = new Dictionary<int, float> {{1, 140F}, {2, 450F}, {3, 410F}, {4, 320F}, {5, 380F}, {6, 200F}};

                    var название_столбцов = new Dictionary<int, string> {{1, "Гриф"}, {2, "Входящий номер и дата, \v подписной номер и дата, \v откуда поступил"}, {3, "Вид и содержание\vдокумента"}, {4, "Исполнитель,\vотметка о\vприложении"}, {5, "Номер экземпляра и \v количество листов,\vдата контроля"}, {6, "Подпись"}};

                    var данныеДляТаблицыs = new List<Редактор.Данные_для_таблицы>();
                    int номерСтроки = 0;
                    foreach (var номер_документа in listId)
                    {
                        var документ = GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа == номер_документа);
                        if (документ != null)
                        {
                            var ячейка1 = new Редактор.Данные_для_таблицы(0, номерСтроки, документ.Грифы.Гриф.ToString(CultureInfo.InvariantCulture));
                            данныеДляТаблицыs.Add(ячейка1);

                            var данные_ячейки_2 = new StringBuilder();
                            данные_ячейки_2.Append(документ.ВходящийНомер);
                            данные_ячейки_2.Append("\v");
                            данные_ячейки_2.Append(документ.ДатаРегистрации.Value.ToShortDateString());
                            данные_ячейки_2.Append("\v");
                            данные_ячейки_2.Append(документ.РегНомер);
                            string дата_подписи = "";
                            if (документ.ДатаПодписи.HasValue)
                            {
                                дата_подписи = документ.ДатаПодписи.Value.ToShortDateString();
                            }
                            данные_ячейки_2.Append(дата_подписи);
                            данные_ячейки_2.Append("\v");
                            данные_ячейки_2.Append(документ.Подразделения);
                            var ячейка2 = new Редактор.Данные_для_таблицы(1,номерСтроки, данные_ячейки_2.ToString()); 
                            данныеДляТаблицыs.Add(ячейка2);

                            var данные_ячейки_3 = new StringBuilder();
                            string видДокумента = "";
                            if (документ.ДатаПодписи.HasValue)
                            {
                                видДокумента = документ.ДатаПодписи.Value.ToShortDateString();
                            }
                            данные_ячейки_3.Append(видДокумента);
                            данные_ячейки_3.Append("\v");
                            данные_ячейки_3.Append(документ.НазваниеДокумента);
                            var ячейка3 = new Редактор.Данные_для_таблицы(2, номерСтроки, данные_ячейки_3.ToString());
                            данныеДляТаблицыs.Add(ячейка3);


                            var данные_ячейки_4 = new StringBuilder();
                            данные_ячейки_4.Append(документ.КомуАдресован.КомуАдресован1);
                            данные_ячейки_4.Append("\v");
                            данные_ячейки_4.Append(документ.НомераПриложений);
                            var ячейка4 = new Редактор.Данные_для_таблицы(3, номерСтроки, данные_ячейки_4.ToString());
                            данныеДляТаблицыs.Add(ячейка4);

                            var данные_ячейки_5 = new StringBuilder();
                           
                            данные_ячейки_5.Append(документ.НомерЭкземпляра);
                            данные_ячейки_5.Append("/");
                            данные_ячейки_5.Append(документ.КоличествоЛистовЭкзепляра);
                            if (документ.ДатаПодписи.HasValue && документ.ДатаКонтроля != null)
                            {
                                данные_ячейки_5.Append("\v");
                                string ДатаКонтроля = документ.ДатаКонтроля.Value.ToShortDateString();
                                данные_ячейки_5.Append(ДатаКонтроля);
                               
                            }
                            var ячейка5 = new Редактор.Данные_для_таблицы(4, номерСтроки, данные_ячейки_5.ToString());
                            данныеДляТаблицыs.Add(ячейка5);


                        }
                        номерСтроки++;
                    }

                    var заголовок = new StringBuilder("ЖУРНАЛ №____, том____, лист ____, дата ");
                    заголовок.Append(date.ToShortDateString());
                    var editorРедактор = new Редактор(заголовок.ToString(),14,размер_столбцов, название_столбцов,9,ParagraphAlignment.Center, данныеДляТаблицыs,5,11);
                    editorРедактор.Show();
                }
                else
                {
                    MessageBox.Show(@"Документов за данную дату не найдено.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void nb_edit_act_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelMain.Controls.Clear();
            var act = new ChoiceAct(ChooiseMode.Edit){ Dock = DockStyle.Fill, Parent = panelMain };
            act.ReturnAct += act_ReturnActEdit;
        }

        private void act_ReturnActEdit()
        {
            panelMain.Controls.Clear();
            new Act(_act, ChooiseMode.Edit) { Dock = DockStyle.Fill, Parent = panelMain };
        }

        private void act_ReturnActDontEdit()
        {
            panelMain.Controls.Clear();
            new Act(_act, ChooiseMode.DontEdit) { Dock = DockStyle.Fill, Parent = panelMain };
        }

        private void nb_view_act_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelMain.Controls.Clear();
            var act = new ChoiceAct(ChooiseMode.DontEdit) { Dock = DockStyle.Fill, Parent = panelMain };
            act.ReturnAct += act_ReturnActDontEdit;
        }

        private void nb_create_journal_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) { }

        private void nb_create_act_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var act = new АктыНаУничтожение { АктИсполнен = false, ДокументСоздан = false, Год = DateTime.Now.Year, Дата = DateTime.Now, ДатаСоздания = DateTime.Now.ToShortDateString() };
            if (!GlobalClass.InteractionWithTheEDMS)
            {
                var textForm = new TextForm("Номер акта");
                var Номер_акта = textForm.OpenDialog();
                act.НомерАкта = Номер_акта;
            }
            
            GlobalClass.Dc.АктыНаУничтожениеs.InsertOnSubmit(act);
            GlobalClass.Dc.SubmitChanges();

            panelMain.Controls.Clear();
            var frm = new ChoiceAct(ChooiseMode.Edit) { Dock = DockStyle.Fill, Parent = panelMain };
            frm.ReturnAct += act_ReturnActEdit;
        }

        private void nb_exit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Close();
        }

        private void nb_returned_documents_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelMain.Controls.Clear();
            new ReturnedDocuments() { Dock = DockStyle.Fill, Parent = panelMain };
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if(!ФормаЗагружена) return;
            GlobalClass.WidthSpliter = splitContainer1.SplitterDistance;
            Classes.Methods.StoreValueInConfig("ШиринаСплитера", GlobalClass.WidthSpliter);
        }

        public void HideThePanel()
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }

        private bool CheckUserPermissions()
        {
            try
            {
                SqlClientPermission permission = new SqlClientPermission(PermissionState.Unrestricted);
                permission.Demand();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //private void ChangeMessage()
        //{
        //    string connString = "Data Source=Slon;Initial Catalog=InPost_Test;Integrated Security=True";
        //    string Proc = "SELECT * FROM ЖурналОпераций ";
        //    if (!CheckUserPermissions()) MessageBox.Show("Error");
        //    SqlDependency.Stop(connString);
        //    SqlDependency.Start(connString);
        //    using (SqlConnection sqlConn = new SqlConnection(connString))
        //    {
        //        using (SqlCommand sqlCmd = new SqlCommand())
        //        {
        //            sqlCmd.Connection = sqlConn;
        //            sqlCmd.Connection.Open();
        //            sqlCmd.CommandType = CommandType.Text;
        //            sqlCmd.Notification = null;
        //            SqlDependency dependency = new SqlDependency(sqlCmd);
        //            dependency.OnChange += new OnChangeEventHandler(dependency_OnDataChengedDelegate);
        //            sqlConn.Open();
        //        }
        //    }
        //}

        //private void dependency_OnDataChengedDelegate(object sender, SqlNotificationEventArgs e)
        //{
        // try
        //    {
        //        Action action = () =>
        //        {
        //            AlertControl control = new AlertControl();
        //            control.FormLocation = AlertFormLocation.BottomRight;
        //            control.Show(this, @"Пришло сообщение", @"Включен режим группировки");
        //        };
        //        this.Invoke(action);
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message);
        //    }
        //}

       
    }
}