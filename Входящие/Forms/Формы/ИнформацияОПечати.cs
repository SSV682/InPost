using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyStart.Формы
{
    public partial class ИнформацияОПечати : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bs;
        public ИнформацияОПечати(BindingSource _bs)
        {
            InitializeComponent();
            bs = _bs;
            gridControl1.DataSource = bs;
        }
     }
}