using KPMG.CRM.Business.Models;
using KPMG.CRM.Business.TimeSlot.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Room.DTO
{
    public class RoomModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public bool isActive { get; set; } // is blocked or not
        public BuildingModel building { get; set; } 
        public List<TimeSlotDTO> timeSlotAvailable { get; set; }
    }
}
