using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonAppsTypes;
using Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Native;
using DocInterfaces;
using DocsData;
using MetaDataPlus;
using ФормированиеВедомостей;
using Входящие.Classes;
using Входящие.Forms;
using Исходящие;


namespace Входящие.InControls
{
    public partial class Act : DevExpress.XtraEditors.XtraUserControl
    {
        private АктыНаУничтожение _act { get; set; }
        private ChooiseMode _mode { get; set; }

        public IQueryable<Документы> Documents {get { return GlobalClass.Dc.Документыs.Where(p => p.Код_акта == _act.Код_акта); }}
            
    
        public Act(АктыНаУничтожение act, ChooiseMode mode)
        {
            InitializeComponent();
            _act = act;
            _mode = mode;
            InitComponent();

        }

        private void grid_ActsDoc_Load(object sender, EventArgs e)
        {
            Methods.DowloadDataToGrid(grid_ActsDoc, Documents);
        }

        private void InitComponent()
        {
            if (_mode == ChooiseMode.DontEdit) { btn_Add.Enabled = false;btn_Delete.Enabled = false;}
            if (_mode == ChooiseMode.Edit) { btn_Add.Enabled = true; btn_Delete.Enabled = true; }
            if (GlobalClass.InteractionWithTheEDMS) 
            { 
                bbi_editor.Visibility = BarItemVisibility.Never;
                bbi_actPerformed.Visibility = BarItemVisibility.Always; bbi_createDocument.Visibility = BarItemVisibility.Always;
                if (_act.ДокументСоздан) { bbi_createDocument.Visibility = BarItemVisibility.Never; btn_Add.Enabled = false; btn_Delete.Enabled = false; }
                if (_act.АктИсполнен) { bbi_actPerformed.Visibility = BarItemVisibility.Never; bbi_createDocument.Visibility = BarItemVisibility.Never; btn_Add.Enabled = false; btn_Delete.Enabled = false; }
            }
            else{bbi_editor.Visibility=BarItemVisibility.Always; bbi_createDocument.Visibility=BarItemVisibility.Never;}
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            var choiseDocuments = new ChooseDocuments(GlobalClass.Dc.Документыs.Where(p=>p.НаУдаление).ToList());
            List<Документы> docs = choiseDocuments.ReturnData();
            if (docs == null) return;
            foreach (Документы doc in docs)
            {
                doc.Код_акта = _act.Код_акта;
                doc.НаУдаление = false;
            }
            GlobalClass.Dc.SubmitChanges();
            Methods.DowloadDataToGrid(grid_ActsDoc, Documents);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var choiseDocuments = new ChooseDocuments(GlobalClass.Dc.Документыs.Where(p => p.Код_акта == _act.Код_акта).ToList());
            List<Документы> docs = choiseDocuments.ReturnData();

            if (docs == null) return;
            foreach (Документы doc in docs)
            {
                doc.Код_акта = 0;
                doc.НаУдаление = true;
            }
            GlobalClass.Dc.SubmitChanges();
            Methods.DowloadDataToGrid(grid_ActsDoc, Documents);
        }

        private void bbi_createDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dАкт = new DocInterfaces.Акт {РегНомер = "???", КраткоеНаименование = "Акт уничтожения №", ДатаОт = DateTime.Today};
            List<Документы> списокДокументов = Documents.ToList();
            int i = 1;
            if (списокДокументов.Count == 0)
                return;
            foreach (var документ in списокДокументов)
            {
               
                if (документ != null)
                {
                    try
                    {
                        dАкт.Экземпляры.Add(new дляАкта((int)документ.id_документа, i,
                            документ.РегНомер + "\n" +
                            (DateTime.Parse(документ.ДатаРегистрации.ToString())).ToShortDateString(),
                            документ.ВидИКраткоеСодержаниеs[0].Текст, int.Parse(документ.НомерЭкземпляра),
                            int.Parse(документ.КоличествоЛистовЭкзепляра)));
                        i++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Ошибка заполнения карточки с  регистрационным номером " + документ.РегНомер +@". Документ будет удален из данного акта.", @"Ошибка", MessageBoxButtons.OK);
                        Methods.ClearTheFieldsOfTheAct(документ);
                        документ.НаУдаление = true;
                        GlobalClass.Dc.SubmitChanges();
                        //списокДокументов.Remove(документ);
                    }

                }
            }
            if (DocsGlobalFactory.СоздательДокументов != null)
            {
                var tmp = new TemplateStruct(dАкт, null);
                var md = new МодельДанных(new DocsData.DocsDataClassesDataContext(MetaUtils.Config.ReadSettingsString("MainConnectString")), (new DynamicForms.DevAppSettings()).ФабрикаИнтерфейсов);
                var did = DocsGlobalFactory.СоздательДокументов.ДокументИзШаблона(md.DataContext.Connection, tmp, ТипыУчёта.Секретариат);
                if (did.HasValue)
                {
                    var vihDoc = md.DataContext.GetTable<Выходные_документы>().SingleOrDefault(x => x.N_выходного_документа == did.Value);

                    try
                    {
                        if (vihDoc != null) 
                        {
                            var регПечати = new РегистрацияПечати(ТипРабочегоМеста.ВходящиеРегистрация, did.Value, 1, "1-" + vihDoc.Количество_листов) {Гриф = vihDoc.гриф, Краткое_наименование = vihDoc.Краткое_наименование, РабМесто = ТипРабочегоМеста.ВходящиеРегистрация, N_выходного_документа = vihDoc.N_выходного_документа, Количество_страниц = vihDoc.Количество_листов};
                            DocsGlobalFactory.РегистраторКарточек = new РегистраторКарточки();
                            DocsGlobalFactory.РегистраторКарточек.ЗарегистрироватьДокумент(md.DataContext.Connection, ref регПечати);
                            foreach (var документ in списокДокументов)
                            {
                                документ.Акт = регПечати.Регистрационный_номер;
                                var op = new ЖурналОпераций { id_документа = документ.id_документа, id_исполнителя = 0, id_операции = 5, id_пользователя = GlobalClass.CurrentUser.id_пользователя, Комментарий = DateTime.Today.ToShortDateString() + "Добавлен в акт на уничтожение", датаНачалаОперации = DateTime.Today };
                                GlobalClass.Dc.ЖурналОперацийs.InsertOnSubmit(op);
                                var rez = new Резолюция {id_документа = документ.id_документа, НомерСтроки = документ.Резолюцияs.Count, Текст = DateTime.Today.ToShortDateString() + " В акт на уничтожение", ПризнакПечати = false};
                                GlobalClass.Dc.Резолюцияs.InsertOnSubmit(rez);
                            }
                            _act.НомерАкта = регПечати.Регистрационный_номер;
                        }
                        _act.ДатаСоздания = DateTime.Today.ToShortDateString();
                        _act.ДокументСоздан = true;
                        GlobalClass.Dc.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, @"btnВАкт_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void bbi_printToCheck_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var listId = GlobalClass.Dc.Документыs.Where(p=>p.Код_акта==_act.Код_акта).Select(p=>p.id_документа).ToList();
            //var editorРедактор = new Редактор(listId, _act.НомерАкта , ModeEditor.CheckAct);
            //editorРедактор.Show();
        }

        private void bbi_actPerformed_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_act.АктИсполнен) return;
            var form = new ReturnDate();
            var date = form.OpenDialog().ToShortDateString();
            try
            {
                _act.АктИсполнен = true;
                _act.ДокументСоздан = true;
                var docs = Documents;
                foreach (var doc in docs){doc.Акт = _act.НомерАкта;doc.от2 = date;}
                GlobalClass.Dc.SubmitChanges();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show(@"Для корректной работы перезапустите программу", @"Внимание!",MessageBoxButtons.OK);
            }
        }

        private void bbi_editor_ItemClick(object sender, ItemClickEventArgs e) { PrintAct(); }

        private void PrintAct()
        {
           
            var docs = GlobalClass.Dc.Документыs.Where(p => p.Код_акта == _act.Код_акта);
            var listId = new List<long>();
            foreach (var doc in docs)
            {
                listId.Add(doc.id_документа);
            }
                    var размер_столбцов = new Dictionary<int, float> {{2, 140F}, {3, 450F}, {4, 410F}, {5, 320F}, {6, 380F}, {1, 100F}};


            var название_столбцов = new Dictionary<int, string> {{2, "Гриф"}, {3, "Входящий номер и дата, \v подписной номер и дата, \v откуда поступил"}, {4, "Вид и содержание\vдокумента"}, {5, "Исполнитель,\vотметка о\vприложении"}, {6, "Номер экземпляра и \v количество листов,\vдата контроля"}, {1, "п/п"}};

            var данныеДляТаблицыs = new List<Редактор.Данные_для_таблицы>();
                    int номер_строки = 0;
                    
                    foreach (var номер_документа in listId)
                    { 
                        Документы документ = GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа == номер_документа);
                        if (документ != null)
                        {
                            Редактор.Данные_для_таблицы ячейка0 = new Редактор.Данные_для_таблицы(0, номер_строки, (номер_строки+1).ToString(CultureInfo.InvariantCulture));
                            данныеДляТаблицыs.Add(ячейка0);
                            Редактор.Данные_для_таблицы ячейка1 = new Редактор.Данные_для_таблицы(1, номер_строки, документ.Грифы.Гриф.ToString());
                            данныеДляТаблицыs.Add(ячейка1);

                            StringBuilder данные_ячейки_2 = new StringBuilder();
                            данные_ячейки_2.Append(документ.ПолныйВходящийНомер);
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
                            var ячейка2 = new Редактор.Данные_для_таблицы(2, номер_строки, данные_ячейки_2.ToString());
                            данныеДляТаблицыs.Add(ячейка2);

                            StringBuilder данные_ячейки_3 = new StringBuilder();
                            string видДокумента = "";
                            if (документ.ДатаПодписи.HasValue)
                            {
                                видДокумента = документ.ДатаПодписи.Value.ToShortDateString();
                            }
                            данные_ячейки_3.Append(видДокумента);
                            данные_ячейки_3.Append("\v");
                            данные_ячейки_3.Append(документ.НазваниеДокумента);
                            Редактор.Данные_для_таблицы ячейка3 = new Редактор.Данные_для_таблицы(3, номер_строки, данные_ячейки_3.ToString());
                            данныеДляТаблицыs.Add(ячейка3);


                            StringBuilder данные_ячейки_4 = new StringBuilder();
                            данные_ячейки_4.Append(документ.КомуАдресован.КомуАдресован1);
                            данные_ячейки_4.Append("\v");
                            данные_ячейки_4.Append(документ.НомераПриложений);
                            Редактор.Данные_для_таблицы ячейка4 = new Редактор.Данные_для_таблицы(4, номер_строки, данные_ячейки_4.ToString());
                            данныеДляТаблицыs.Add(ячейка4);

                            StringBuilder данные_ячейки_5 = new StringBuilder();

                            данные_ячейки_5.Append(документ.НомерЭкземпляра);
                            данные_ячейки_5.Append("/");
                            данные_ячейки_5.Append(документ.КоличествоЛистовЭкзепляра);
                            if (документ.ДатаПодписи.HasValue && документ.ДатаКонтроля != null)
                            {
                                данные_ячейки_5.Append("\v");
                                string ДатаКонтроля = документ.ДатаКонтроля.Value.ToShortDateString();
                                данные_ячейки_5.Append(ДатаКонтроля);

                            }
                            Редактор.Данные_для_таблицы ячейка5 = new Редактор.Данные_для_таблицы(5, номер_строки, данные_ячейки_5.ToString());
                            данныеДляТаблицыs.Add(ячейка5);


                        }
                        номер_строки++;
                    }

                    StringBuilder заголовок = new StringBuilder("Акт № ");
                    заголовок.Append(_act.НомерАкта);
                    заголовок.Append(" от ");  
                    заголовок.Append(_act.ДатаСоздания);
                    var editorРедактор = new Редактор(заголовок.ToString(), 14, размер_столбцов, название_столбцов, 9, ParagraphAlignment.Center, данныеДляТаблицыs, 5, 11);
                    editorРедактор.Show();
                }
               
      }
}

