using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Data;
using DevExpress.XtraEditors;

namespace Входящие.InControls
{
    public partial class Destiny : DevExpress.XtraEditors.XtraUserControl
    {
        public Destiny(Документы документ)
        {
            InitializeComponent();
            grid_destiny.DataSource = документ.ЖурналОперацийs.OrderBy(p=>p.датаНачалаОперации).ThenBy(p=>p.id_записи);

        }
    }
}
