using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyStart.Формы
{
    public partial class ФормаДопечатывания : DevExpress.XtraEditors.XtraForm
    {
        public СтруктураДопечатывания структураДопечатывания = new СтруктураДопечатывания();
        public ФормаДопечатывания()
        {
            InitializeComponent();
        }

        public СтруктураДопечатывания ОткрытьДиалог()
        {
            DialogResult dr = ShowDialog();
            return структураДопечатывания;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            структураДопечатывания.ДатаПодписи = checkEdit6.Checked;
            структураДопечатывания.НомерЭкземпляра = checkEdit1.Checked;
            структураДопечатывания.ЛистовЭкземпляра = checkEdit2.Checked;
            структураДопечатывания.Приложения = checkEdit3.Checked;
            структураДопечатывания.Содержание = checkEdit5.Checked;
            Close();
        }
    }

    public struct СтруктураДопечатывания
    {
        public bool ДатаПодписи;
        public bool НомерЭкземпляра;
        public bool ЛистовЭкземпляра;
        public bool Приложения;
        public bool Содержание;
    }
}