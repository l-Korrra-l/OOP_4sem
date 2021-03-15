using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    [Serializable]
    public class Book
    {
        public int UDK { get; set; }
        public int size { get; set; }
        public int year { get; set; }
        public string numb { get; set; }
        public string publisher { get; set; }
        public string name { get; set; }
        public string auth { get; set; }
        public string format { get; set; }
        public DateTime date { get; set; }
        public string result { get
            {
                return UDK +" - " +auth+": "+name+", "+ year+ "\n"+publisher+format+"  "+date+"\nsize:"+size+" ("+numb+")" ;
            } set { } }
    }
}
