using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    public abstract class AuthorBuilder
    {
        public Author author { get;  set; }
        public void CreateWorker()
        {
            author = new Author();
        }
        public abstract void setFIO(string FIO);
        public abstract void setAge(int age);
        public abstract void setCountry(string workExpirience);
        public abstract void setId(int post);
    }
    public class AuthorCreator
    {
        public Author Create(AuthorBuilder builder, string FIO, int age, int id, string country)
        {
            builder.CreateWorker();
            builder.setFIO(FIO);
            builder.setAge(age);
            builder.setCountry(country);
            builder.setId(id);
            return builder.author;
        }
    }
    public class BuilderAuth : AuthorBuilder
    {
        public override void setFIO(string FIO)
        {
            author.FIO = FIO;
        }
        public override void setAge(int age)
        {
            author.age = age;
        }
        public override void setCountry(string country)
        {
            author.country = country;
        }
        public override void setId(int id)
        {
            author.id = id;
        }
    }
}
