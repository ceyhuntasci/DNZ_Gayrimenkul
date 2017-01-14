using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNZ_Gayrimenkul.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Password { get; set; }
        public DateTime SignupDate { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}