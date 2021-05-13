using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Lab_10
{
    public class AuthContext : DbContext
    {

        public DbSet<Author> Authors { get; set; }

        public AuthContext() : base("DefaultConnection")
        {
        }
    }
}
