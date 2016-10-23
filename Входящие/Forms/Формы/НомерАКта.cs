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
    public partial class НомерАКта : DevExpress.XtraEditors.XtraForm
    {

        private string НомерАкта;
        public НомерАКта()
        {
            InitializeComponent();
        }


        public string ОткрытьДиалог()
        {
            DialogResult dr = ShowDialog();
            НомерАкта = textEdit1.Text;
            if (string.IsNullOrEmpty(НомерАкта))
            {
                MessageBox.Show("Вы не ввели номер акта!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            return НомерАкта;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}