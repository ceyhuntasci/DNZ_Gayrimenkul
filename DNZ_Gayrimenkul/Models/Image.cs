using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNZ_Gayrimenkul.Models
{
    public class Image
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public int PropertyID { get; set; }
       

        public virtual Property Property { get; set; }
     
    }
}