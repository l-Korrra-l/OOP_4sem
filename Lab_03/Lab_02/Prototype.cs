using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    public class Prototype
    {
        public interface IClone
        {
            IClone Clone();
        }
    }
}
