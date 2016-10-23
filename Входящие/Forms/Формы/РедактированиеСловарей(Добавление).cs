using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraExport;
using MyData;
using формаФ4;

namespace MyStart.Формы
{
    public partial class РедактированиеСловарей_Добавление_ : DevExpress.XtraEditors.XtraForm
    {
        //private object nv;
        public РедактированиеСловарей_Добавление_(ТипДобавленияВСловарь тип)
        {
            InitializeComponent();
            if (тип == ТипДобавленияВСловарь.БезПараметра)
            {
                textEdit2.Enabled = false;
                calcEdit1.Enabled = false;
            }

            
        }

        public MyData.Подразделения ДобавитьПодразделения()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return new Подразделения() {НазваниеПодразделения = textEdit1.Text, Индекс = calcEdit1.Text, Префикс = textEdit2.Text};
            }
            else
            {
                return null;
            }
        }


        public MyData.КомуАдресован ДобавитьКомуАдресован()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return new КомуАдресован() { КомуАдресован1 = textEdit1.Text};
            }
            else
            {
                return null;
            }
        }

        public MyData.ВидДокумента ДобавитьВидДокумента()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return new ВидДокумента() {ВидДокумента1 = textEdit1.Text};
            }
            else
            {
                return null;
            }
        }

        public MyData.ШаблоныКратСод ДобавитьШаблоныКратСод()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return new ШаблоныКратСод() { Шаблон = textEdit1.Text };
            }
            else
            {
                return null;
            }
        }

        public MyData.Исполнители ДобавитьИсполнителя()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return new Исполнители() { Исполнитель = textEdit1.Text };
            }
            else
            {
                return null;
            }
        }
       
    }


    public enum ТипДобавленияВСловарь
    {
        CПараметром,
        БезПараметра
    };
}