using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Models
{
    public class BuildingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string code { get; set; }
        public bool isActive { get; set; } // is blocked or not

    }
}
