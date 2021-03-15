using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{ 
    [Serializable]
    public class Author
    {

            public string FIO;
            public string country;
            public int age;
            public int id;
            public string Write()
            {
                return "I`am writing, because i have to do it";
            }

        public override string ToString()
        {
            return $"{id}: {FIO}, {age}, {country}";
        }
    }
}
