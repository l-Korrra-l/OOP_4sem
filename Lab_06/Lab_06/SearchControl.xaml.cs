using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Lab_06
{
    /// <summary>
    /// Логика взаимодействия для SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        public SearchControl()
        {
            InitializeComponent();
            CommandBinding bindFind = new CommandBinding(ApplicationCommands.Find);
            bindFind.Executed += SearchB_Click;
            this.CommandBindings.Add(bindFind);

            CommandBinding bindDel = new CommandBinding(ApplicationCommands.Delete);
            bindDel.Executed += Button_Click;
            this.CommandBindings.Add(bindDel);
        }



        List<Prod> result = new List<Prod>();
        List<Prod> list = new List<Prod>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(Prod p in result)
            {
                using (DataBase db = new DataBase())
                {
                    db.Delete(p);
                }
            }
            //DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(List<Prod>));
            //using (FileStream f = new FileStream("products.json", FileMode.OpenOrCreate))
            //{
            //    jsonForm.WriteObject(f, list);
            //}
            Clean();
        }

        public void Clean()
        {
            name.Text = "";
            partList.ItemsSource = result;
            UpPrice.Text = "";
            BottomPrice.Text = "";
        }
        private void SearchB_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(List<Prod>));
                //using (FileStream f = new FileStream("products.json", FileMode.OpenOrCreate))
                //{
                //    list = (List<Prod>)jsonForm.ReadObject(f);
                //}
                using (DataBase db = new DataBase())
                {
                    list = db.GetProds();
                }
                if (name.Text != null && name.Text != "")
                    result = new List<Prod>(list.Where(d => d.ToString().Contains(name.Text)));

                if (UpPrice.Text != "" && BottomPrice.Text != "")
                {
                    int top = Convert.ToInt32(UpPrice.Text);
                    int botom = Convert.ToInt32(BottomPrice.Text);
                    if (botom != null && top != null)
                    {
                        if (botom > top) top = botom;
                        result = new List<Prod>(result.Where(d => d.Price <= top && d.Price >= botom));
                    }
                }
                partList.ItemsSource = result;
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
