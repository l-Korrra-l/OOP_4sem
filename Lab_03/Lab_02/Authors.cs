using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab_02
{
    public partial class Authors : Form
    {
        public List<Author> authors = new List<Author>();
        public Authors()
        {
            InitializeComponent();
            FromFile();
        }

        public void FromFile()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Author>));
                using (FileStream stream = new FileStream("Authors.xml", FileMode.Open))
                {
                    authors = serializer.Deserialize(stream) as List<Author>;
                }
            }
            catch(Exception e)
            {

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Regex r = new Regex(@"^([А-ЯA-Z]|[А-ЯA-Z][\x27а-яa-z]{1,}|[А-ЯA-Z][\x27а-яa-z]{1,}\-([А-ЯA-Z][\x27а-яa-z]{1,}|(оглы)|(кызы)))\040[А-ЯA-Z][\x27а-яa-z]{1,}(\040[А-ЯA-Z][\x27а-яa-z]{1,})?$");
                Regex r1 = new Regex(@"\w{1,9}");
                if (!r.IsMatch(textBox1.Text))
                {
                    MessageBox.Show("Неверный формат ФИО");
                }
                else if (!r1.IsMatch(textBox3.Text) || !r1.IsMatch(textBox4.Text))
                {
                    MessageBox.Show("ТОЛЬКО ЦИФРЫ!!!!!!!!!!!!!!!!!");
                }
                else
                {
                    AuthorCreator tmp = new AuthorCreator();
                    AuthorBuilder t = new BuilderAuth();
                    Author temp = tmp.Create(t,textBox1.Text,Convert.ToInt32(textBox3.Text),Convert.ToInt32(textBox4.Text), domainUpDown1.Text );
                    
                    foreach (Author i in authors)
                    {
                        if (temp.FIO == i.FIO)
                        {
                            throw new Exception("Попытка повторного добавления члена экипажа");
                        }
                    }
                    authors.Add(temp);
                    listBox1.Items.Add(temp);

                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Author>));
                        using (FileStream stream = new FileStream("Authors.xml", FileMode.OpenOrCreate))
                        {
                            serializer.Serialize(stream, authors);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка создания файла");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            domainUpDown1.Text="";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Author a in authors)
                listBox1.Items.Add(a.ToString());
        }
    }
}
