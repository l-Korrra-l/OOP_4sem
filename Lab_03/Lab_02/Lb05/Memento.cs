using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.Lb05
{
    public class Memento
    {
        public List<Library> libList = new List<Library>();
        public Memento(List<Library> state)
        {
            if (state != null)
            {
                foreach (Library i in state)
                {
                    this.libList.Add(i);
                }
            }
            else if (state == null)
                this.libList.Clear();
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
