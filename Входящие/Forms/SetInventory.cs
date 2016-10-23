using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using DevExpress.XtraEditors;
using Входящие.Classes;

namespace Входящие.Forms
{
    public partial class SetInventory : DevExpress.XtraEditors.XtraForm
    {

        public string Number
        {
            get { return te_number.Text; }
            set { te_number.Text = value; }
        }
        public string Date
        {
            get { return de_date.DateTime.ToShortDateString(); }
        }
        public string Resolution { get; set; }
        public Документы Документ { get; set; }

        public SetInventory()
        {
            InitializeComponent();
            de_date.DateTime = DateTime.Today;
            
        }

        public void MakeDataInventory(Документы _документы)
        {
            Документ = _документы;
            var dr = ShowDialog();
        }

        private void SaveChanges()
        {
            Resolution = Date+" вошел в инвентарь №"+Number;
            var bindOperation = Methods.AddNewDistiny(Документ, 0, Operations.ToInventory, Resolution, DateTime.Today);
            Methods.AddNewResolution(Документ, Resolution, bindOperation);

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            SaveChanges();Close();
        }
    }
}