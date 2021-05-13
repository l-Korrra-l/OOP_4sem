using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    public class Memento
    {
        public List<Prod> prodList = new List<Prod>();
        public Memento(List<Prod> state)
        {
            if (state != null)
            {
                foreach (Prod i in state)
                {
                    this.prodList.Add(i);
                }
            }
            else if (state == null)
                this.prodList.Clear();
        }
    }
    public class Caretaker
    {
        public Stack<Memento> History { get; private set; }
        public Caretaker()
        {
            History = new Stack<Memento>();
        }
    }
}
