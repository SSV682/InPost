using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Data;
using Data.Classes;
using DevExpress.Data.Helpers;
using DevExpress.PivotGrid.Printing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using Входящие.Forms;
using Входящие.InControls;
using Входящие.Print;
using System.Configuration;
using CommonAppsTypes;

namespace Входящие.Classes
{
    public class Methods
    {
        public static void SetInPanelControl(PanelControl panel, UserControl control)
        {
            panel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.Parent = panel;
        }
        public static void SetInPanelControl(Panel panel, UserControl control)
        {
            panel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.Parent = panel;
        }
        public static void SetInPanelFormF4(PanelControl panel, FormF4 formF4)
        {
            panel.SuspendLayout();
            Control old = panel.Controls["List"];
            if (old != null)
            {
                panel.Controls.Remove(old);
                old.Dispose();
            }
            formF4.Visible = true;
            formF4.Dock = DockStyle.Fill;
            panel.Controls.Add(formF4);
            formF4.BringToFront();
            formF4.Name = "List";
            panel.ResumeLayout();
            panel.Update();
        }
        public static void SetInPanelFormF4(Panel panel, FormF4 formF4)
        {
            panel.SuspendLayout();
            Control old = panel.Controls["List"];
            if (old != null)
            {
                panel.Controls.Remove(old);
                old.Dispose();
            }
            formF4.Visible = true;
            formF4.Dock = DockStyle.Fill;
            panel.Controls.Add(formF4);

            formF4.BringToFront();
            formF4.Name = "List";
            panel.ResumeLayout();
            panel.Update();
        }
        public static void StoreValueInConfig(string nameOfConfiguration,object value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var collection = config.AppSettings.Settings;
            var p = collection[nameOfConfiguration];
            p.Value = value.ToString();
            config.Save();
        }
        public static void DowloadDataToGrid<T>(GridControl grid,IQueryable<T> data ) where T:class
        {
            var bs = new BindingSource();
            foreach (var value in data)
            {
                bs.Add(value);
            }
            grid.DataSource = bs;
        }
        public static bool ToCompareStrings(string firstString, string secondString)
        {
            if (firstString == null) throw new ArgumentNullException("firstString");
            return true;
        }
        public static void CloseDistiny(Документы document, DateTime date)
        {
            ЖурналОпераций журналОпераций = GlobalClass.Dc.ЖурналОперацийs.Where(p => p.id_документа == document.id_документа).OrderByDescending(p => p.датаНачалаОперации).ThenByDescending(p => p.id_записи).FirstOrDefault();
            if (журналОпераций != null)
            {
                журналОпераций.датаКонцаОперации = date;
                GlobalClass.Dc.SubmitChanges();
            }
        }
        public static void DeleteLastDistiny(Документы document)
        {
            ЖурналОпераций журналОпераций = document.ЖурналОперацийs.OrderByDescending(p => p.датаНачалаОперации).ThenByDescending(p => p.id_записи).FirstOrDefault();
            document.ЖурналОперацийs.Remove(журналОпераций);
            if (журналОпераций != null) {
                GlobalClass.Dc.ЖурналОперацийs.DeleteOnSubmit(журналОпераций);
                GlobalClass.Dc.SubmitChanges();
            }
            журналОпераций = document.ЖурналОперацийs.OrderByDescending(p => p.датаНачалаОперации).ThenByDescending(p => p.id_записи).FirstOrDefault();
            if (журналОпераций != null) журналОпераций.датаКонцаОперации = default(DateTime);

            if (журналОпераций != null)
                switch (журналОпераций.id_операции)
                {
                    case (1): {document.Закрыт = false; break;}
                    case (2): { document.Закрыт = true; break; }
                    case (3): { document.Закрыт = false; break; }
                    case (4): { document.Закрыт = true; break; }
                    case (5): { document.Закрыт = true; break; }
                    case (6): { document.Закрыт = true; break; }
                    case (7): { document.Закрыт = false; break; }
                    case (8): { document.Закрыт = true; break; }
                    case (9): { document.Закрыт = true; break; }
                    case (10): { document.Закрыт = true; break; }
                }


            GlobalClass.Dc.SubmitChanges();
        }
        public static Документы InitIncommingNumber(Документы document)
        {
            Документы doc = document;
            doc.ВходящийНомер = GlobalClass.Dc.ПолучитьВходящийНомер();
            var sb = new StringBuilder();
            sb.Append(GlobalClass.Prefix);
            if (GlobalClass.PrefixViaVulture)
            {
                if (doc.id_грифа == 3) { sb.Append("0"); }
                if (doc.id_грифа == 4) { sb.Append("00"); }
            }
            sb.Append(doc.ВходящийНомер);
            doc.ПолныйВходящийНомер = sb.ToString();
            return doc;
        }
        public static void DeleteDocument(Документы docДокументы)
        {
            GlobalClass.Dc.ВидИКраткоеСодержаниеs.DeleteAllOnSubmit(docДокументы.ВидИКраткоеСодержаниеs);
            GlobalClass.Dc.Резолюцияs.DeleteAllOnSubmit(docДокументы.Резолюцияs);
            GlobalClass.Dc.ЖурналОперацийs.DeleteAllOnSubmit(docДокументы.ЖурналОперацийs);
            GlobalClass.Dc.SubmitChanges();
            GlobalClass.Dc.Документыs.DeleteOnSubmit(docДокументы);
            GlobalClass.Dc.SubmitChanges();
        }
        public static void DeleteAct(АктыНаУничтожение act)
        {
            GlobalClass.Dc.АктыНаУничтожениеs.DeleteOnSubmit(act);
            GlobalClass.Dc.SubmitChanges();
        }
        public static void AddNewResolution(Документы document, string the_text_of_the_resolution, int bind_operation)
        {
            var resolution = new Резолюция { ПризнакПечати = false, Текст = the_text_of_the_resolution, НомерСтроки = document.Резолюцияs.Count, id_документа = document.id_документа,id_записи_операции = bind_operation};
            document.Резолюцияs.Add(resolution);
            GlobalClass.Dc.Резолюцияs.InsertOnSubmit(resolution);
           // GlobalClass.Dc.SubmitChanges();
        }
        public static void AddNewView(Документы document, string theTextOfTheResolution)
        {
            var view = new ВидИКраткоеСодержание { ПризнакПечати = false, Текст = theTextOfTheResolution, НомерСтроки = document.ВидИКраткоеСодержаниеs.Count, id_документа = document.id_документа};
            document.ВидИКраткоеСодержаниеs.Add(view);
            GlobalClass.Dc.ВидИКраткоеСодержаниеs.InsertOnSubmit(view);
            // GlobalClass.Dc.SubmitChanges();
        }
        public static void ClearTheFieldsOfTheAct(Документы document) { GlobalClass.Dc.ОчиститьПоляАкта(document.id_документа); }
        public static void DeleteTheLastResolution(Документы document)
        {
            var resolution = document.Резолюцияs.Last();
            document.Резолюцияs.Remove(resolution);
            GlobalClass.Dc.Резолюцияs.DeleteOnSubmit(resolution);
            GlobalClass.Dc.SubmitChanges();
            
        }
        public static void DeleteTheLastView(Документы document)
        {
            var view = document.ВидИКраткоеСодержаниеs.Last();
            document.ВидИКраткоеСодержаниеs.Remove(view);
            GlobalClass.Dc.ВидИКраткоеСодержаниеs.DeleteOnSubmit(view);
            GlobalClass.Dc.SubmitChanges();
        }
        public static void SendInUnit(Документы документ, string theNameOfTheUnit, string commentStr,DateTime date)
        {

            var comment = new StringBuilder();
            comment.Append(date.ToShortDateString());
            comment.Append(" отправлен в ");
            comment.Append(theNameOfTheUnit);
            if (!string.IsNullOrWhiteSpace(commentStr))
            {
                comment.Append(" ");
                comment.Append(commentStr);
            }
            var bindOperation = AddNewDistiny(документ, GlobalClass.Dc.Подразделенияs.Where(p => p.НазваниеПодразделения == theNameOfTheUnit).Select(p => p.id_подразделения).FirstOrDefault(),Operations.Send,comment.ToString(),date);

            var list = BrokenLines(comment.ToString(), 60);
            foreach (var currentString in list)
            {
                AddNewResolution(документ, currentString, bindOperation);
            }
            документ.Наличие = false;
            документ.Закрыт = true;
            GlobalClass.Dc.SubmitChanges();
        }
        public static void SendInUnit(Документы документ, int theIdOfTheUnit, string commentStr, DateTime date)
        {
            var unit = GlobalClass.Dc.Подразделенияs.FirstOrDefault(p => p.id_подразделения == theIdOfTheUnit);

            var comment = new StringBuilder();
            comment.Append(date.ToShortDateString());
            comment.Append(" отправлен в ");
            comment.Append(unit.НазваниеПодразделения);
            if (!string.IsNullOrWhiteSpace(commentStr))
            {
                comment.Append(" ");
                comment.Append(commentStr);
            }
            var bindOperation = AddNewDistiny(документ, GlobalClass.Dc.Подразделенияs.Where(p => p.НазваниеПодразделения == unit.НазваниеПодразделения).Select(p => p.id_подразделения).FirstOrDefault(), Operations.Send, comment.ToString(), date);
            var list = BrokenLines(comment.ToString(), 60);
            foreach (var currentString in list)
            {
                AddNewResolution(документ, currentString, bindOperation);
            }
            документ.Наличие = false;

            GlobalClass.Dc.SubmitChanges();
        }
        public static int AddNewDistiny(Документы _документ, int _id_исполнителя, Operations operation, string _комментарий, DateTime _датаНачалаОперации)
        {
            var newOperation = new ЖурналОпераций { id_документа = _документ.id_документа, id_исполнителя = _id_исполнителя, id_операции = (short)operation, id_пользователя = GlobalClass.Dc.Пользователиs.FirstOrDefault().id_пользователя, Комментарий = _комментарий, датаНачалаОперации = _датаНачалаОперации };
            GlobalClass.Dc.ЖурналОперацийs.InsertOnSubmit(newOperation);
            GlobalClass.Dc.SubmitChanges();
            _документ.ЖурналОперацийs.Add(newOperation);
            return newOperation.id_записи;
        }
        public static void ПечатьФ4СНастройкамиУк(Документы док, List<KeyValuePair<string, string>> parameters)
        {
            PrintMode mode;
            try {  mode = (bool) док.ПризнакПечати ? PrintMode.Partially : PrintMode.Full; }
            catch (Exception)
            {
                mode = PrintMode.Full;
            }

            int numberOfInstances = GlobalClass.NumbersCopies;
            if (GlobalClass.ConductSurvey)
            {
                var frm = new CalcForm("Количество экземпляров", numberOfInstances);
                numberOfInstances =  frm.OpenDialog();
            }


            if (numberOfInstances > 10 && MessageBox.Show(@"Подозрительно много экземпляров - " + numberOfInstances + @". Вы уверены?", @"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            parameters.Add(new KeyValuePair<string, string>("ekz", numberOfInstances.ToString(CultureInfo.InvariantCulture)));

            for (int i = 1; i <= numberOfInstances; i++)
            {
                int[] mas = ВычислитьКоличествоСтрокНаКарточкеУк(док, parameters);

                var содержание = док.ВидИКраткоеСодержаниеs.Select(view => new Data.Classes.StringsF4 {НомерСтроки = view.НомерСтроки, ПризнакПечати = view.ПризнакПечати, Текст = view.Текст}).ToList();

                var резолюции = new List<Data.Classes.StringsF4>();
                var допечатываемыеРезолюции = new List<Data.Classes.StringsF4>();
                var cardList = new List<KeyValuePair<ReportPrintTool, int[]>>();

               



                if (mode == PrintMode.Partially)
                {
                    резолюции.AddRange(from resolution in док.Резолюцияs where resolution.ПризнакПечати != null && (bool) resolution.ПризнакПечати select new Data.Classes.StringsF4 {НомерСтроки = resolution.НомерСтроки, ПризнакПечати = resolution.ПризнакПечати, Текст = resolution.Текст});
                    cardList.AddRange(ЗаполнитьКарточкуУк(mas, док, содержание, резолюции, 1, numberOfInstances, 0, parameters));
                }
                else
                {
                    резолюции.AddRange(док.Резолюцияs.Select(resolution => new Data.Classes.StringsF4 { НомерСтроки = resolution.НомерСтроки, ПризнакПечати = resolution.ПризнакПечати, Текст = resolution.Текст }));
                    cardList.AddRange(ЗаполнитьКарточкуУк(mas, док, содержание, резолюции, i, numberOfInstances, док.НомерПродолжения, parameters));
                }


                if (mode == PrintMode.Partially)
                {

                    KeyValuePair<ReportPrintTool, int[]> last = cardList.Last();
                    cardList.Clear();
                    допечатываемыеРезолюции.AddRange(from resolution in док.Резолюцияs where !resolution.ПризнакПечати select new Data.Classes.StringsF4 {НомерСтроки = resolution.НомерСтроки, ПризнакПечати = resolution.ПризнакПечати, Текст = resolution.Текст});
                    var количествоРаспечатанныхРезолюций = док.Резолюцияs.Count(p => p.ПризнакПечати);
                    var количествоНеРаспечатанныхРезолюций = док.Резолюцияs.Count(p => !p.ПризнакПечати);
                    if (количествоРаспечатанныхРезолюций % (mas[1] - mas[0] - 1) == 0 && количествоНеРаспечатанныхРезолюций>0)
                    {
                        док.содержаниеКарточки.Clear();
                        cardList.AddRange(ЗаполнитьКарточкуУк(mas, док, содержание, допечатываемыеРезолюции, i, numberOfInstances, количествоРаспечатанныхРезолюций / (mas[1] - mas[0] - 1), parameters));
                    }
                    else
                    {
                        cardList.AddRange(ЗаполнитьДопечатываемуюКарточкуУК(mas, док, содержание, допечатываемыеРезолюции, last.Value, parameters));
                    }
                    
                }


                foreach (var card in cardList)
                {
                    if (GlobalClass.FastModePrinting)
                    {
                        card.Key.Print();
                    }
                    else
                    {
                        ShowPreview(card.Key);
                    }


                }
                
            }
            foreach (var str in док.Резолюцияs)
            {
                str.ПризнакПечати = true;
            }
            foreach (var str in док.ВидИКраткоеСодержаниеs)
            {
                str.ПризнакПечати = true;
            }
        }
        private static IEnumerable<KeyValuePair<ReportPrintTool, int[]>> ЗаполнитьКарточкуУк(IList<int> mas, Документы док, List<Data.Classes.StringsF4> содержание, List<Data.Classes.StringsF4> резолюции, int nЭкз, int количествоЭкземпляров, int N_Продолжения, List<KeyValuePair<string, string>> parameters)
        {
            var retList = new List<KeyValuePair<ReportPrintTool, int[]>>();
            док.НомерЭкземпляраКарточки = nЭкз;
            док.НомерПродолжения = N_Продолжения;
            int вставленоСтрок = 0;
            if (содержание.Count + 2 > mas[1])
            {
                throw new Exception("Карточка не может быть напечатана, т.к. слишком много строк содержания");
            }
            док.СодержаниеКарточки.AddRange(содержание.OrderBy(p => p.НомерСтроки));

            вставленоСтрок += содержание.Count;
            if (mas[0] > содержание.Count)
            {

                while (док.СодержаниеКарточки.Count < mas[0])
                {
                    док.СодержаниеКарточки.Add(new Data.Classes.StringsF4 {Текст = " "});
                    вставленоСтрок += 1;
                }
            }
            int строкНаПоследнейСтранице = вставленоСтрок - mas[0];

            if (GlobalClass.PrintingReverseSide)
            {
                док.СодержаниеКарточки.Add(new Data.Classes.StringsF4 {Текст = "Резолюции и направление:"});
                вставленоСтрок += 1;

                var дляУдаления = new List<Data.Classes.StringsF4>();

                for (int i = 0; i < Math.Min(резолюции.Count, mas[1] - вставленоСтрок /*(mas[1] - mas[0])*/); i++)
                {
                    док.СодержаниеКарточки.Add(резолюции[i]);
                    дляУдаления.Add(резолюции[i]);
                    строкНаПоследнейСтранице += 1;
                }
                foreach (Data.Classes.StringsF4 строка in дляУдаления)
                {
                    резолюции.Remove(строка);
                }
            }

            var report = new Card(GlobalClass.PrintingReverseSide);
            ЗаполнитьПараметрыОтчетаУк(report, parameters);

            var l = new List<object> {док};
            report.DataSource = l;
            var rpt = new ReportPrintTool(report);
                
            report.CreateDocument();

         
            //Возвращаем
            retList.Add(new KeyValuePair<ReportPrintTool, int[]>(rpt, new[] { строкНаПоследнейСтранице, nЭкз, N_Продолжения }));
            
            if (GlobalClass.PrintingReverseSide)
            {
                if (резолюции.Count > 0)
                {

                    foreach (KeyValuePair<ReportPrintTool, int[]> card in retList)
                    {
                        if (GlobalClass.FastModePrinting)
                        {
                            card.Key.Print();
                        }
                        else
                        {
                            ShowPreview(card.Key);
                        }
                    }

                    object dbobj = док;
                    ((Документы)dbobj).содержаниеКарточки.Clear();
                    док = null;
                    retList.AddRange(ЗаполнитьКарточкуУк(mas, dbobj as Документы, содержание, резолюции, nЭкз, количествоЭкземпляров, N_Продолжения + 1, parameters));
                    док = (Документы)dbobj;
                }
            }
            return retList;
        }
        private static IEnumerable<KeyValuePair<ReportPrintTool, int[]>> ЗаполнитьДопечатываемуюКарточкуУК(int[] mas, Документы док, List<Data.Classes.StringsF4> содержание, List<Data.Classes.StringsF4> резолюции, int[] par, List<KeyValuePair<string, string>> parameters)
        {
            var retList = new List<KeyValuePair<ReportPrintTool, int[]>>();
            док.СодержаниеКарточки.Clear();
            var дляУдаления = new List<Data.Classes.StringsF4>();
            int строкНаПоследнейСтранице = par[0];
            // вставляем пустые строки
            int i = 0; // вставлено строк
            while (i < строкНаПоследнейСтранице+1)
            {
                док.СодержаниеКарточки.Add(new Data.Classes.StringsF4 { Текст = " " });
                i++;
            }

            for (i = 0; i < Math.Min(резолюции.Count, mas[1] - mas[0] - строкНаПоследнейСтранице-1 /*(mas[1] - mas[0])*/); i++)
            {
                док.СодержаниеКарточки.Add(резолюции[i]);
                дляУдаления.Add(резолюции[i]);
            }
            foreach (var строка in дляУдаления)
            {
                резолюции.Remove(строка);
            }

            var report = new CardPartially();
            var l = new List<object> {док};
            report.DataSource = l;
            var rpt = new ReportPrintTool(report);
            report.CreateDocument();

            

            retList.Add(new KeyValuePair<ReportPrintTool, int[]>(rpt, new int[] { строкНаПоследнейСтранице, par[1], par[2] }));



            foreach (KeyValuePair<ReportPrintTool, int[]> card in retList)
            {
                if (GlobalClass.FastModePrinting)
                {
                    card.Key.Print();
                }
                else
                {
                    ShowPreview(card.Key);
                }
                
            }
            retList.Clear();
            if (резолюции.Count > 0)
            {
                док.содержаниеКарточки.Clear();
                retList.AddRange(ЗаполнитьКарточкуУк(mas, док, содержание, резолюции, par[1], 0, par[2] + 1, parameters));
            }
            return retList;
        }
        private static int[] ВычислитьКоличествоСтрокНаКарточкеУк(Документы док, List<KeyValuePair<string, string>> parameters)
        {

            var mas = new int[2];
            int колВоСтраниц = 0;
            док.СодержаниеКарточки.Clear();
            while (колВоСтраниц < 2)
            {
                var report = new Card();
                var l = new List<object> {док};
                док.СодержаниеКарточки.Add(new Data.Classes.StringsF4 { Текст = " 1" });
                report.DataSource = l;
                //ЗаполнитьПараметрыОтчетаУк(report, parameters);
                report.CreateDocument();
                колВоСтраниц = report.Pages.Count;
            }
            mas[0] = док.СодержаниеКарточки.Count - 1;
            //if (док.НомераПриложений.IsEmpty() && mas[0]<9) { mas[0] = 9;}
            //else if (mas[0] < 8 && !док.НомераПриложений.IsEmpty()) { mas[0] = 8;}
            while (колВоСтраниц < 3)
            {
                var report = new Card(GlobalClass.PrintingReverseSide);
                var l = new List<object>();
                l.Add(док);
                док.СодержаниеКарточки.Add(new Data.Classes.StringsF4 { Текст = " " });
                report.DataSource = l;
                //ЗаполнитьПараметрыОтчетаУк(report, parameters);
                report.CreateDocument();
                колВоСтраниц = report.Pages.Count;
            }
            mas[1] = док.СодержаниеКарточки.Count - 1;
           
            док.СодержаниеКарточки.Clear();
            
            return mas;
        }
        private static void ЗаполнитьПараметрыОтчетаУк(Card report, List<KeyValuePair<string, string>> parameters)
        {
            try
            {
               // report.user.Value = parameters.FirstOrDefault(p => p.Key == "user").Value;
                //report.person.Value = parameters.FirstOrDefault(p => p.Key == "person").Value;
                //report.ekz.Value = parameters.FirstOrDefault(p => p.Key == "ekz").Value;
            }
            catch (Exception)
            { }

        }
        public static void ShowPreview(ReportPrintTool rpt)
        {
            rpt.PreviewForm.Load += PreviewForm_Load;

            rpt.PrintingSystem.Begin();
            rpt.PrintingSystem.PageSettings.Landscape = true;
            rpt.PrintingSystem.PageSettings.PaperKind = PaperKind.Custom;
            rpt.PrintingSystem.PageSettings.PaperName = "КарточкаФ4";
            rpt.PrintingSystem.End();
            rpt.ShowPreviewDialog();
        }
        private static void PreviewForm_Load(object sender, EventArgs e)
        {
            PrintPreviewFormEx frm = (PrintPreviewFormEx)sender;
            frm.PrintBarManager.PreviewBar.Manager.AllowCustomization = false;
            frm.PrintBarManager.PreviewBar.OptionsBar.AllowQuickCustomization = false;
            //список нужных кнопок
            List<int> l = new List<int>();
            l.Add(7); l.Add(10); l.Add(12); l.Add(13); l.Add(14); l.Add(16); l.Add(17); l.Add(18); l.Add(19); l.Add(20); l.Add(25);

            foreach (BarItemLink link in frm.PrintBarManager.PreviewBar.ItemLinks.Where(p => !l.Contains(frm.PrintBarManager.PreviewBar.ItemLinks.IndexOf(p))))
            {
                link.Visible = false;
            }

            frm.PrintBarManager.MainMenu.Visible = false;


        }
        public static List<string> BrokenLines(string originalString, int lineLenghtLimitaion)
        {
            var splitStrings = originalString.Split(new char[] {' '});
            var newString = new List<string>();
            var sb = new StringBuilder();
            
            foreach (var splitString in splitStrings)
            {
                var intermediateLine = sb.ToString();
                sb.Append(splitString);
                sb.Append(" ");
                if (sb.Length <= lineLenghtLimitaion) continue;
                newString.Add(intermediateLine);
                sb = new StringBuilder();
                sb.Append(splitString);
                sb.Append(" ");
            }
        newString.Add(sb.ToString());
        return newString;

        }

    }
}
