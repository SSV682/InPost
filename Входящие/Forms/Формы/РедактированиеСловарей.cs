using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using формаФ4;

namespace MyStart.Формы
{
    public partial class РедактированиеСловарей : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bs5 = new BindingSource();
        BindingSource bs6= new BindingSource();
        BindingSource bs7 = new BindingSource();
        public РедактированиеСловарей()
        { 
           InitializeComponent();
           ОбновлениеСловарей();
           
        }

        private void РедактированиеСловарей_Load(object sender, EventArgs e)
        {
            this.видДокументаTableAdapter.Fill(this.inPostDataSet.ВидДокумента);


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.bs5.Current == null) return;
            MyData.Подразделения подразделения = (MyData.Подразделения)bs5.Current;
            IQueryable<MyData.Документы> документыs =
                MyData.StaticMembers.dc.Документыs.Where(p => p.Подразделения == подразделения);
            if (документыs.Count() != 0)
            {
                MessageBox.Show("Невозможно удалить, так как за отправителем числятся документы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Удалить отправителя?", "Удаление", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    MyData.StaticMembers.dc.Подразделенияs.DeleteOnSubmit((MyData.Подразделения)bs5.Current);
                    bs5.RemoveCurrent();
                    MyData.StaticMembers.dc.SubmitChanges();
                }
            }
        }

        private void ОбновлениеСловарей()
        {   
            bs7.Clear();
            bs5.Clear();
            bs6.Clear();
            //bs5.DataSource = MyData.StaticMembers.dc.Подразделенияs;
            //bs6.DataSource = MyData.StaticMembers.dc.КомуАдресованs;
            //bs7.DataSource = MyData.StaticMembers.dc.ЧастыеРезолюцииs;

            IQueryable<MyData.Подразделения> pods = MyData.StaticMembers.dc.Подразделенияs;
            foreach (var pod in pods)
            {
                bs5.Add(pod);
            }

            IQueryable<MyData.КомуАдресован> adrs = MyData.StaticMembers.dc.КомуАдресованs;
            foreach (var adr in adrs)
            {
                bs6.Add(adr);
            }

            IQueryable<MyData.ВидДокумента> vids = MyData.StaticMembers.dc.ВидДокументаs;
            foreach (var vid in vids)
            {
                bs7.Add(vid);
            }

           

            this.gridControl1.DataSource = bs5;  
            this.gridControl2.DataSource = bs6;
            this.gridControl3.DataSource = bs7;

        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.bs6.Current == null) return;
            MyData.КомуАдресован получатель = (MyData.КомуАдресован)bs6.Current;
            IQueryable<MyData.Документы> документыs =
                MyData.StaticMembers.dc.Документыs.Where(p => p.КомуАдресован == получатель);
            if (документыs.Count() != 0)
            {
                MessageBox.Show("Невозможно удалить, так как за адресатом числятся документы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Удалить адресата?", "Удаление", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    MyData.StaticMembers.dc.КомуАдресованs.DeleteOnSubmit((MyData.КомуАдресован)bs6.Current);
                    bs6.RemoveCurrent();
                    MyData.StaticMembers.dc.SubmitChanges();
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            РедактированиеСловарей_Добавление_ frm = new РедактированиеСловарей_Добавление_(ТипДобавленияВСловарь.CПараметром);
            MyData.Подразделения dv = frm.ДобавитьПодразделения();
            if (dv != null)
            {
                MyData.StaticMembers.dc.Подразделенияs.InsertOnSubmit(dv);
                MyData.StaticMembers.dc.SubmitChanges();
                ОбновлениеСловарей();
            }
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            РедактированиеСловарей_Добавление_ frm = new РедактированиеСловарей_Добавление_(ТипДобавленияВСловарь.БезПараметра);
            MyData.КомуАдресован dv = frm.ДобавитьКомуАдресован();
            if (dv != null)
            {
                MyData.StaticMembers.dc.КомуАдресованs.InsertOnSubmit(dv);
                MyData.StaticMembers.dc.SubmitChanges();
                ОбновлениеСловарей();
            }
        }

        private void добавитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            РедактированиеСловарей_Добавление_ frm = new РедактированиеСловарей_Добавление_(ТипДобавленияВСловарь.БезПараметра);
            MyData.ВидДокумента dv = frm.ДобавитьВидДокумента();
            if (dv != null)
            {
                MyData.StaticMembers.dc.ВидДокументаs.InsertOnSubmit(dv);
                MyData.StaticMembers.dc.SubmitChanges();
                ОбновлениеСловарей();
            }
        }

        private void удалитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.bs7.Current == null) return;
            MyData.ВидДокумента вид = (MyData.ВидДокумента)bs7.Current;
            IQueryable<MyData.Документы> документыs =
                MyData.StaticMembers.dc.Документыs.Where(p => p.ВидДокумента == вид);
            if (документыs.Count() != 0)
            {
                MessageBox.Show("Невозможно удалить, так как документы такого вида зарегестрированы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Удалить вид документа?", "Удаление", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    MyData.StaticMembers.dc.ВидДокументаs.DeleteOnSubmit((MyData.ВидДокумента)bs7.Current);
                    bs7.RemoveCurrent();
                    MyData.StaticMembers.dc.SubmitChanges();
                }
            }
        }
    }
}