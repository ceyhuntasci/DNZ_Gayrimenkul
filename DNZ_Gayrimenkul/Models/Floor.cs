using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNZ_Gayrimenkul.Models
{
    public class Floor
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}