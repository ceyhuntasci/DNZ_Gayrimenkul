using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNZ_Gayrimenkul.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public bool ShowOnMap { get; set; }

        public virtual Property Property { get; set; }
      
    }
}