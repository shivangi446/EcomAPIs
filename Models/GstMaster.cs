using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomAPIs.Models
{
    public class GstMaster
    {
        public int GID { get; set; }
        public int HSNCode { get; set; }
        public string GDescription { get; set; }
        public int CGSTR { get; set; }
        public int SGSTR { get; set; }
        public int status { get; set; }

    }
}
