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
using System.IO;
using System.Windows.Resources;
using System.Runtime.Serialization.Json;

namespace Lab_06
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool currentTheme = true; //def
        List<Prod> parts = new List<Prod>();
        public MainWindow()
        {
            InitializeComponent();
            GridPrincipal.Children.Add(new UControl());

            CommandBinding bindNew = new CommandBinding(ApplicationCommands.New);
            bindNew.Executed += Reduct_Click;
            this.CommandBindings.Add(bindNew);

            CommandBinding bindFind = new CommandBinding(ApplicationCommands.Find);
            bindFind.Executed += Find;
            this.CommandBindings.Add(bindFind);

    

        }

        private void Reduct_Click(object sender, RoutedEventArgs e)
        {
            AddProd addWindow = new AddProd();
            addWindow.ShowDialog();
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ты админ");
        }

        private void ExitMain_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMain.SelectedIndex;
            switch(index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UControl());
                    break;
                case 1:
                    Find(sender,e);
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UControl(true));
                    break;
                default: break;
            }
        }

        private void Find(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new SearchControl());
        }



        private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddProd addWindow = new AddProd();
            addWindow.ShowDialog();
        }

        private void Theme_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(@"..\theme\Default.xaml", UriKind.Relative);
            Resources.MergedDictionaries.Add(dict);
        }

        private void Theme_Click_1(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(@"..\theme\bw.xaml", UriKind.Relative);
            Resources.MergedDictionaries.Add(dict);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(@"..\languages\language.ru-RU.xaml", UriKind.Relative);
            Resources.MergedDictionaries.Add(dict);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(@"..\languages\language.xaml", UriKind.Relative);
            Resources.MergedDictionaries.Add(dict);
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            Lab08.Lab08 wind = new Lab08.Lab08();
            wind.Show();
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            Undo_Click(sender,e);
        }
    }
}
