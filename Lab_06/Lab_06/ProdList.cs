using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    public class ProdList
    {
        public List<Prod> li = new List<Prod>();
        public ProdList()
        { 
        }

        public void RestoreState(Memento memento)
        {
            li = memento.prodList;
        }
        public Memento SaveState()
        {
            return new Memento(li);
        }
    }
}
