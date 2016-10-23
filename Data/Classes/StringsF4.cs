using System;
namespace Data.Classes
{
    public partial class StringsF4
    {
        public Nullable<int> номерСтроки;
        public Nullable<int> НомерСтроки
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

        public Nullable<bool> признакПечати;
        public Nullable<bool> ПризнакПечати
        {
            get { return признакПечати; }
            set {признакПечати = value;}
        }
    }
}
