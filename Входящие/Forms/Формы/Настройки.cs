using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Model;
using MyData;

namespace MyStart.Формы
{
    public partial class Настройки : DevExpress.XtraEditors.XtraForm
    {
        public Настройки()
        {
            InitializeComponent();
            ЗагрузкаНастроек();
        }

        private void ЗагрузкаНастроек()
        {
            ИндексSwitch.IsOn = формаФ4.StaticMembers.ПоляКарточки.индекс;
            ВидДокументаSwitch.IsOn = формаФ4.StaticMembers.ПоляКарточки.видДокумента;
            ДатаКонтроляSwitch.IsOn = формаФ4.StaticMembers.ПоляКарточки.датаКонтроля;
            КомментарииSwitch.IsOn = формаФ4.StaticMembers.ПоляКарточки.комментарии;
            ЧерезГрифSwitch.IsOn = MyData.StaticMembers.формированиеВходящего;
            РезолюцииSwitch.IsOn = MyData.StaticMembers.добавлятьСтрокиВРезолюции;
            РежимПечатиSwitch.IsOn = MyData.StaticMembers.ускореныйРежим;
            ОпросSwitch.IsOn = MyData.StaticMembers.проведениеОпроса;
            ЗакрытиеПослеПечатиSwitch.IsOn = MyData.StaticMembers.ЗакрытиеФормыПослеПечати;
            ПодсвечиватьСтрокиSwitch.IsOn = MyData.StaticMembers.ВыделятьЦветом;
            Префикс.Text = MyData.StaticMembers.префикс;
            ОборотнаяСторонаSwitch.IsOn = MyData.StaticMembers.Traceback;
            РежимРаботыSwitch.IsOn = MyData.StaticMembers.ModeРаботы==РежимРаботы.Однопользовательский?true:false;
            РабочиеSwitch.IsOn = MyData.StaticMembers.показыватьРабочие;
            ЗакрытыеSwitch.IsOn = MyData.StaticMembers.показыватьЗакрытые;
            Входящийtext.Text = MyData.StaticMembers.номерВходящего.ToString();
            ГодПоискаtext.Text = MyData.StaticMembers.годПоиска.ToString();
            РежимУчетаSwitch.IsOn = MyData.StaticMembers.ModeУчета== РежимРаботыКарточногоУчета.Отслеживаемый;
            ПодсвечиватьСтрокиSwitch.IsOn = MyData.StaticMembers.ВыделятьЦветом;
            РежимПрограммыSwitch.IsOn = MyData.StaticMembers.ModeПрограммы==РежимПрограммы.Автономный;
            КолвоЭкземпляров.Text = MyData.StaticMembers.количетсвоЭкземпляров.ToString();
            ПереданныйcolorEdit.EditValue = Color.FromName(MyData.StaticMembers.ЦветПередачи);
            ЗакрытыйcolorEdit.EditValue = Color.FromName(MyData.StaticMembers.ЦветЗакрытия);
            ДобавленныйcolorEdit.EditValue = Color.FromName(MyData.StaticMembers.ЦветУдаления);



        }
        
        private void ИндексSwitch_EditValueChanged(object sender, EventArgs e)
        {
            формаФ4.StaticMembers.ПоляКарточки.индекс= ИндексSwitch.IsOn ? true : false;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["Index"];
            p.Value = ИндексSwitch.IsOn.ToString();
            config.Save();
        }

        private void ВидДокументаSwitch_EditValueChanged(object sender, EventArgs e)
        {
            формаФ4.StaticMembers.ПоляКарточки.видДокумента = ВидДокументаSwitch.IsOn ? true : false;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["DocumentType"];
            p.Value = ВидДокументаSwitch.IsOn.ToString();
            config.Save();
        }

        private void ДатаКонтроляSwitch_EditValueChanged(object sender, EventArgs e)
        {
            формаФ4.StaticMembers.ПоляКарточки.датаКонтроля = ДатаКонтроляSwitch.IsOn ? true : false;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["DateControl"];
            p.Value = ДатаКонтроляSwitch.IsOn.ToString();
            config.Save();
        }

        private void КомментарииSwitch_EditValueChanged(object sender, EventArgs e)
        {
            формаФ4.StaticMembers.ПоляКарточки.комментарии = КомментарииSwitch.IsOn ? true : false;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["comments"];
            p.Value = КомментарииSwitch.IsOn.ToString();
            config.Save();
        }

        private void ЧерезГрифSwitch_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.формированиеВходящего = ЧерезГрифSwitch.IsOn ? true : false;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["PrefGrif"];
            p.Value = ЧерезГрифSwitch.IsOn.ToString();
            config.Save();
        }

        private void РезолюцииSwitch_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.добавлятьСтрокиВРезолюции = РезолюцииSwitch.IsOn;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["AddRez"];
            p.Value = РезолюцииSwitch.IsOn.ToString();
            config.Save();
        }

        private void РежимПечатиSwitch_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.ускореныйРежим = РежимПечатиSwitch.IsOn;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["SpeedRezhim"];
            p.Value = РежимПечатиSwitch.IsOn.ToString();
            config.Save();
        }

        private void ОпросSwitch_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.проведениеОпроса = ОпросSwitch.IsOn;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["Opros"];
            p.Value = ОпросSwitch.IsOn.ToString();
            config.Save();
        }

        private void ЗакрытиеПослеПечатиSwitch_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.ЗакрытиеФормыПослеПечати = ЗакрытиеПослеПечатиSwitch.IsOn;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["CloseCardAfterPrint"];
            p.Value = ЗакрытиеПослеПечатиSwitch.IsOn.ToString();
            config.Save();
        }

        private void Префикс_EditValueChanged(object sender, EventArgs e)
        {
            if (Префикс.Text == null)
            {
                //System.Windows.Forms.MessageBox.Show("Вы ввели что-то не то. Попробуйте ещё раз!", "Ошибка", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            try
            {
                MyData.StaticMembers.префикс = Префикс.EditValue.ToString();
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
                var p = collection["Prefiks"];
                p.Value = Префикс.Text;
                config.Save();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Вы ввели что-то не то. Попробуйте ещё раз!", "Ошибка", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void ОборотнаяСторонаSwitch_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.Traceback = ОборотнаяСторонаSwitch.IsOn ? true : false;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["Traceback"];
            p.Value = ОборотнаяСторонаSwitch.IsOn.ToString();
            config.Save();
        }

        private void РежимРаботыSwitch_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.ModeРаботы = РежимРаботыSwitch.IsOn ? РежимРаботы.Многопользовательский : РежимРаботы.Однопользовательский;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["ModeWork"];
            p.Value = РежимРаботыSwitch.IsOn.ToString();
            config.Save();
        }

        private void РабочиеSwitch_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.показыватьРабочие = РабочиеSwitch.IsOn;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["TolkoRabochie"];
            p.Value = РабочиеSwitch.IsOn.ToString();
            config.Save();
        }

        private void toggleSwitch2_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.показыватьЗакрытые = ЗакрытыеSwitch.IsOn;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["OnlyClose"];
            p.Value = ЗакрытыеSwitch.IsOn.ToString();
            config.Save();
        }

        private void Входящийtext_EditValueChanged(object sender, EventArgs e)
        {
            //MyData.StaticMembers.ВходящийНомер num = MyData.StaticMembers.dc.ВходящийНомерs.Where(p => p.Год == DateTime.Today.Year).FirstOrDefault();
            //MyData.StaticMembers.dc.SubmitChanges();
        }

        private void ГодПоискаtext_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.годПоиска = int.Parse(ГодПоискаtext.EditValue.ToString());
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["GodPoiska"];
            p.Value = ГодПоискаtext.EditValue.ToString();
            config.Save();
        }

        private void СбросБлокировкиButton_Click(object sender, EventArgs e)
        {
            IQueryable<MyData.Документы> docs = MyData.StaticMembers.dc.Документыs.Where(p => p.запретИзменения);
            if (docs.Any())
            {
                foreach (var doc in docs)
                {
                    doc.запретИзменения = false;
                }
                MyData.StaticMembers.dc.SubmitChanges();
            }
            System.Windows.Forms.MessageBox.Show("Блокировка снята", "Ифнормация", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        private void СохранитьButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void РежимУчетаSwitch_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.ModeУчета = РежимУчетаSwitch.IsOn ? РежимРаботыКарточногоУчета.Отслеживаемый : РежимРаботыКарточногоУчета.Неотслеживаемый;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["ModeAccounting"];
            p.Value = РежимУчетаSwitch.IsOn.ToString();
            config.Save();
        }

        private void ПодсвечиватьСтрокиSwitch_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.наличиеПодсветкиСтрок = ПодсвечиватьСтрокиSwitch.IsOn;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["Highlight"];
            p.Value = ПодсвечиватьСтрокиSwitch.IsOn.ToString();
            config.Save();
            
        }

        private void РежимПрограммыSwitch_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.ModeПрограммы = РежимПрограммыSwitch.IsOn?РежимПрограммы.Автономный : РежимПрограммы.Серверный;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["ModeProgramm"];
            p.Value = РежимПрограммыSwitch.IsOn.ToString();
            config.Save();
        }

        private void КолвоЭкземпляров_EditValueChanged(object sender, EventArgs e)
        {
            MyData.StaticMembers.количетсвоЭкземпляров = int.Parse(КолвоЭкземпляров.EditValue.ToString());
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["Ekz"];
            p.Value = КолвоЭкземпляров.EditValue.ToString();
            config.Save();
        }

        private void ПереданныйcolorEdit_EditValueChanged(object sender, EventArgs e)
        {
            Color color = ПереданныйcolorEdit.Color;
            string ColorName3 = color.Name;
            MyData.StaticMembers.ЦветПередачи = ColorName3;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["ЦветПередачи"];
            p.Value = ColorName3;
            config.Save();
        }

        private void ЗакрытыйcolorEdit_EditValueChanged(object sender, EventArgs e)
        {
            Color color = ЗакрытыйcolorEdit.Color;
            string ColorName3 = color.Name;
            MyData.StaticMembers.ЦветЗакрытия = ColorName3;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["ЦветЗакрытия"];
            p.Value = ColorName3;
            config.Save();
        }

        private void ДобавленныйcolorEdit_EditValueChanged(object sender, EventArgs e)
        {
            Color color = ДобавленныйcolorEdit.Color;
            string ColorName3 = color.Name;
            MyData.StaticMembers.ЦветУдаления = ColorName3;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.KeyValueConfigurationCollection collection = config.AppSettings.Settings;
            var p = collection["ЦветУдаления"];
            p.Value = ColorName3;
            config.Save();
        }
    }
}