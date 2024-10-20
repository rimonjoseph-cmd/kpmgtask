using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Models
{
    public class BuildingModel
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public bool isactive { get; set; } // is blocked or not
        public bool isblocked { get; set; }

    }
}
