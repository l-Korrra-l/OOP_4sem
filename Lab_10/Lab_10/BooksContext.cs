using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lab_10
{
    public class BooksContext : DbContext
    {

        public DbSet<Book> Books { get; set; }

        public BooksContext() : base("DefaultConnection")
        {
        }
    }
}
