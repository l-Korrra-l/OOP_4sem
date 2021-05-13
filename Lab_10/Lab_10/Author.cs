using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class Author
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> books = new List<Book>();

        public Author()
        { }

        public Author(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
