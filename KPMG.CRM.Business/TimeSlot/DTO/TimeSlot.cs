using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.TimeSlot.DTO
{
    public class TimeSlotDTO
    {
        public int TimeId { get; set; }
        public string Time { get; set; }
        public Guid timeSlotID { get; set; }
    }

}
