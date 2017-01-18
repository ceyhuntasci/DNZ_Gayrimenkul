using DNZ_Gayrimenkul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNZ_Gayrimenkul.ViewModels
{
    public class PropertyViewModel
    {
        public Property Property { get; set; }
        public List<Specification> innerSpecs { get; set; }
        public List<Specification> outerSpecs { get; set; }
        public List<Specification> locationSpecs { get; set; }
    }
}