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
    public partial class RangeOfNumbers : DevExpress.XtraEditors.XtraForm
    {
        private int _numFrom;
        public int NumFrom
        {
            get { return (int)ce_from.Value; }
            set
            {
                _numFrom = value;
                ce_from.Value = _numFrom;
            }
        }

        private int _numTo;
        public int NumTo
        {
            get { return (int)ce_to.Value; }
            set
            {
                _numTo = value;
                ce_to.Value = _numTo;
            }
        }

        public RangeOfNumbers(int numFrom,int numTo)
        {
            InitializeComponent();
            this.NumFrom = numFrom;
            this.NumTo = numTo;
            
        }
        public RangeOfNumbers(){InitializeComponent();}

        private void ce_to_EditValueChanged(object sender, EventArgs e)
        {
            if (NumTo < NumFrom){btn_Ok.Enabled = false;}
            else{ btn_Ok.Enabled = true;}

            if (NumFrom == 0 || NumTo == 0){btn_Ok.Enabled = false;}
        }

        private void btn_Ok_Click(object sender, EventArgs e){Close();}

        public List<int> OpenDialog()
        {
            ShowDialog();
            var range = new List<int> {NumFrom, NumTo};
            return range;
        }
    }
}