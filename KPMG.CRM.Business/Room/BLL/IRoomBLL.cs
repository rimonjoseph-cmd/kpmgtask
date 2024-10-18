using KPMG.CRM.Business.Room.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Room.BLL
{
    public  interface IRoomBLL
    {
        Task<Guid> createRoom(CreateRoomInputDTO createRoomInput);
    }
}
