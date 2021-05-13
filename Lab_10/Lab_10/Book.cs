using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lab_10
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }

        public Book() { }
        public Book(int id, string name, int authid)
        {
            this.Id = id;
            this.Name = name;
            this.AuthorId = authid;
        }
    }
}
