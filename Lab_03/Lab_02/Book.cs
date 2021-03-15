using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab_02
{
    [Serializable]
    sealed public class Ident: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null && Int32.Parse(value.ToString()) <= 999999 && Int32.Parse(value.ToString()) >= 100)
                return true;
            else
            {
                this.ErrorMessage="Неверный формат УДК";
                return false;
            }
        }
    }
    public class Book
    {

        public Book()
        {
        }

        public Book(AbstractFactory fact)
        {
           format= fact.SetType().format;
        }
        [Required]
        [Ident]
        public int UDK { get; set; }
        [Required]
        public int size { get; set; }
        [Required]
        [Range(1899,2021)]
        public int year { get; set; }
        [Required]
        public string numb { get; set; }
        [Required]
        [StringLength(15, MinimumLength =3)]
        public string publisher { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string auth { get; set; }
        [Required]
        public string format { get; set; }
        [Required]
        public DateTime date { get; set; }
        public string result { get
            {
                return $"{UDK} - {auth}: {name}, {year}\n{publisher+format}  {date}\nsize:{size} ({numb})" ;
            } set { } }
    }
}
