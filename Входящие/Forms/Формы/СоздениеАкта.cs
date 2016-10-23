using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonAppsTypes;
using DocInterfaces;
using DocsData;
using MetaDataPlus;
using MyData;
using MyStart.Контролы;
using Исходящие;

namespace MyStart.Формы
{
   
     
    public partial class СоздениеАкта : DevExpress.XtraEditors.XtraForm
    {
        private MyData.АктыНаУничтожение act;
        Контролы.ДокументыАкта лист3;
        static private РежимыРаботыСАктом mode;


        public СоздениеАкта(MyData.АктыНаУничтожение _act,РежимыРаботыСАктом _mode)
        {
            act = _act;
            InitializeComponent();
            РежимыРаботыСАктом mode;
            mode = _mode;
            ОбновитьФорму();
           
            BindingSource bs;
        }

        private void ОбновитьФорму()
        {
            if (!act.АктИсполнен)
            {
                if (String.IsNullOrEmpty(act.НомерАкта))
                {
                    navBarItem4.Visible = false;
                }
                else
                {
                    navBarItem4.Visible = true;
                    
                }
                navBarItem2.Caption = "Добавление зарегестрированных документов";
                navBarItem1.Visible = true;
            }
            if (act.АктИсполнен)
            {
                mode = РежимыРаботыСАктом.Просмотр;
                navBarItem2.Caption = "Список документов в акте";
                navBarItem4.Visible = false;
                navBarItem1.Visible = false;

            }
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Сброс();
            var bs = new BindingSource();
            if (act.АктИсполнен)
            {
                лист3 = new Контролы.ДокументыАкта(act, РежимыРаботыСАктом.Просмотр);
            }
            else
            {
                лист3 = new Контролы.ДокументыАкта(act, РежимыРаботыСАктом.Редактирование);
            }
            лист3.Dock = DockStyle.Fill;
            лист3.Parent = layoutControl2;
           

            
        }
        private void Сброс()
        {
            MyData.StaticMembers.dc.SubmitChanges();
            try
            {
                лист3.Parent = null;
            }
            catch
            {
            }
            
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                act.АктИсполнен = true;
                MyData.StaticMembers.dc.SubmitChanges();
                this.Close();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Для корректной работы перезапустите программу", "Внимание!", MessageBoxButtons.OK);
                this.Close();
            }
            
        }

        private void navBarItem1_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DocInterfaces.Акт dАкт = new DocInterfaces.Акт();
            dАкт.РегНомер = "???";
            dАкт.КраткоеНаименование = "Акт уничтожения №";
            dАкт.ДатаОт = DateTime.Today;
            List<Документы> списокДокументов =
                MyData.StaticMembers.dc.Документыs.Where(p => p.Код_акта == act.Код_акта).ToList();
            int i = 1;
            if (списокДокументов.Count==0)
                return;
            foreach (var документ in списокДокументов)
            {
                if (документ != null)
                {
                    try
                    {
                        dАкт.Экземпляры.Add(new дляАкта((int) документ.id_документа, i,
                            документ.РегНомер + "\n" +
                            (DateTime.Parse(документ.ДатаРегистрации.ToString())).ToShortDateString(),
                            документ.Видs[0].Текст, int.Parse(документ.НомерЭкземпляра),
                            int.Parse(документ.КоличествоЛистовЭкзепляра)));
                        i++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка заполнения карточки с  регистрационным номером " + документ.РегНомер, "Ошибка", MessageBoxButtons.OK);
                    }
                    
                }
            }
            
            if (DocsGlobalFactory.СоздательДокументов != null)
            {
                TemplateStruct tmp = new TemplateStruct(dАкт, null);
                МодельДанных md = new МодельДанных(new DocsData.DocsDataClassesDataContext(MetaUtils.Config.MainConnectString),  (new DynamicForms.DevAppSettings()).ФабрикаИнтерфейсов);
                int? did = DocsGlobalFactory.СоздательДокументов.ДокументИзШаблона(md, tmp, ТипыУчёта.Секретариат);
                if (did.HasValue)
                {
                 Выходные_документы vih_doc = md.DataContext.GetTable<Выходные_документы>().SingleOrDefault(x => x.N_выходного_документа == did.Value);

                    try
                    {
                        РегистрацияПечати регПечати = new РегистрацияПечати(ТипРабочегоМеста.ВходящиеПочта, did.Value, 1, "1-" + vih_doc.Количество_листов.ToString());

                        регПечати.Гриф = vih_doc.гриф;
                        регПечати.Краткое_наименование = vih_doc.Краткое_наименование;
                        //регПечати.РабМесто = ТипРабочегоМеста.ВходящиеПочта;
                        регПечати.N_выходного_документа = vih_doc.N_выходного_документа;
                        регПечати.Количество_страниц = vih_doc.Количество_листов;
                        регПечати.Регистрационный_номер = "171/199119";
                        DocsGlobalFactory.РегистраторКарточек = new РегистраторКарточки();
                        DocsGlobalFactory.РегистраторКарточек.ЗарегистрироватьДокумент(md.DataContext.Connection,
                            ref регПечати);
                        foreach (var документ in списокДокументов)
                        {
                            документ.Акт = регПечати.Регистрационный_номер;

                            MyData.Резолюция rez = new Резолюция();
                            rez.id_документа = документ.id_документа;
                            rez.НомерСтроки = документ.Резолюцияs.Count;
                            rez.Текст = DateTime.Today.ToShortDateString() + " В акт на уничтожение";
                            rez.ПризнакПечати = false;
                            MyData.StaticMembers.dc.Резолюцияs.InsertOnSubmit(rez);
                        }
                        //act.НомерАкта = регПечати.Регистрационный_номер;
                        act.ДатаСоздания = DateTime.Today.ToShortDateString();
                        MyData.StaticMembers.dc.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "btnВАкт_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            ОбновитьФорму();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Close();
        }

        private void СоздениеАкта_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MyStart.StaticMembers.ПечатьСпискаДляПроверки(act.Код_акта);
        }

    

      
    }
}