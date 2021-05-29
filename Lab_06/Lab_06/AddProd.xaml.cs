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
using System.Runtime.Serialization.Json;
using System.IO;


namespace Lab_06
{
    /// <summary>
    /// Логика взаимодействия для AddProd.xaml
    /// </summary>
    public partial class AddProd : Window
    {
        public AddProd()
        {
            InitializeComponent();
            GetItems();
        }

        public ProdList prList = new ProdList();
        Caretaker history = new Caretaker();
        public Prod prod = new Prod();
        private void Viewbox_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Viewbox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                listBox1.Items.Clear();
                string[] path = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                foreach(string d in path)
                {
                    if (System.IO.Path.GetExtension(d).Contains(".jpg") || System.IO.Path.GetExtension(d).Contains(".png") )
                    { 
                    ListBoxItem item = new ListBoxItem();

                        item.Content = System.IO.Path.GetFileName(d);
                        item.ToolTip = path;
                        listBox1.Items.Add(item);
                    }
                }
             }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // Valid();
                Prod product = new Prod();
                product.Name = TextBox_Name.Text;
                product.Price = Int32.Parse(TextBox_Price.Text);
                product.Quantity = Int32.Parse(TextBox_Quantity.Text);
                product.ImagePath = @"C:\Users\User\Documents\ооп\OOP_4sem\Lab_06\Lab_06\Pictures\" + listBox1.Items.GetItemAt(0).ToString().Split(new char[] { ' ' })[1];
                product.Description = TextBox_Description.Text;
                product.FullDiscription = TextBox_FullDiscription.Text;

                SetItem(product);

                Clean();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clean()
        {
            TextBox_Description.Text = "";
            listBox1.Items.Clear();
            TextBox_Name.Text = "";
            TextBox_Price.Text = "";
            TextBox_Quantity.Text = "";
            TextBox_FullDiscription.Text = "";
        }
        private void Valid()
        {
            int a;
            if(TextBox_Name.Text.Equals(""))
            {
                MessageBox.Show("Enter name");
                return;
            }
            if (TextBox_Price.Text.Equals(""))
            {
                MessageBox.Show("Enter price");
                return;
            }
            else if(!Int32.TryParse( TextBox_Price.Text,out a))
            {
                MessageBox.Show("Not a number");
                TextBox_Price.Text = "";
                return;
            }
            if (TextBox_Quantity.Text.Equals(""))
            {
                MessageBox.Show("Enter quantity");
                return;
            }
            else if (!Int32.TryParse(TextBox_Quantity.Text, out a))
            {
                MessageBox.Show("Not a number");
                TextBox_Quantity.Text = "";
                return;
            }
            if (TextBox_Description.Text.Equals(""))
            {
                MessageBox.Show("Enter description");
                return;
            }
            if (listBox1.Items.Count==0)
            {
                MessageBox.Show("Add a picture");
                return;
            }
            if(TextBox_FullDiscription.Text.Equals(""))
            {
                MessageBox.Show("Enter full description");
                return;
            }
        }

        public List<Prod> parts = new List<Prod>();
        public List<Prod> GetItems()
        {
            try
            {
                using (DataBase db = new DataBase())
                {
                    parts = db.GetProds();
                }

                //DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(List<Prod>));
                //using (FileStream f = new FileStream("products.json", FileMode.OpenOrCreate))
                //{
                //    parts = (List<Prod>)jsonForm.ReadObject(f);
                //}
                prList.li = parts;
                history.History.Push(prList.SaveState());
                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return parts;
        }

        public void SetItem(Prod a)
        {
            List<Prod> parts = GetItems();
            prod = a;
            parts.Add(a);
            prList.li = parts;
            //DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(List<Prod>));
            //using (FileStream f = new FileStream("products.json", FileMode.OpenOrCreate))
            //{
            //    jsonForm.WriteObject(f, parts);
            //}
            using (DataBase db = new DataBase())
            {
                db.AddProd(a);
                this.Close();
            }

            history.History.Push(prList.SaveState());

        }

        //public void SetList(List<Prod> prods)
        //{
        //    //DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(List<Prod>));
        //    //using (FileStream f = new FileStream("products.json", FileMode.OpenOrCreate))
        //    //{
        //    //    jsonForm.WriteObject(f, prods);
        //    //}

        //    using (DataBase db = new DataBase())
        //    {
        //        db.Trunc();
        //    }
        //    foreach(Prod a in prods)
        //    using (DataBase db = new DataBase())
        //    {
        //        db.AddProd(a);
        //        this.Close();
        //    }

        //}

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            //Memento memento = history.History.Pop();
            //prList.RestoreState(history.History.Pop());
            //SetList(prList.li);
            //history.History.Push(memento);
            //history.History.Push(prList.SaveState());


        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            //Memento memento = history.History.Pop();
            //prList.RestoreState(history.History.Pop());
            //SetList(prList.li);
            //history.History.Push(memento);
            //history.History.Push(prList.SaveState());

        }
    }
}
