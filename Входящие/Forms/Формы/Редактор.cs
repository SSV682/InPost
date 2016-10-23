using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Office.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Export;
using DevExpress.XtraRichEdit.Services;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.API.Native.Implementation;
using MyData;
using Paragraph = DevExpress.XtraRichEdit.API.Native.Paragraph;
using Table = DevExpress.XtraRichEdit.API.Native.Table;

namespace MyStart.Формы
{
    public partial class Редактор : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private readonly int _код_Акта;

        public Редактор(IQueryable<long> dbdocs,int код_Акта)
        {
            _код_Акта = код_Акта;
            InitializeComponent();
            richEditControl1.CreateNewDocument();
            richEditControl1.Update();
            CreateTable(dbdocs);
            richEditControl1.EndUpdate();
        }

        public Редактор(int код_Акта)
        {
            InitializeComponent();
            _код_Акта = код_Акта;
            string path = MyData.StaticMembers.dc.ДокументыРедактораs.Where(p => p.Код_акта == код_Акта).Select(p => p.Путь).First();
            IQueryable<long> dbdocs = MyData.StaticMembers.dc.Документыs.Where(p => p.Код_акта == код_Акта).Select(p => p.id_документа);
            richEditControl1.LoadDocument(@path);
            richEditControl1.Update();
            RefreshTable(dbdocs);
            richEditControl1.EndUpdate();
        } 

        public Редактор(List<long> dbdocs, DateTime date)
        {
            InitializeComponent();
            richEditControl1.CreateNewDocument();
            richEditControl1.Update();
            CreateTableJournal(dbdocs, date);
            richEditControl1.Document.DefaultCharacterProperties.FontSize = 10;
            richEditControl1.EndUpdate();
        }

        public Редактор(List<long> dbdocs, string debtors)
        {
            InitializeComponent();
            richEditControl1.CreateNewDocument();
            richEditControl1.Update();
            CreateTableDebtors(dbdocs, debtors);
            richEditControl1.Document.DefaultCharacterProperties.FontSize = 10;
            richEditControl1.EndUpdate();
        }

        private void CreateTable(IQueryable<long> dbdocs)
        {

            SubDocument doc = richEditControl1.Document;
            //doc.BeginUpdate();
            DocumentPosition pos = doc.Range.Start;

            doc = pos.BeginUpdateDocument();
            Paragraph paragraph = doc.Paragraphs.Get(pos);
            DocumentPosition newPos = doc.CreatePosition(paragraph.Range.End.ToInt() - 1);
            doc.InsertText(newPos, "АКТ № "+MyData.StaticMembers.dc.АктыНаУничтожениеs.Where(p=>p.Код_акта==_код_Акта).Select(p=>p.НомерАкта).FirstOrDefault());


            ParagraphProperties pp_HeadingGrif = doc.BeginUpdateParagraphs(paragraph.Range);
            pp_HeadingGrif.Alignment = ParagraphAlignment.Center;
            doc.EndUpdateParagraphs(pp_HeadingGrif);
            pos.EndUpdateDocument(doc);

            doc.BeginUpdate();
            Table table = doc.Tables.Create(doc.CreatePosition(paragraph.Range.End.ToInt()), 1, 6, AutoFitBehaviorType.AutoFitToWindow);
            try
            {
                table.BeginUpdate();
                //CharacterProperties cp_table = doc.BeginUpdateCharacters(table.Range);
                //cp_table.FontSize = 10;
                //cp_table.FontName = "TimesNewRoman";
                doc.InsertSingleLineText(table[0, 0].Range.Start, "п/п");
                ParagraphProperties pp_HeadingRegPP = doc.BeginUpdateParagraphs(table[0, 0].Range);
                pp_HeadingRegPP.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingRegPP);


                doc.InsertSingleLineText(table[0, 1].Range.Start, "Регистрационный номер,\n дата документа(дела)");
                ParagraphProperties pp_HeadingRegNumber = doc.BeginUpdateParagraphs(table[0, 1].Range);
                pp_HeadingRegNumber.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingRegNumber);

                doc.InsertSingleLineText(table[0, 2].Range.Start, "Наименование(заголовок) документа\n(дела)");
                ParagraphProperties pp_HeadingView = doc.BeginUpdateParagraphs(table[0, 2].Range);
                pp_HeadingView.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingView);

                doc.InsertSingleLineText(table[0, 3].Range.Start, "Количетсво экземпляров");
                ParagraphProperties pp_HeadingKol= doc.BeginUpdateParagraphs(table[0, 3].Range);
                pp_HeadingKol.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingKol);

                doc.InsertSingleLineText(table[0, 4].Range.Start, "Номер экземпляра");
                ParagraphProperties pp_HeadingEkz = doc.BeginUpdateParagraphs(table[0,4].Range);
                pp_HeadingEkz.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingEkz);

                doc.InsertSingleLineText(table[0, 5].Range.Start, "Кол-во листов\n в экземпляре");
                ParagraphProperties pp_HeadingList = doc.BeginUpdateParagraphs(table[0, 5].Range);
                pp_HeadingList.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingList);

                table.RightPadding = Units.InchesToDocumentsF(0.08f);
                table.LeftPadding = Units.InchesToDocumentsF(0.08f);

                table.TableLayout = DevExpress.XtraRichEdit.API.Native.TableLayoutType.Autofit;
                table.ForEachCell(((cell, rowIndex, cellIndex) => { cell.PreferredWidthType = WidthType.Auto; }));

            }
            finally
            {

                table.EndUpdate();
            }
            int i = 0;
            try
            {
                table.BeginUpdate();
                foreach (var dbdoc in dbdocs)
                {
                    i++;
                    StringBuilder stringBuilder = new StringBuilder();
                    
                    TableRow row = table.Rows.Append();
                    TableCell cell = row.FirstCell;
                    MyData.Документы docДокументы =
                        MyData.StaticMembers.dc.Документыs.Where(p => p.id_документа == dbdoc).FirstOrDefault();
                    stringBuilder.Append(docДокументы.КоличествоЛистовЭкзепляра);
                    if (docДокументы.ВидДокумента != null)
                    {
                        stringBuilder.Append(" \n(");
                        stringBuilder.Append(docДокументы.ВидДокумента.ВидДокумента1);
                        stringBuilder.Append(")");
                    }
                    doc.InsertSingleLineText(cell.Range.Start, i.ToString());
                    doc.InsertSingleLineText(cell.Next.Range.Start, docДокументы.РегНомер);
                    doc.InsertSingleLineText(cell.Next.Next.Range.Start, docДокументы.НазваниеДокумента);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Range.Start, "1");
                    doc.InsertSingleLineText(cell.Next.Next.Next.Next.Range.Start, docДокументы.НомерЭкземпляра);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Next.Next.Range.Start,stringBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                table.EndUpdate();
            }
            doc.EndUpdate();

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {   
            richEditControl1.SaveDocument(_код_Акта+ ".rtf", DocumentFormat.Rtf);
            System.IO.FileInfo fi = new FileInfo(_код_Акта + ".rtf");

            var spisok =
                MyData.StaticMembers.dc.ДокументыРедактораs.Where(p=>p.Код_акта==_код_Акта).FirstOrDefault();
            if (spisok==null)
            {
                MyData.ДокументыРедактора doc = new ДокументыРедактора();
            doc.id_пользователя = MyData.StaticMembers.пользователь.id_пользователя;
            doc.Код_акта = _код_Акта;
                doc.Путь = Application.StartupPath.ToString() + "\\" + _код_Акта+".rtf";
                       
                 MyData.StaticMembers.dc.ДокументыРедактораs.InsertOnSubmit(doc);
                 MyData.StaticMembers.dc.SubmitChanges();
            }
        }

        private void RefreshTable(IQueryable<long> dbdocs)
        {
            SubDocument doc = richEditControl1.Document;
            DocumentPosition pos = doc.Tables[0].Range.End;
            doc.Tables.Remove(doc.Tables[0]);
            doc.BeginUpdate();
            Table table = doc.Tables.Create(pos, 1, 6, AutoFitBehaviorType.AutoFitToWindow);
            try
            {
                table.BeginUpdate();
                //CharacterProperties cp_table = doc.BeginUpdateCharacters(table.Range);
                //cp_table.FontSize = 10;
                //cp_table.FontName = "TimesNewRoman";
                doc.InsertSingleLineText(table[0, 0].Range.Start, "п/п");
                ParagraphProperties pp_HeadingRegPP = doc.BeginUpdateParagraphs(table[0, 0].Range);
                pp_HeadingRegPP.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingRegPP);


                doc.InsertSingleLineText(table[0, 1].Range.Start, "Регистрационный номер,\n дата документа(дела)");
                ParagraphProperties pp_HeadingRegNumber = doc.BeginUpdateParagraphs(table[0, 1].Range);
                pp_HeadingRegNumber.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingRegNumber);

                doc.InsertSingleLineText(table[0, 2].Range.Start, "Наименование(заголовок) документа\n(дела)");
                ParagraphProperties pp_HeadingView = doc.BeginUpdateParagraphs(table[0, 2].Range);
                pp_HeadingView.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingView);

                doc.InsertSingleLineText(table[0, 3].Range.Start, "Количетсво экземпляров");
                ParagraphProperties pp_HeadingKol = doc.BeginUpdateParagraphs(table[0, 3].Range);
                pp_HeadingKol.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingKol);

                doc.InsertSingleLineText(table[0, 4].Range.Start, "Номер экземпляра");
                ParagraphProperties pp_HeadingEkz = doc.BeginUpdateParagraphs(table[0, 4].Range);
                pp_HeadingEkz.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingEkz);

                doc.InsertSingleLineText(table[0, 5].Range.Start, "Кол-во листов\n в экземпляре");
                ParagraphProperties pp_HeadingList = doc.BeginUpdateParagraphs(table[0, 5].Range);
                pp_HeadingList.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingList);

                table.RightPadding = Units.InchesToDocumentsF(0.08f);
                table.LeftPadding = Units.InchesToDocumentsF(0.08f);

                table.TableLayout = DevExpress.XtraRichEdit.API.Native.TableLayoutType.Autofit;
                table.ForEachCell(((cell, rowIndex, cellIndex) => { cell.PreferredWidthType = WidthType.Auto; }));

            }
            finally
            {

                table.EndUpdate();
            }
            int i = 0;
            try
            {
                table.BeginUpdate();
                foreach (var dbdoc in dbdocs)
                {
                    i++;
                    TableRow row = table.Rows.Append();
                    TableCell cell = row.FirstCell;
                    MyData.Документы docДокументы =
                        MyData.StaticMembers.dc.Документыs.Where(p => p.id_документа == dbdoc).FirstOrDefault();
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(docДокументы.КоличествоЛистовЭкзепляра);
                    if (docДокументы.ВидДокумента != null)
                    {
                        stringBuilder.Append(" \n(");
                        stringBuilder.Append(docДокументы.ВидДокумента.ВидДокумента1);
                        stringBuilder.Append(")");
                    }
                    doc.InsertSingleLineText(cell.Range.Start, i.ToString());
                    doc.InsertSingleLineText(cell.Next.Range.Start, docДокументы.РегНомер);
                    doc.InsertSingleLineText(cell.Next.Next.Range.Start, docДокументы.НазваниеДокумента);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Range.Start, "1");
                    doc.InsertSingleLineText(cell.Next.Next.Next.Next.Range.Start, docДокументы.НомерЭкземпляра);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Next.Next.Range.Start, stringBuilder.ToString());
                    
                }
            }
            finally
            {
                table.EndUpdate();
            }
            
            
            doc.EndUpdate();

        }

        private void CreateTableJournal(List<long> dbdocs, DateTime date)
        {
            SubDocument doc = richEditControl1.Document;
            //CharacterProperties cp = richEditControl1.Document.BeginUpdateCharacters(cp);
            //doc.BeginUpdate();
            DocumentPosition pos = doc.Range.Start;

            doc = pos.BeginUpdateDocument();
            Paragraph paragraph = doc.Paragraphs.Get(pos);
            DocumentPosition newPos = doc.CreatePosition(paragraph.Range.End.ToInt() - 1);
            StringBuilder insertString = new StringBuilder("Документы зарегистрированные за ");
            insertString.Append(date.ToShortDateString());

            doc.InsertText(newPos, insertString.ToString());

            ParagraphProperties pp_HeadingGrif = doc.BeginUpdateParagraphs(paragraph.Range);
            pp_HeadingGrif.Alignment = ParagraphAlignment.Center;
            newPos = doc.CreatePosition(paragraph.Range.End.ToInt());
            doc.InsertText(newPos, "\v ");
            doc.EndUpdateParagraphs(pp_HeadingGrif);
            pos.EndUpdateDocument(doc);

            doc.BeginUpdate();
            Table table = doc.Tables.Create(doc.CreatePosition(paragraph.Range.End.ToInt()), 1, 6, AutoFitBehaviorType.FixedColumnWidth);



            try
            {
                table.BeginUpdate();


                doc.InsertSingleLineText(table[0, 0].Range.Start, "Гриф");
                ParagraphProperties pp_HeadingRegPP = doc.BeginUpdateParagraphs(table[0, 0].Range);
                pp_HeadingRegPP.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingRegPP);

                doc.InsertSingleLineText(table[0, 1].Range.Start, "Вх.номер\vДата рег.\vРег.номер\vДата подписи\vОткуда");
                ParagraphProperties pp_HeadingRegNumber = doc.BeginUpdateParagraphs(table[0, 1].Range);
                pp_HeadingRegNumber.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingRegNumber);

                doc.InsertSingleLineText(table[0, 2].Range.Start, "Вид и содержание\vдокумента");
                ParagraphProperties pp_HeadingView = doc.BeginUpdateParagraphs(table[0, 2].Range);
                pp_HeadingView.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingView);

                doc.InsertSingleLineText(table[0, 3].Range.Start, "Исполнитель\vпроложение");
                ParagraphProperties pp_HeadingEkz = doc.BeginUpdateParagraphs(table[0, 3].Range);
                pp_HeadingEkz.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingEkz);

                doc.InsertSingleLineText(table[0, 4].Range.Start, "Экз/лист\v Дата контроля");
                ParagraphProperties pp_HeadingList = doc.BeginUpdateParagraphs(table[0, 4].Range);
                pp_HeadingList.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingList);

                doc.InsertSingleLineText(table[0, 5].Range.Start, "Подпись");
                ParagraphProperties pp_HeadingIsp = doc.BeginUpdateParagraphs(table[0, 5].Range);
                pp_HeadingIsp.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingIsp);

                table.RightPadding = Units.InchesToDocumentsF(0.08f);
                table.LeftPadding = Units.InchesToDocumentsF(0.08f);
            }
            finally
            {

                table.EndUpdate();
            }
            NativeSectionPage page = (DevExpress.XtraRichEdit.API.Native.Implementation.NativeSectionPage)richEditControl1.Document.Sections[0].Page;
            int i = 0;
            try
            {
                table.BeginUpdate();
                foreach (var dbdoc in dbdocs)
                {
                    i++;
                    TableRow row = table.Rows.Append();
                    table.PreferredWidth = page.Width - 500F;
                    table.PreferredWidthType = WidthType.Fixed;
                    if (i <= 5)
                    {
                        row.HeightType = HeightType.Exact;
                        row.Height = 500F;
                    }
                    else
                    {
                        float HeightPage = page.Height;
                        row.HeightType = HeightType.Exact;
                        row.Height = (HeightPage / 6) + 10F;
                    }
                    for (int k = 0; k < table.FirstRow.Cells.Count; k++)
                    {
                        table.Rows[row.Index].Cells[0].PreferredWidth = 70F;
                        table.Rows[row.Index].Cells[0].PreferredWidthType = WidthType.Fixed;
                        table.Rows[row.Index].Cells[1].PreferredWidth = 650F;
                        table.Rows[row.Index].Cells[1].PreferredWidthType = WidthType.Fixed;
                        table.Rows[row.Index].Cells[2].PreferredWidth = 700F;
                        table.Rows[row.Index].Cells[2].PreferredWidthType = WidthType.Fixed;
                        table.Rows[row.Index].Cells[3].PreferredWidth = 500F;
                        table.Rows[row.Index].Cells[3].PreferredWidthType = WidthType.Fixed;
                        table.Rows[row.Index].Cells[4].PreferredWidth = 150F;
                        table.Rows[row.Index].Cells[4].PreferredWidthType = WidthType.Fixed;
                        table.Rows[row.Index].Cells[5].PreferredWidth = 80F;
                        table.Rows[row.Index].Cells[5].PreferredWidthType = WidthType.Fixed;
                    }

                    TableCell cell = row.FirstCell;

                    MyData.Документы docДокументы = MyData.StaticMembers.dc.Документыs.Where(p => p.id_документа == dbdoc).FirstOrDefault();
                    string val = "";
                    if (docДокументы.ДатаПодписи.HasValue)
                    {
                        val = docДокументы.ДатаПодписи.Value.ToShortDateString();
                    }
                    string val2 = "";
                    if (docДокументы.ДатаКонтроля.HasValue)
                    {
                        val2 = docДокументы.ДатаКонтроля.Value.ToShortDateString();
                    }
                    doc.InsertSingleLineText(cell.Range.Start, docДокументы.Грифы.Гриф);
                    doc.InsertSingleLineText(cell.Next.Range.Start, docДокументы.ВходящийНомер + "\v" + docДокументы.ДатаРегистрации.Value.ToShortDateString() + "\v" + docДокументы.РегНомер + "\v " + val + "\v" + docДокументы.Подразделения);
                    doc.InsertSingleLineText(cell.Next.Next.Range.Start, docДокументы.НазваниеДокумента);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Range.Start, docДокументы.КомуАдресован.КомуАдресован1 + "\v " + docДокументы.НомераПриложений);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Next.Range.Start, docДокументы.КоличествоЛистовЭкзепляра + "/" + docДокументы.КоличествоЛистовЭкзепляра + "\v " + val2);
                }
            }
            finally
            {
                table.EndUpdate();
            }
            doc.EndUpdate();

        }

        private void CreateTableJournalCP(List<long> dbdocs, DateTime date)
        {

            SubDocument doc = richEditControl1.Document;
            //CharacterProperties cp = richEditControl1.Document.BeginUpdateCharacters(cp);
            //doc.BeginUpdate();
            DocumentPosition pos = doc.Range.Start;

            doc = pos.BeginUpdateDocument();
            Paragraph paragraph = doc.Paragraphs.Get(pos);
            DocumentPosition newPos = doc.CreatePosition(paragraph.Range.End.ToInt() - 1);
            StringBuilder insertString = new StringBuilder("Документы зарегестрированные за ");
            insertString.Append(date.ToShortDateString());

            doc.InsertText(newPos, insertString.ToString());
            ParagraphProperties pp_HeadingGrif = doc.BeginUpdateParagraphs(paragraph.Range);
            pp_HeadingGrif.Alignment = ParagraphAlignment.Center;
            newPos = doc.CreatePosition(paragraph.Range.End.ToInt());
            doc.InsertText(newPos, " ");
            doc.EndUpdateParagraphs(pp_HeadingGrif);
            pos.EndUpdateDocument(doc);

            doc.BeginUpdate();
            Table table = doc.Tables.Create(doc.CreatePosition(paragraph.Range.End.ToInt()), 1, 7, AutoFitBehaviorType.AutoFitToWindow);

            try
            {
                table.BeginUpdate();


                doc.InsertSingleLineText(table[0, 0].Range.Start, "Входящий номер");
                ParagraphProperties pp_HeadingRegPP = doc.BeginUpdateParagraphs(table[0, 0].Range);
                pp_HeadingRegPP.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingRegPP);

                doc.InsertSingleLineText(table[0, 1].Range.Start, "Дата документа(дела)");
                ParagraphProperties pp_HeadingRegNumber = doc.BeginUpdateParagraphs(table[0, 1].Range);
                pp_HeadingRegNumber.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingRegNumber);

                doc.InsertSingleLineText(table[0, 2].Range.Start, "Регистрационный номер, дата документа(дела)");
                ParagraphProperties pp_HeadingView = doc.BeginUpdateParagraphs(table[0, 2].Range);
                pp_HeadingView.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingView);

                doc.InsertSingleLineText(table[0, 3].Range.Start, "Вид и краткое содержание");
                ParagraphProperties pp_HeadingEkz = doc.BeginUpdateParagraphs(table[0, 3].Range);
                pp_HeadingEkz.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingEkz);

                doc.InsertSingleLineText(table[0, 4].Range.Start, "Экземпляр, приложение");
                ParagraphProperties pp_HeadingList = doc.BeginUpdateParagraphs(table[0, 4].Range);
                pp_HeadingList.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingList);

                doc.InsertSingleLineText(table[0, 5].Range.Start, "Исполнитель");
                ParagraphProperties pp_HeadingIsp = doc.BeginUpdateParagraphs(table[0, 5].Range);
                pp_HeadingIsp.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingIsp);

                doc.InsertSingleLineText(table[0, 6].Range.Start, "Подпись,Дата");
                ParagraphProperties pp_Heading = doc.BeginUpdateParagraphs(table[0, 6].Range);
                pp_Heading.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_Heading);

                table.RightPadding = Units.InchesToDocumentsF(0.08f);
                table.LeftPadding = Units.InchesToDocumentsF(0.08f);

                //table.TableLayout = DevExpress.XtraRichEdit.API.Native.TableLayoutType.Autofit;\
                //table.ForEachRow((row, rowIndex) => { row.Height = Units.InchesToDocumentsF(1.65f); });
                table.ForEachCell(((cell, rowIndex, cellIndex) => { cell.PreferredWidthType = WidthType.Auto; }));


            }
            finally
            {

                table.EndUpdate();
            }
            int i = 0;
            try
            {
                table.BeginUpdate();
                foreach (var dbdoc in dbdocs)
                {
                    i++;
                    TableRow row = table.Rows.Append();
                    if (i <= 5)
                    {
                        row.HeightType = HeightType.Exact;
                        row.Height = 500F;
                    }
                    else
                    {

                        NativeSectionPage page =
                            (DevExpress.XtraRichEdit.API.Native.Implementation.NativeSectionPage)
                                richEditControl1.Document.Sections[0].Page;
                        float HeightPage = page.Height;
                        row.HeightType = HeightType.Exact;
                        row.Height = (HeightPage / 6) + 10F;
                    }
                    TableCell cell = row.FirstCell;

                    MyData.Документы docДокументы = MyData.StaticMembers.dc.Документыs.Where(p => p.id_документа == dbdoc).FirstOrDefault();
                    doc.InsertSingleLineText(cell.Range.Start, docДокументы.ПолныйВходящийНомер);
                    doc.InsertSingleLineText(cell.Next.Range.Start, docДокументы.ДатаРегистрации.Value.ToShortDateString());
                    doc.InsertSingleLineText(cell.Next.Next.Range.Start, docДокументы.РегНомер + "\v" + docДокументы.ДатаПодписи.Value.ToShortDateString() + "\v" + docДокументы.Подразделения);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Range.Start, docДокументы.НазваниеДокумента);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Next.Range.Start, docДокументы.КоличествоЛистовЭкзепляра + "\v" + docДокументы.НомераПриложений);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Next.Next.Range.Start, docДокументы.КомуАдресован.КомуАдресован1);
                }
            }
            finally
            {
                table.EndUpdate();
            }
            doc.EndUpdate();

        }

        private void CreateTableDebtors(List<long> dbdocs, string detors)
        {

            SubDocument doc = richEditControl1.Document;
            DocumentPosition pos = doc.Range.Start;

            doc = pos.BeginUpdateDocument();
            Paragraph paragraph = doc.Paragraphs.Get(pos);
            DocumentPosition newPos = doc.CreatePosition(paragraph.Range.End.ToInt() - 1);
            StringBuilder insertString = new StringBuilder("Документы переданные в работу ");
            insertString.Append(detors);

            doc.InsertText(newPos, insertString.ToString());
            ParagraphProperties pp_HeadingGrif = doc.BeginUpdateParagraphs(paragraph.Range);
            pp_HeadingGrif.Alignment = ParagraphAlignment.Center;
            newPos = doc.CreatePosition(paragraph.Range.End.ToInt());
            doc.InsertText(newPos, "\v ");
            doc.EndUpdateParagraphs(pp_HeadingGrif);
            pos.EndUpdateDocument(doc);

            doc.BeginUpdate();
            Table table = doc.Tables.Create(doc.CreatePosition(paragraph.Range.End.ToInt()), 1, 7, AutoFitBehaviorType.AutoFitToWindow);
            try
            {
                table.BeginUpdate();
                //CharacterProperties cp_table = doc.BeginUpdateCharacters(table.Range);
                //cp_table.FontSize = 10;
                //cp_table.FontName = "TimesNewRoman";
                doc.InsertSingleLineText(table[0, 0].Range.Start, "п/п");
                ParagraphProperties pp_HeadingReg = doc.BeginUpdateParagraphs(table[0, 0].Range);
                pp_HeadingReg.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingReg);


                doc.InsertSingleLineText(table[0, 1].Range.Start, "Гриф");
                ParagraphProperties pp_HeadingRegPP = doc.BeginUpdateParagraphs(table[0, 0].Range);
                pp_HeadingRegPP.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingRegPP);

                doc.InsertSingleLineText(table[0, 2].Range.Start, "Вх.номер\vДата рег.\vРег.номер\vДата подписи\vОткуда");
                ParagraphProperties pp_HeadingRegNumber = doc.BeginUpdateParagraphs(table[0, 1].Range);
                pp_HeadingRegNumber.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingRegNumber);

                doc.InsertSingleLineText(table[0, 3].Range.Start, "Вид и содержание\vдокумента");
                ParagraphProperties pp_HeadingView = doc.BeginUpdateParagraphs(table[0, 2].Range);
                pp_HeadingView.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingView);

                doc.InsertSingleLineText(table[0, 4].Range.Start, "Исполнитель\vпроложение");
                ParagraphProperties pp_HeadingEkz = doc.BeginUpdateParagraphs(table[0, 3].Range);
                pp_HeadingEkz.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingEkz);

                doc.InsertSingleLineText(table[0, 5].Range.Start, "Экз/лист\v Дата контроля");
                ParagraphProperties pp_HeadingList = doc.BeginUpdateParagraphs(table[0, 4].Range);
                pp_HeadingList.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_HeadingList);

                doc.InsertSingleLineText(table[0, 6].Range.Start, "Примечание");
                ParagraphProperties pp_Heading = doc.BeginUpdateParagraphs(table[0, 5].Range);
                pp_Heading.Alignment = ParagraphAlignment.Center;
                doc.EndUpdateParagraphs(pp_Heading);

                table.RightPadding = Units.InchesToDocumentsF(0.08f);
                table.LeftPadding = Units.InchesToDocumentsF(0.08f);

                table.TableLayout = DevExpress.XtraRichEdit.API.Native.TableLayoutType.Autofit;
                table.ForEachCell(((cell, rowIndex, cellIndex) => { cell.PreferredWidthType = WidthType.Auto; }));

            }
            finally
            {

                table.EndUpdate();
            }
            int i = 0;
            try
            {
                table.BeginUpdate();
                foreach (var dbdoc in dbdocs)
                {
                    i++;
                    TableRow row = table.Rows.Append();
                    TableCell cell = row.FirstCell;
                    MyData.Документы docДокументы =
                        MyData.StaticMembers.dc.Документыs.Where(p => p.id_документа == dbdoc).FirstOrDefault();

                    string val = "";
                    if (docДокументы.ДатаПодписи.HasValue)
                    {
                        val = docДокументы.ДатаПодписи.Value.ToShortDateString();
                    }
                    string val2 = "";
                    if (docДокументы.ДатаКонтроля.HasValue)
                    {
                        val2 = docДокументы.ДатаКонтроля.Value.ToShortDateString();
                    }
                    doc.InsertSingleLineText(cell.Range.Start, i.ToString());
                    doc.InsertSingleLineText(cell.Next.Range.Start, docДокументы.Грифы.Гриф);
                    doc.InsertSingleLineText(cell.Next.Next.Range.Start, docДокументы.ВходящийНомер + "\v" + docДокументы.ДатаРегистрации.Value.ToShortDateString() + "\v" + docДокументы.РегНомер + "\v " + val + "\v" + docДокументы.Подразделения);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Range.Start, docДокументы.НазваниеДокумента);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Next.Range.Start, docДокументы.КомуАдресован.КомуАдресован1 + "\v " + docДокументы.НомераПриложений);
                    doc.InsertSingleLineText(cell.Next.Next.Next.Next.Next.Range.Start, docДокументы.КоличествоЛистовЭкзепляра + "/" + docДокументы.КоличествоЛистовЭкзепляра + "\v " + val2);
                }
            }
            finally
            {
                table.EndUpdate();
            }
            doc.EndUpdate();

        }

    }
}