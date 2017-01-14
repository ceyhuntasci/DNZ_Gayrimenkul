using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNZ_Gayrimenkul.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
        public string CellNo { get; set; }
      
    }
}