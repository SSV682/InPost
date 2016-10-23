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
    public partial class AddValueDictionary : XtraForm
    {
        public delegate void UpdateBS();
        public virtual event UpdateBS UpdateBsForDistionery;

        private string AddingValue
        {
            get { return te_value.Text; }
        }
        private string Prefix
        {
            get { return te_prefix.Text; }
        }
        private string Index
        {
            get { return te_index.Text; }
        }
        private TypeValueDictionary _typeValueDictionary { get; set; }
        public int IdInsertingValue
        {
            get { return _idInsertingValue; }
            set { _idInsertingValue = value; }
        }
        private int _idInsertingValue;

        public AddValueDictionary( TypeValueDictionary typeValueDictionary)
        {
            InitializeComponent();
            _typeValueDictionary = typeValueDictionary;
            SetSettings();
        }
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            SaveChange();
            Close();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SaveChange()
        {
            if (_typeValueDictionary == TypeValueDictionary.From)
            {
                var unit = new Подразделения {НазваниеПодразделения = AddingValue, Индекс = Index, Префикс = Prefix,Удален = false};
                GlobalClass.Dc.Подразделенияs.InsertOnSubmit(unit);
                _idInsertingValue = unit.id_подразделения;
            }
            if (_typeValueDictionary == TypeValueDictionary.Where)
            {
                var unit = new КомуАдресован {КомуАдресован1 = AddingValue,Удален = false};
                GlobalClass.Dc.КомуАдресованs.InsertOnSubmit(unit);
                _idInsertingValue = unit.id_получателя;
            }
            if (_typeValueDictionary == TypeValueDictionary.View)
            {
                var view = new ВидДокумента {Вид = AddingValue};
                GlobalClass.Dc.ВидДокументаs.InsertOnSubmit(view);
                _idInsertingValue = view.id_видДокумента;
            }
            if (_typeValueDictionary == TypeValueDictionary.Executor)
            {
                var executor = new Исполнители {Исполнитель = AddingValue,Удален = false};
                GlobalClass.Dc.Исполнителиs.InsertOnSubmit(executor);
                _idInsertingValue = executor.id_исполнителя;
            }
            GlobalClass.Dc.SubmitChanges();
            if (UpdateBsForDistionery != null) {UpdateBsForDistionery();}
        }
        private void SetSettings()
        {
            if (_typeValueDictionary != TypeValueDictionary.From)
            {
                te_index.Enabled = false;
                te_prefix.Enabled = false;
            }
        }
        public enum TypeValueDictionary
        {
            From,Where,View,Executor
        }


        public void InsertValueinDictionary() { var dr = ShowDialog(); }

       
    }
}