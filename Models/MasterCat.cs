using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomAPIs.Models
{
    public class MasterCat
    {
        public int Cmid { get; set; }
        public int Parentid { get; set; }
        public string Cname { get; set; }
        public string Cdescription { get; set; }
        public int Status { get; set; }
        
    }
}
