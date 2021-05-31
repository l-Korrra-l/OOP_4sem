using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using L11.Models;

namespace L11.Context
{

    public class MyDb : DbContext
    {
        public MyDb() : base("name=DBConnection") { }


        public DbSet<Worker> Worker { get; set; }
        public DbSet<Plane> Plane { get; set; }
    }
}
