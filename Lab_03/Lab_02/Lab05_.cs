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

namespace Lab_02
{
    public partial class Lab05_ : Form
    {
        public Lab05_()
        {
            InitializeComponent();
        }

        //Adapter
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Author author = new Author();
            author.FIO = "Merhel Caroine";
            Lb05.Adapter adapter = new Lb05.Adapter(author);
            listBox1.Items.Add("original");
            listBox1.Items.Add(author.Write());
            listBox1.Items.Add("adapter");
            listBox1.Items.Add(adapter.StartWriting());
        }

        //Decorator
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        //Memento
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Library lib1 = new Library();
            Library lib2 = new Library();

            Book book = new Book(new Pdf());
            book.auth = "Иванов Иван Иванович";
            book.date = DateTime.Today;
            book.name = "Test";
            book.UDK = 12345678;
            book.year = 2000;
            book.size = 6;
            lib1.Books.Add(book);
            Book book2 = new Book(new Pdf());
            book2.auth = "Иванов Иван Иванович";
            book2.date = DateTime.Today;
            book2.name = "Test1";
            book2.UDK = 12345678;
            book2.year = 2000;
            book2.size = 6;
            lib2.Books.Add(book2);

            Lb05.Libs libs = new Lb05.Libs();
            libs.libs.Add(lib1);
            Lb05.Caretaker history = new Lb05.Caretaker();
            history.History.Push(libs.SaveState());
            listBox1.Items.Add("original");
            foreach(Library l in libs.libs)
            { 
                foreach(Book b in l.Books)
                {
                    listBox1.Items.Add(b.name);
                }
            }
            listBox1.Items.Add("Added");
            libs.libs.Add(lib2);
            foreach (Library l in libs.libs)
            {
                foreach (Book b in l.Books)
                {
                    listBox1.Items.Add(b.name);
                }
            }
            listBox1.Items.Add("Restored");
            libs.RestoreState(history.History.Pop());
            foreach (Library l in libs.libs)
            {
                foreach (Book b in l.Books)
                {
                    listBox1.Items.Add(b.name);
                }
            }
        }
    }
}