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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
            Init();
        }

        TextBox textBox2 = new System.Windows.Forms.TextBox();
        NumericUpDown numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        DomainUpDown domainUpDown1 = new System.Windows.Forms.DomainUpDown();
        public void Init()
        {
            textBox2.Location = new System.Drawing.Point(checkBox2.Location.X, checkBox2.Location.Y+20);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(141, 22);
            textBox2.TabIndex = 0;
            textBox2.Visible = false;

            numericUpDown1.Location = new Point(checkBox3.Location.X,checkBox3.Location.Y+20);
            numericUpDown1.Size = new System.Drawing.Size(141, 22);
            numericUpDown1.Visible = false;
            numericUpDown1.Minimum = 1899;
            numericUpDown1.Maximum = 2021;
            numericUpDown1.Value = 1899;

            this.domainUpDown1.Items.Add("");
            this.domainUpDown1.Items.Add("<200");
            this.domainUpDown1.Items.Add("200-500");
            this.domainUpDown1.Items.Add(">500");
            this.domainUpDown1.Location = new System.Drawing.Point(checkBox4.Location.X, checkBox4.Location.Y+20);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(120, 22);
            this.domainUpDown1.TabIndex = 10;
            this.domainUpDown1.Visible = false;

            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(domainUpDown1);
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(textBox1.Text== "текст для поиска")
            textBox1.Text = "";
            if (e.KeyCode == Keys.Enter) Searching();
        }

        private void Searching()
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {

        }



        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Visible = true;
                checkBox3.Location = new Point(checkBox3.Location.X, checkBox3.Location.Y + 25);
                checkBox4.Location = new Point(checkBox4.Location.X, checkBox4.Location.Y + 25);
                numericUpDown1.Location = new Point(numericUpDown1.Location.X,numericUpDown1.Location.Y + 25);
                domainUpDown1.Location = new Point(domainUpDown1.Location.X, domainUpDown1.Location.Y + 25);

            }
            else
            {
                textBox2.Visible = false;
                checkBox3.Location = new Point(checkBox3.Location.X, checkBox3.Location.Y - 25);
                checkBox4.Location = new Point(checkBox4.Location.X, checkBox4.Location.Y - 25);
                numericUpDown1.Location = new Point(numericUpDown1.Location.X, numericUpDown1.Location.Y - 25);
                domainUpDown1.Location = new Point(domainUpDown1.Location.X, domainUpDown1.Location.Y - 25);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                numericUpDown1.Visible = true;
                checkBox4.Location = new Point(checkBox4.Location.X, checkBox4.Location.Y + 25);
                domainUpDown1.Location = new Point(domainUpDown1.Location.X, domainUpDown1.Location.Y + 25);
            }
            else
            {
                numericUpDown1.Visible =false;
                checkBox4.Location = new Point(checkBox4.Location.X, checkBox4.Location.Y - 25);
                domainUpDown1.Location = new Point(domainUpDown1.Location.X, domainUpDown1.Location.Y - 25);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                domainUpDown1.Visible = true;
            }
            else
            {
                domainUpDown1.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox1.Visible = true;
                textBox1.Enabled = false;
            }
            else
            {
                groupBox1.Visible = false;
                textBox1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            listBox1.Items.Clear();
            numericUpDown1.Value = 1899;
            textBox2.Text = "";
            domainUpDown1.SelectedIndex = 0;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Library library = new Library();
                XmlSerializer serializer = new XmlSerializer(typeof(Library));
                using (FileStream stream = new FileStream("Library.xml", FileMode.Open))
                {
                    library = serializer.Deserialize(stream) as Library;
                }

                Regex r = new Regex(textBox1.Text);
                int check= 0;
                int cont = 0;

                foreach (Book book in library.Books)
                    if (r.IsMatch(book.result))
                        listBox1.Items.Add(book.result);
                    else
                    {
                        if (checkBox1.Checked)
                        {
                            if (textBox2.Text.Length > 0 && textBox2.Text == book.publisher)
                                listBox1.Items.Add(book.result);
                            if (numericUpDown1.Value != 1899 && numericUpDown1.Value == book.year)
                                listBox1.Items.Add(book.result);
                            if (domainUpDown1.SelectedIndex > 0 && domainUpDown1.Text == book.numb)
                                listBox1.Items.Add(book.result);
                        }
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
