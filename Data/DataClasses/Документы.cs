using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using Data.Classes;


namespace Data
{
    public partial class Документы
    {
        public string Meстоположение
        {
            get
            {
                return GlobalClass.Dc.GetLocation(this._id_документа).Select(p => p.Местонахождения).FirstOrDefault();
            }
        }

        public string Исполнитель
        {
            //get { return GlobalClass.Dc.GetExecutor(this._id_документа).Select(p=>p.Исполнитель).FirstOrDefault(); }
            get { return ""; }
        }

        public bool InAct { get; set; }

        public List<StringsF4> содержаниеКарточки = new List<StringsF4>();

        public List<StringsF4> СодержаниеКарточки
        {
            get { return содержаниеКарточки; }
            set { содержаниеКарточки = value; }
        }
        public int НомерЭкземпляраКарточки = 0;
        public int НомерПродолжения = 0;

        public string НомерПродолженияПечатаемый
        {
            get { return (НомерПродолжения == 0 ? "" : "Продолжение " + НомерПродолжения.ToString(CultureInfo.InvariantCulture)); }
        }

        public string ЗаголовокРегНомера
        {
            get { return НомерЭкземпляраКарточки < 2 ? "Рег. номер" : "Рег. номер (Экз. № " + НомерЭкземпляраКарточки.ToString(CultureInfo.InvariantCulture) + ")"; }
        }

        public void Init()
        {
            ДатаРегистрации = DateTime.Today.Date;
            //ВходящийНомер = ConnectionSettings.dc.ПолучитьВходящийНомер();
        }

        public Документы Copy()
        {
            var other = new Документы {id_грифа = this.id_грифа, РегНомер = this.РегНомер, ВходящийНомер = this.ВходящийНомер, id_виддокумента = this.id_виддокумента, id_подразделения = this._id_подразделения, id_получателя = this._id_получателя, id_пользователя = this._id_пользователя, ДатаРегистрации = this.ДатаРегистрации, ДатаКонтроля = this.ДатаКонтроля, ДатаПодписи = this.ДатаПодписи, ПолныйВходящийНомер = this.ПолныйВходящийНомер, ПризнакПечати = false, НазваниеПриложения = this.НазваниеПриложения, НомерЭкземпляра = this.НомерЭкземпляра, КоличествоЛистовЭкзепляра = this.КоличествоЛистовЭкзепляра, КоличествоЛистовПриложения = this.КоличествоЛистовПриложения, КомментарийКому = this.КомментарийКому, КомментарийОткуда = this.КомментарийОткуда, Вернуть = this.Вернуть, ДатаВозврата = this.ДатаВозврата};
            return other;
        }

        public string ПолныйРегистрационныйНомер
        {
            get { return this.РегНомер + "   экз. № "+ this.НомерЭкземпляра; }
        }
    }
}
