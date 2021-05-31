using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для Lab10Wind.xaml
    /// </summary>
    public partial class Lab10Wind : Window, INotifyPropertyChanged
    {
        DataBase db = new DataBase();
        
        public Lab10Wind()
        {
            InitializeComponent();
            products = db.GetProds();
            if(products.Count()!=0)
            prod = products[CurrentStateIndex];
            UpdFileds();
        }
        public int CurrentStateIndex = 0;
        Prod prod = new Prod();
        List<Prod> products = new List<Prod>();
        public byte[] BinImage
        {
            get
            {
                return prod.Image;
            }
            set
            {
                prod.Image = value;
                OnPropertyChanged(nameof(BinImage));
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Description
        {
            get
            {
                return prod.Description;
            }
            set
            {
                prod.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public int Quantity
        {
            get
            {
                return prod.Quantity;
            }
            set
            {
                prod.Quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public int Price
        {
            get
            {
                return prod.Price;
            }
            set
            {
                prod.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        private string errorMes;
        public string ErrorMes
        {
            get { return errorMes; }
            set
            {
                this.errorMes = value;
                OnPropertyChanged(nameof(ErrorMes));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = "";
            if (OpenFile(ref FilePath))
            {
                try
                {
                    this.BinImage = File.ReadAllBytes(FilePath);
                    prod.ImagePath = FilePath;
                    Img.Source = new BitmapImage(new Uri(FilePath));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private bool OpenFile(ref string FilePath)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentStateIndex == 0) CurrentStateIndex = products.Count()-1;
            else CurrentStateIndex--;
            prod = products[CurrentStateIndex];
            UpdFileds();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentStateIndex == products.Count() - 1 || products.Count()==0) CurrentStateIndex = 0;
            else
            CurrentStateIndex++;
            prod = products[CurrentStateIndex];
            UpdFileds();
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            prod = new Prod();
            products.Add(prod);
            CurrentStateIndex = products.Count()-1;
            UpdFileds();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            FieldToProd();
            db.Update(CurrentStateIndex,prod);
            products = db.GetProds();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (products[CurrentStateIndex]==prod)
                CurrentStateIndex = 0;
            db.Delete(prod);
            products = db.GetProds();
            UpdFileds();
        }

        public void UpdFileds()
        {
            NameBox.Text = prod.Name;
            PriceBox.Text = prod.Price.ToString();
            Quant.Text = prod.Quantity.ToString();
            Descr.Text = prod.Description;
            if (prod.ImagePath!=null)
            Img.Source = new BitmapImage(new Uri(prod.ImagePath));
        }
        public void FieldToProd()
        {
            try
            {
                prod.Name = NameBox.Text;
                prod.Price = Int32.Parse(PriceBox.Text);
                prod.Quantity = Int32.Parse(Quant.Text);
                prod.Description = Descr.Text;
            }
            catch (Exception ex) { }
        }

        private void SaveNew_Click(object sender, RoutedEventArgs e)
        {
            db.AddProd(prod);
            products = db.GetProds();
        }
    }
}
