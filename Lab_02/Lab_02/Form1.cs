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
using System.Windows.Forms;


namespace Lab_02
{
    public partial class Form1 : Form
    {
        public Library library;
        public Form1()
        {
            InitializeComponent();
            library = new Library();
            timer1.Interval = 1;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
           
        }
        


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            Task.Delay(new TimeSpan(0, 0, 10)).ContinueWith(o => { timer1.Enabled=false; });
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private int check = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            filled();

            Book currentBook = new Book
            {
                name = textBox1.Text,
                auth = textBox2.Text,
                UDK = Int32.Parse(textBox3.Text),
                year = (int)numericUpDown1.Value,
                format = comboBox1.Text,
                size = trackBar1.Value,
                date=dateTimePicker2.Value
            };

            library.Books.Add(currentBook);

            if (checkBox1.Checked) { currentBook.publisher += checkBox1.Text; check++; }
            if (checkBox2.Checked)
            {
                if (check > 0) currentBook.publisher += " , ";
                currentBook.publisher += checkBox2.Text;
                check++;
            }
            if (checkBox3.Checked)
            {
                if (check > 0) currentBook.publisher += " , ";
                currentBook.publisher += checkBox3.Text;
                check = 0;
            }


            if (radioButton6.Checked) { currentBook.numb += radioButton6.Text;}
            if (radioButton7.Checked) { currentBook.numb += radioButton7.Text;}
            if (radioButton8.Checked) { currentBook.numb += radioButton8.Text;}

            listBox1.Items.Add(currentBook.result);
        }

        private void filled()
        {
            if (textBox1.Text.Equals(""))
            { 
                MessageBox.Show("Введите название книги");
                return; 
            }
            if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Введите авторов книги");
                return;
            }
            if (textBox3.Text.Equals(""))
            {
                MessageBox.Show("Введите удк книги");
                return;
            }
            if (comboBox1.Text.Equals(""))
            {
                MessageBox.Show("Выберите формат документа");
                return;
            }
            if (radioButton6.Checked.Equals(false) && radioButton8.Checked.Equals(false) && radioButton7.Checked.Equals(false))
            {
                MessageBox.Show("Выберите количество страниц документа");
                return;
            }
            if (checkBox1.Checked.Equals(false)&& checkBox2.Checked.Equals(false) && checkBox3.Checked.Equals(false))
            {
                MessageBox.Show("Выберите издания");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filled();
            XmlSerializer serializer = new XmlSerializer(typeof(Library));
            using (FileStream stream = new FileStream("Library.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, library);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Library));
                using (FileStream stream = new FileStream("Library.xml", FileMode.Open))
                {
                    library = serializer.Deserialize(stream) as Library;
                }
                foreach (Book book in library.Books)
                    listBox1.Items.Add(book.result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно открыть файл");
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void format_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void format_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)e.KeyData) && e.KeyData!=Keys.Enter)
            {
                MessageBox.Show("УДК должно содержать только цифры");
                textBox3.Text = "";
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            Label sdf = new Label();

            newForm.Controls.Add(textBox1);

        }
    }
}
