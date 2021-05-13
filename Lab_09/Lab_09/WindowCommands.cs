using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_09
{
    class WindowCommands
    {
        static WindowCommands()
        {
            Exit = new RoutedUICommand("Close the window","Exit", typeof(MainWindow));
        }
        public static RoutedUICommand Exit { get; set; }
    }
}
