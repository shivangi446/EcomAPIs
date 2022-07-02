using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomAPIs.Models
{
    public class Product
    {
        public int product_id { get; set; }
        public int category { get; set; }
        public int size { get; set; }
        public int color { get; set; }
        public int package { get; set; }
        public int tag { get; set; }
    }
}
