using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    public abstract class AbstractFactory
    {
        public abstract Book SetType();
    }

    public class Pdf:AbstractFactory
    {
        public override Book SetType()
        {
            return new PdfBook();
        }
    }
    [Serializable]
    public class PdfBook: Book
    {
        public PdfBook()
        {
            format = ".pdf";
        }
    }

    public class Epub : AbstractFactory
    {
        public override Book SetType()
        {
            return new EpubBook();
        }
    }
    [Serializable]
    public class EpubBook : Book
    {
        public EpubBook()
        {
            format = ".epub";
        }
    }

    public class Txt : AbstractFactory
    {
        public override Book SetType()
        {
            return new TxtBook();
        }
    }
    [Serializable]
    public class TxtBook : Book
    {
        public TxtBook()
        {
            format = ".txt";
        }
    }

    public class Docx : AbstractFactory
    {
        public override Book SetType()
        {
            return new DocxBook();
        }
    }
    [Serializable]
    public class DocxBook : Book
    {
        public DocxBook()
        {
            format = ".epub";
        }
    }
}
