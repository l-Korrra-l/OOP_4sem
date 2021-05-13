using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.Lb05
{
    [Serializable]
    class Libs
    {
        public List<Library> libs = new List<Library>();
        public Libs()
        {

        }
        public void RestoreState(Memento memento)
        {
            libs = memento.libList;
        }
        public Memento SaveState()
        {
            return new Memento(libs);
        }
    }
}
