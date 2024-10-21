using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Models
{
    public class ContactModel
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string username { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string paswword { get; set; }
        public string confirmPassword { get; set; }
    }
}
