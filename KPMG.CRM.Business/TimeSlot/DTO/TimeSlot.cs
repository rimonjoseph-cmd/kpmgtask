using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.TimeSlot.DTO
{
    public class TimeSlotDTO
    {
        public int timeid { get; set; }
        public string time { get; set; }
        public Guid timeslotid { get; set; }
    }

}
