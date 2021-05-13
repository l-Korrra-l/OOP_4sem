using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    [Serializable]
    public class Library: Prototype.IClone
    {
        public List<Book> Books { get; set; }
        public Book book;
        public Library()
        {
            Books = new List<Book>();
            book = new Book();
        }
        public Library(AbstractFactory factory)
        {
            Books = new List<Book>();
            book = factory.SetType();
        }
        public Library(List<Book> books, Book book)
        {
            this.Books = books;
            this.book = book;
        }

        public Prototype.IClone Clone()
        {
            return new Library(Books, book);
        }

        //----------------------------------------
    }
}
