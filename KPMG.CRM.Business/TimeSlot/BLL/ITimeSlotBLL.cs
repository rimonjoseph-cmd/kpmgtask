using KPMG.CRM.Business.TimeSlot.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.TimeSlot.BLL
{
    public interface ITimeSlotBLL
    {
        Task<List<TimeSlotDTO>> getAll();
        void createtimeslotconfiguration();
    }
}
