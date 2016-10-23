using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Data;
using DevExpress.CodeParser;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraEditors;

namespace Входящие.Forms
{
    public partial class ReRegistration : DevExpress.XtraEditors.XtraForm
    {

        public int Year
        {
            get { return int.Parse(te_Year.Text); }
            set { te_Year.Text = value.ToString(CultureInfo.InvariantCulture); }
        }
        public int YearLimited { get; set; }
        private BindingSource Bs { get; set; }
        public Документы Document { get; set; }

        private string incNumber
        {
            get { return te_IncNumber.Text; }
            set { te_IncNumber.Text = value; }
        }

        public ReRegistration(int yearLimited)
        {
            InitializeComponent();
            Year = GlobalClass.YearSearch;
            YearLimited = yearLimited;

        }

        private void te_Year_EditValueChanged(object sender, EventArgs e)
        {
            if (YearLimited <= Year)
            {
                var docss = Data.DataMethods.DataMethods.GetDocumentsByDetails(Year);
                Bs = new BindingSource();
                foreach (var doc in docss) { Bs.Add(doc); }
                grid_docs.DataSource = Bs;
            }
            else
            {
                XtraMessageBox.Show(@"Вы пытаетесь перерегистрировать на более ранний документ.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void te_IncNumber_EditValueChanged(object sender, EventArgs e)
        {
            var docss = Data.DataMethods.DataMethods.GetDocumentsByDetails(Year, null, null, null, incNumber);
            Bs = new BindingSource();
            foreach (var doc in docss) {Bs.Add(doc);}
            grid_docs.DataSource = Bs;
        }

        private void grid_docs_DoubleClick(object sender, EventArgs e)
        {
            Document = (Документы)Bs.Current; 
            Close();
        }


        public Документы OpenDialog()
        {
            var dr = ShowDialog();
            return Document;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (Bs.Count == 1) {Document = (Документы)Bs[0];Close();}
            else {XtraMessageBox.Show(@"Вы не выбрали новый документ.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);}
        }

        private void bbi_createNewDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
       
    }
}