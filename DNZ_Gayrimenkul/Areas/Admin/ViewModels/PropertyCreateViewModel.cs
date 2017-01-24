using DNZ_Gayrimenkul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNZ_Gayrimenkul.Areas.Admin.ViewModels
{
    public class PropertyCreateViewModel
    {
        public Property Property { get; set; }
        public List<Specification> InnerSpecs { get; set; }
        public List<Specification> OuterSpecs { get; set; }
        public List<Specification> LocationSpecs { get; set; }
        
    }
}