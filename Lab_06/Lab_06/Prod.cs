using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    [Serializable]
    public class Prod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string  FullDiscription { get; set; }
        public byte[] Image { get; set; }
        public Prod() { }
        public Prod(int id, string name, string desc, int quantity, int price, string imgpath, string fulldiscription)
        {
            Id = id;
            Name = name;
            Description = desc;
            Quantity = quantity;
            Price = price;
            ImagePath = imgpath;
            FullDiscription = fulldiscription;
            //Image = File.ReadAllBytes(ImagePath);
        }

        public string ToString()
        {
            return Id + " " + Name + " " + Description + " " + ImagePath + " " + Quantity + " " + Price + " " + FullDiscription;
        }
    }
}
