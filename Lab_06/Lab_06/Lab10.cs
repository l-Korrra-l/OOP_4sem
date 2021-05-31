using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab_06
{
    class Lab10: INotifyPropertyChanged
    {
        DataBase db = new DataBase();

        public Lab10()
        {
            List<Prod> products = new List<Prod>();
            products = db.GetProds();
            if (products.Count() != 0)
                prod = products[CurrentStateIndex];

        }
        public int CurrentStateIndex = 0;
        Prod prod = new Prod();
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
        public string Name
        {
            get
            {
                return prod.Name;
            }
            set
            {
                prod.Name = value;
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
            List<Prod> products = new List<Prod>();
            if (CurrentStateIndex == 0) CurrentStateIndex = products.Count() - 1;
            else CurrentStateIndex--;
            prod = products[CurrentStateIndex];
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            List<Prod> products = new List<Prod>();
            if (CurrentStateIndex == products.Count() - 1 || products.Count() == 0) CurrentStateIndex = 0;
            else
                CurrentStateIndex++;
            prod = products[CurrentStateIndex];
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            List<Prod> products = new List<Prod>();
            prod = new Prod();
            products.Add(prod);
            CurrentStateIndex = products.Count();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            List<Prod> products = new List<Prod>();
            prod.Name = Name;
            db.AddProd(prod);
            products = db.GetProds();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            List<Prod> products = new List<Prod>();
            if (products[CurrentStateIndex] == prod)
                CurrentStateIndex = 0;
            db.Delete(prod);
            products = db.GetProds();
        }
    }
}
