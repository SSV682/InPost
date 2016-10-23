using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Data;
using DevExpress.XtraEditors;
using Входящие.Classes;

namespace Входящие.Forms
{
    public partial class LimitedSettingsForm : DevExpress.XtraEditors.XtraForm
    {


        public bool ShowClosing
        {
            get { return ts_ShowClosing.IsOn; }
            set { this.ts_ShowClosing.IsOn = value; }
        }
        public bool ShowWorking
        {
            get { return ts_ShowWorking.IsOn; }
            set { this.ts_ShowWorking.IsOn = value; }
        }

        public int TimePeriodDowload
        {
            get { return (int)ceTimePeriod.Value; }
            set { ceTimePeriod.Value = value; }
        }

        public LimitedSettingsForm()
        {
            InitializeComponent();
            InitSettings();
        }

        private void InitSettings() 
        {
            TimePeriodDowload = GlobalClass.TimePeriodDowload;
            ShowClosing = GlobalClass.ShowClosing;
            ShowWorking = GlobalClass.ShowWorking;
        }


        private void SetSettingsInGlobalClass()
        {
            GlobalClass.ShowClosing = ShowClosing;
            GlobalClass.ShowWorking = ShowWorking;
            GlobalClass.TimePeriodDowload = TimePeriodDowload;
        }

        private void SaveSettings()
        {
            Methods.StoreValueInConfig("Врменной_интервал_загрузки_документов", GlobalClass.TimePeriodDowload);
            Methods.StoreValueInConfig("Показывать_рабочие_документы", GlobalClass.ShowWorking);
            Methods.StoreValueInConfig("Показывать_закрытые_документы", GlobalClass.ShowClosing);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            SetSettingsInGlobalClass();
            SaveSettings();
            Close();
        
        }

    }
}