using DNZ_Gayrimenkul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNZ_Gayrimenkul.ViewModels
{
    public class HomeViewModel
    {
        public List<Property> Properties { get; set; }
        public List<Property> Features { get; set; }
    }
}