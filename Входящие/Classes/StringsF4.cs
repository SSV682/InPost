using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Входящие.Classes
{
    public class StringsF4
    {
        public int номерСтроки;
        public int НомерСтроки
        {
            get { return номерСтроки; }
            set {номерСтроки = value;}
        }
        
        public string текст;
        public string Текст
        {
            get { return текст; }
            set {текст = value;}
        }

        public bool признакПечати;
        public bool ПризнакПечати
        {
            get { return признакПечати; }
            set {признакПечати = value;}
        }
    }
}
