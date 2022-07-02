using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcomAPIs.Models
{
    public class Productls
    {
        [Required]
        public int Cmid { get; set; }
        [Required]
        public int Brandid { get; set; }
        [Required]
        public string Pname { get; set; }
        [Required]
        public string LD { get; set; }
        [Required]
        public string SD { get; set; }
        [Required]
        public int MRP { get; set; }
        [Required]
        public int DP { get; set; }
        [Required]
        public int Availqty { get; set; }
        [Required]
        public int status { get; set; }
        public int gid { get; set; }

    }
}
