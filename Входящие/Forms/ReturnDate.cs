using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Входящие.Forms
{
    public partial class ReturnDate : DevExpress.XtraEditors.XtraForm
    {
        private DateTime _date;
        public DateTime Date
        {
            get
            {
               _date = (DateTime)de_Date.EditValue;
                return _date;
            }
            set
            {
                _date = value;
                de_Date.EditValue = _date;
            }
        }

        public ReturnDate()
        {
            InitializeComponent();
        }

        public DateTime OpenDialog()
        {
            ShowDialog();
            return Date;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReturnDate_Load(object sender, EventArgs e)
        {
            Date = DateTime.Today;
        }

        
    }
}