using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_06
{
    /// <summary>
    /// Логика взаимодействия для SelControl.xaml
    /// </summary>
    public partial class SelControl : UserControl
    {
        List<Prod> li = new List<Prod>();
        public SelControl(Prod item)
        {
            InitializeComponent();
            li.Add(item);
            partList.ItemsSource = li;
        }

    }
}
