using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data;
using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Native;
using Входящие.Forms;
using ФормированиеВедомостей;

namespace Входящие.InControls
{
    public partial class UploadedDocuments : UserControl
    {

        private List<Документы> _docs;
        private BindingSource _bss;

        private Исполнители Executor
        {
            get
            {
                return GlobalClass.Dc.Исполнителиs.Where(p=>p.Удален==false).FirstOrDefault(p => p.Исполнитель == cbe_executor.Text);
            }
        }

        public Исполнители Исполнитель
        {
            get { return (cbe_executor.SelectedItem as Исполнители); }
            set
            {
                if (cbe_executor.Properties.Items.Count == 0)
                {
                    if (GlobalClass.Dc.Исполнителиs == null) return;
                    if (GlobalClass.SeesAllDocuments) { cbe_executor.Properties.Items.AddRange(GlobalClass.Dc.Исполнителиs.Where(p => p.Удален == false).Select(p => p.Исполнитель).Distinct().ToArray()); }
                    else if (GlobalClass.SeesDocumentsDepartament)
                    {
                        var списокПодразделенийВидимости = GlobalClass.Dc.ВидимостьПольномочийПользователяs.Where(p => p.id_пользователя == GlobalClass.CurrentUser.id_пользователя).Select(p=>p.id_подразделения);
                        foreach (var номерПодразделения in списокПодразделенийВидимости)
                        {
                            cbe_executor.Properties.Items.AddRange(GlobalClass.Dc.Исполнителиs.Where(p => p.id_подразделения == номерПодразделения).Select(p => p.Исполнитель).Distinct().ToArray());
                        }
                    }
                    if (Исполнитель == null) return;
                    cbe_executor.EditValue = Исполнитель.Исполнитель;
                    cbe_executor.SelectedValueChanged += cbe_executor_EditValueChanged;
                }
            }
        }

        public UploadedDocuments(Исполнители executor=null)
        {
            InitializeComponent();
            if (GlobalClass.SeesAllDocuments) { cbe_executor.Properties.Items.AddRange(GlobalClass.Dc.Исполнителиs.Where(p => p.Удален == false).Select(p => p.Исполнитель).Distinct().ToArray()); }
            else if (GlobalClass.SeesDocumentsDepartament)
            {
                var списокПодразделенийВидимости = GlobalClass.Dc.ВидимостьПольномочийПользователяs.Where(p => p.id_пользователя == GlobalClass.CurrentUser.id_пользователя).Select(p => p.id_подразделения);
                foreach (var номерПодразделения in списокПодразделенийВидимости)
                {
                    cbe_executor.Properties.Items.AddRange(GlobalClass.Dc.Исполнителиs.Where(p => p.id_подразделения == номерПодразделения).Select(p => p.Исполнитель).Distinct().ToArray());
                }
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                int yearSorting = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows().FirstOrDefault(), colГод).ToString());
                _bss = new BindingSource();
                _docs = new List<Документы>();
                var списокНомеров = GlobalClass.Dc.МестоположениеДокументаs.Where(p => p.id_операции == 1).Where(p => p.id_исполнителя == Executor.id_исполнителя).Select(p => p.id_документа);
                foreach (var номер in списокНомеров.Where(номер => GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа == номер).ДатаРегистрации.Value.Year == yearSorting)) 
                {
                    _bss.Add(GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа == номер));
                    _docs.Add(GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа == номер));
                }
                
                grid_UploadedDocs.DataSource = _bss;
            }
            catch
            {
                
            }
        }

        private void Reload()
        {   
            try
            {
            _bss = new BindingSource();

            var списокНомеров = GlobalClass.Dc.Документыs.Where(p => p.id_исполнителя == Executor.id_исполнителя).Select(p => p.id_документа);



            _docs = new List<Документы>();
            
            foreach (var номер in списокНомеров)
            {
                _bss.Add(GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа == номер));
                _docs.Add(GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа == номер));
            }
            
            grid_UploadedDocs.DataSource = _bss;
            gridControl1.DataSource = GlobalClass.Dc.ДокументыИсполнителейs.Where(p => p.Исполнитель == Executor.Исполнитель);
            }
            catch (Exception)
            {

            }
        }

        private void cbe_executor_EditValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void bbi_print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_docs.Any())
                {
                    var редактор = new Редактор();
                    редактор = РедактироватьДокумента(редактор, _docs, Executor.Исполнитель);
                    редактор.Show();
                }
                else
                {
                    MessageBox.Show("Документов за эту дату не найдено!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Выберите сотрудника!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void bbi_view_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reload();
        }

        private void gridView2_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            SaveGrid.SaveSettings.СохранитьГрид(grid_UploadedDocs);
        }

        private void gridControl2_Load(object sender, EventArgs e)
        {
            SaveGrid.SaveSettings.ВосстановитьГрид(grid_UploadedDocs);
        }

        private void gridView1_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            SaveGrid.SaveSettings.СохранитьГрид(gridControl1);
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            SaveGrid.SaveSettings.ВосстановитьГрид(gridControl1);
        }

        private void barToggleSwitchItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var main = this.Parent.Parent.Parent.Parent as Main;
            if (main != null) main.HideThePanel();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {PrintAllExecutors();}

        private void PrintAllExecutors()
        {
            var returnYear = new ReturnYear();
            var годЗапроса = returnYear.OpenDialog();
            var исполнители = GlobalClass.Dc.Исполнителиs;
            var редактор = new Редактор();
            progressBarControl1.Properties.Maximum = исполнители.Count();
            //progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.Minimum = 0;
            foreach (var исполнитель in исполнители)
            { 
                progressBarControl1.PerformStep();
                progressBarControl1.Update();
                var списокНомеров = GlobalClass.Dc.Документыs.Where(p => p.id_исполнителя == исполнитель.id_исполнителя).Select(p => p.id_документа);
                if (!списокНомеров.Any()) continue;
                _docs = new List<Документы>();
                foreach (var док in списокНомеров.Select(номер => GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа == номер && p.ДатаРегистрации.Value.Year == годЗапроса)).Where(док => док!=null)) {_docs.Add(док);}
                if (!_docs.Any()) continue;
                редактор =РедактироватьДокумента(редактор, _docs, исполнитель.Исполнитель);
            }
            progressBarControl1.Refresh();
            progressBarControl1.Properties.Step = 0;
            progressBarControl1.EditValue = 0;
            progressBarControl1.Update();
            редактор.Show();
            
        }

        private Редактор РедактироватьДокумента(Редактор редактор,IEnumerable<Документы> docs, string executor)
        {
            var размер_столбцов = new Dictionary<int, float> { { 1, 100F }, { 2, 140F }, { 3, 450F }, { 4, 410F }, { 5, 320F }, { 6, 430F }, { 7, 150F } };


            var название_столбцов = new Dictionary<int, string> { { 1, "п/п" }, { 2, "Гриф" }, { 3, "Входящий номер и дата, \v подписной номер и дата, \v откуда поступил" }, { 4, "Вид и содержание\vдокумента" }, { 5, "Исполнитель,\vотметка о\vприложении" }, { 6, "Номер экземпляра и \v количество листов,\vдата контроля" }, { 7, "Прим." } };

            var данныеДляТаблицыs = new List<Редактор.Данные_для_таблицы>();
            var номерСтроки = 0;
            var documents = docs.OrderBy(p => p.ДатаРегистрации).ThenBy(p => p.ВходящийНомер);
            foreach (var doc in documents)
            {
                var документ = doc;
                if (документ != null)
                {
                    Редактор.Данные_для_таблицы ячейка0 = new Редактор.Данные_для_таблицы(0, номерСтроки, (номерСтроки + 1).ToString(CultureInfo.InvariantCulture));
                    данныеДляТаблицыs.Add(ячейка0);

                    Редактор.Данные_для_таблицы ячейка1 = new Редактор.Данные_для_таблицы(1, номерСтроки, документ.Грифы.Гриф.ToString(CultureInfo.InvariantCulture));
                    данныеДляТаблицыs.Add(ячейка1);

                    StringBuilder данные_ячейки_2 = new StringBuilder();
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
                    var ячейка2 = new Редактор.Данные_для_таблицы(2, номерСтроки, данные_ячейки_2.ToString());
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
                    Редактор.Данные_для_таблицы ячейка3 = new Редактор.Данные_для_таблицы(3, номерСтроки, данные_ячейки_3.ToString());
                    данныеДляТаблицыs.Add(ячейка3);


                    StringBuilder данные_ячейки_4 = new StringBuilder();
                    данные_ячейки_4.Append(документ.КомуАдресован.КомуАдресован1);
                    данные_ячейки_4.Append("\v");
                    данные_ячейки_4.Append(документ.НомераПриложений);
                    Редактор.Данные_для_таблицы ячейка4 = new Редактор.Данные_для_таблицы(4, номерСтроки, данные_ячейки_4.ToString());
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
                    Редактор.Данные_для_таблицы ячейка5 = new Редактор.Данные_для_таблицы(5, номерСтроки, данные_ячейки_5.ToString());
                    данныеДляТаблицыs.Add(ячейка5);
                }
                номерСтроки++;
            }

            StringBuilder заголовок = new StringBuilder("Документы переданные в работу  ");
            заголовок.Append(executor);
            редактор.ДобавитьЗаголовок(заголовок.ToString(),14);
            редактор.СоздатьТаблицу(размер_столбцов,название_столбцов,9, ParagraphAlignment.Center, данныеДляТаблицыs, 5, 11);
            редактор.ПеренестиСтроку();
            return редактор;
        }
    }
}
