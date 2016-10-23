using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Data.DataMethods
{
    public class DataMethods
    {
        public static List<Документы> GetDocumentsByDetails(int year, string contents=null, string nameOfTheUnit=null,string regNumber=null,string incommingNumber=null, string dateReg=null, string datePod=null)
        {
            var searchQuery = new StringBuilder("SELECT distinct d.* FROM dbo.Документы as d ");
            if (!string.IsNullOrEmpty(contents)) 
            {
                searchQuery.Append(" Join  dbo.ВидИКраткоеСодержание as v  ON d.id_документа=v.id_документа WHERE YEAR(d.ДатаРегистрации)=" + year);
                searchQuery.Append(" AND Contains(v.Текст,'" + contents + "') ");
            }
            else
            {
                searchQuery.Append(" WHERE YEAR(d.ДатаРегистрации)=" + year);
            }
            if (!string.IsNullOrEmpty(nameOfTheUnit))
            {
                int idUnit = GlobalClass.Dc.Подразделенияs.Where(p => p.НазваниеПодразделения == nameOfTheUnit).Select(q => q.id_подразделения).FirstOrDefault();
                searchQuery.Append(" AND d.id_подразделения = " + idUnit);
            }
            if (!string.IsNullOrEmpty(regNumber)){searchQuery.Append(" AND d.РегНомер='" +regNumber + "'");}
            if (!string.IsNullOrEmpty(incommingNumber)){searchQuery.Append(" AND d.ВходящийНомер = " + incommingNumber);}
            if (dateReg != null){searchQuery.Append(" AND d.ДатаРегистрации = CONVERT(datetime, '" + dateReg + "',104)");}
            if (datePod != null){searchQuery.Append(" AND d.ДатаКонтроля = CONVERT(datetime, '" + datePod + "',104)");}
            var documents = GlobalClass.Dc.ExecuteQuery<Документы>(searchQuery.ToString()).ToList();

            if(documents.Any())return documents;
            else
            {
                searchQuery = new StringBuilder("SELECT distinct d.* FROM dbo.Документы as d ");
                if (!string.IsNullOrEmpty(contents))
                {
                    searchQuery.Append(" Join  dbo.ВидИКраткоеСодержание as v  ON d.id_документа=v.id_документа WHERE YEAR(d.ДатаРегистрации)=" + year);
                    searchQuery.Append(" AND Contains(v.Текст,'" + contents + "') ");
                }
                else
                {
                    searchQuery.Append(" WHERE YEAR(d.ДатаРегистрации)=" + year);
                }
                if (!string.IsNullOrEmpty(nameOfTheUnit))
                {
                    int idUniti = GlobalClass.Dc.Подразделенияs.Where(p => p.НазваниеПодразделения != null && p.НазваниеПодразделения == nameOfTheUnit).Select(q => q.id_подразделения).FirstOrDefault();
                    searchQuery.Append(" AND d.id_подразделения = " + idUniti);
                }
                if (!string.IsNullOrEmpty(regNumber)) { searchQuery.Append(" AND d.РегНомер='" + regNumber + "'"); }
                if (!string.IsNullOrEmpty(incommingNumber)) { searchQuery.Append(" AND d.ПолныйВходящийНомер = '" + incommingNumber+"'") ; }
                if (dateReg != null) { searchQuery.Append(" AND d.ДатаРегистрации = CONVERT(datetime, '" + dateReg + "',104)"); }
                if (datePod != null) { searchQuery.Append(" AND d.ДатаКонтроля = CONVERT(datetime, '" + datePod + "',104)"); }
                documents = GlobalClass.Dc.ExecuteQuery<Документы>(searchQuery.ToString()).ToList();
                return documents;
            }


            
        }
    }
}


