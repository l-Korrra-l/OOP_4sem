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
using System.Windows.Shapes;

namespace Lab_06
{
    /// <summary>
    /// Логика взаимодействия для Full.xaml
    /// </summary>
    public partial class Full : Window
    {
        public Full(Prod item)
        {
            InitializeComponent();
            GridPrin.Children.Add(new SelControl(item));
        }

        private void ExitMain_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
