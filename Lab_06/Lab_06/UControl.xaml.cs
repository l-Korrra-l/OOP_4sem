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
using System.IO;
using System.Runtime.Serialization.Json;


namespace Lab_06
{
    /// <summary>
    /// Логика взаимодействия для UControl.xaml
    /// </summary>
    public partial class UControl : UserControl
    {
        private List<Prod> prods { get; set; }
        public UControl()
        {
            InitializeComponent();
            prods = GetItems();
            partList.ItemsSource = prods;
        }

        public List<Prod> GetItems()
        {
            List<Prod> parts = new List<Prod>();
            try
            {
                DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(List<Prod>));
                using (FileStream f = new FileStream("products.json", FileMode.OpenOrCreate))
                {
                    parts = (List<Prod>)jsonForm.ReadObject(f);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("а файла то нет");
                Prod pr = new Prod();
                pr.Name = "Hi";
                pr.Price = 0;
                pr.Quantity = 0;
                pr.Description = "Priceless";
                pr.ImagePath = @"C:\Users\User\Documents\ооп\OOP_4sem\Lab_06\Lab_06\bin\Debug\vnkMpQHDPM0.png";
                pr.FullDiscription = "Full Description of this item";
                parts.Add(pr);
            }
            return parts;
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Full window = new Full((Prod)partList.SelectedItem);
            window.Show();

        }
    }
}
