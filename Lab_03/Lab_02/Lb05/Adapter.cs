using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.Lb05
{
    public interface ITarget
    {
        string StartWriting();
    }
    class Adapter : ITarget
    {
        private readonly Author auth;
        public Adapter(Author author)
        {
            this.auth = author;
        }
        public string StartWriting()
        {
            return $"{this.auth.FIO} says: {this.auth.Write()}";
        }

    }
}
