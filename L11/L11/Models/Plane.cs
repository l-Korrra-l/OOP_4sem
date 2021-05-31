using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace L11.Models
{
    public class Plane
    {
        [Key]
        public int id { get; set; }
        public string model { get; set; }
        public List<Worker> Workers { get; set; }
    }
}
