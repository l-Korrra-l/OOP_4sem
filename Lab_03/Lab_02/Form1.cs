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
using System.ComponentModel.DataAnnotations;


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
            Authori();
        }

        List<Author> authors = new List<Author>();
        public void Authori()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Author>));
                using (FileStream stream = new FileStream("Authors.xml", FileMode.Open))
                {
                    authors = serializer.Deserialize(stream) as List<Author>;
                }

                foreach (Author a in authors)
                    domainUpDown1.Items.Add(a.FIO);
            }
            catch (Exception e)
            {
                MessageBox.Show("Отсутствуют автры книг");
            }
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
            label11.Text = $"Текущие дата и время: {DateTime.Now}";
            label12.Text = $"Количество объектов: {library.Books.Count}";
            progressBar1.PerformStep();
            Task.Delay(new TimeSpan(0, 0, 10)).ContinueWith(o => { timer1.Enabled=false; });
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private int check = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                filled();
                Book currentBook = new Book();
                switch (comboBox1.Text)
                {
                    case ".pdf":
                        currentBook = new Book(new Pdf());
                        break;  
                    case ".epub":
                        currentBook = new Book(new Epub());
                        break;
                    case ".txt":
                        currentBook = new Book(new Txt());
                        break;
                    case ".docx":
                        currentBook = new Book(new Docx());
                        break;
                }
                currentBook.name = textBox1.Text;
                currentBook.auth = domainUpDown1.Text;
                currentBook.UDK = Int32.Parse(textBox3.Text);
                currentBook.year = (int)numericUpDown1.Value;
                currentBook.size = trackBar1.Value;
                currentBook.date = dateTimePicker2.Value;
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


                if (radioButton6.Checked) { currentBook.numb += radioButton6.Text; }
                if (radioButton7.Checked) { currentBook.numb += radioButton7.Text; }
                if (radioButton8.Checked) { currentBook.numb += radioButton8.Text; }

                var context = new ValidationContext(currentBook);
                var res = new List<ValidationResult>();
                if (!Validator.TryValidateObject(currentBook, context, res, true)) MessageBox.Show(res[0].ErrorMessage);
                else
                {
                    listBox1.Items.Add(currentBook.result);
                    label13.Text = $"Последнее действие: {button1.Text}";
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void filled()
        {
            if (textBox1.Text.Equals(""))
            { 
                MessageBox.Show("Введите название книги");
                return; 
            }
            if (domainUpDown1.Text.Equals(""))
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

                if (library.Books.Count == 0) 
                {
                    MessageBox.Show("Не элементов для сохранения");
                    return;
                }
            try
            {   
                XmlSerializer serializer = new XmlSerializer(typeof(Library));
                using (FileStream stream = new FileStream("Library.xml", FileMode.OpenOrCreate))
                {
                    serializer.Serialize(stream, library);
                }
                label13.Text = $"Последнее действие: {button2.Text}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка создания файла");
                
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
            label10.Text = $"Текущее значение:{trackBar1.Value}";
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
            Open();
            foreach (Book book in library.Books)
                listBox1.Items.Add(book.result);
            label13.Text = $"Последнее действие: {button3.Text}";


        }

        public void Open()
        {
            try
            {
                listBox1.Items.Clear();
                XmlSerializer serializer = new XmlSerializer(typeof(Library));
                using (FileStream stream = new FileStream("Library.xml", FileMode.Open))
                {
                    library = serializer.Deserialize(stream) as Library;
                }
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

        public Search newForm = new Search();
        private void button4_Click(object sender, EventArgs e)
        {
            newForm.Show();
            if (newForm != null && newForm.IsDisposed!=true) button4.Enabled = false;

            newForm.FormClosed += new FormClosedEventHandler(FormClosed);
            label13.Text = $"Последнее действие: {button4.Text}";

        }
        public void FormClosed(object sender, FormClosedEventArgs e)
        {
            this.button4.Enabled = true;
            newForm = new Search();
        }   

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merhel Caroline -+- Version i.d.k.");
            label13.Text = $"Последнее действие: О программе";
        }

        private void поНазваниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (library.Books.Count==0) Open();
            IEnumerable<Book> lib=library.Books.OrderBy(p => p.name);
            Library libb = new Library();
            foreach (Book book in lib)
            {
                listBox1.Items.Add(book.result);
                libb.Books.Add(book);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(Library));
            using (FileStream stream = new FileStream("DateOrder.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, libb);
            }
            label13.Text = $"Последнее действие: Сортировка";
        }

        private void поДатеЗагрузкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (library.Books.Count == 0) Open();
            var lib = library.Books.OrderBy(p => p.date);
            Library libb = new Library();

            foreach (Book book in lib)
            {
                listBox1.Items.Add(book.result);
                libb.Books.Add(book);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Library));
            using (FileStream stream = new FileStream("DateOrder.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, libb);
            }
            label13.Text = $"Последнее действие: Сортировка";
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            library.Books.Clear();

        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4_Click(sender,e);
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender,e);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label13.Text = $"Последнее действие: {button6.Text}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            library.Books.Clear();
            label13.Text = $"Последнее действие: {button5.Text}";
        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }
        public Authors a = new Authors();
        private void автораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            a.Show();
            if (a != null && newForm.IsDisposed != true) автораToolStripMenuItem.Enabled = false;

            a.FormClosed += new FormClosedEventHandler(FormClosedd);
            label13.Text = $"Последнее действие: {автораToolStripMenuItem.Text}";

        }
        public void FormClosedd(object sender, FormClosedEventArgs e)
        {
            this.автораToolStripMenuItem.Enabled = true;
            try
            {
                Authori();
                a = new Authors();
            }
            catch (Exception exp)
            {

            }
         
        }
    

        public AppSettings Config { get; set; }
        private void button7_Click(object sender, EventArgs e)
        {
            Config = AppSettings.GetInstance(this.Size.ToString());
            MessageBox.Show(Config.settings);
        }

        public Lab05_ newForm5 = new Lab05_();
        private void lab05ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            newForm5.Show();
            if (newForm5 != null && newForm5.IsDisposed != true) lab05ToolStripMenuItem.Enabled = false;

            newForm5.FormClosed += new FormClosedEventHandler(FormClosed05);
            label13.Text = $"Последнее действие: {lab05ToolStripMenuItem.Text}";

        }

        public void FormClosed05(object sender, FormClosedEventArgs e)
        {
            this.button4.Enabled = true;
            newForm5 = new Lab05_();
        }
    }
}
