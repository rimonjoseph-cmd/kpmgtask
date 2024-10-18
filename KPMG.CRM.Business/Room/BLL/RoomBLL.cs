using KPMG.CRM.Business.Room.DTO;
using KPMG.CRM.DAL;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Room.BLL
{
    public class RoomBLL : IRoomBLL
    {
        private readonly IOrganizationServiceAsync organizationService;

        public RoomBLL(IOrganizationServiceAsync organizationService)
        {
            this.organizationService = organizationService;
        }
        public async Task<Guid> createRoom(CreateRoomInputDTO createRoomInput)
        {
            KPMg_Room room = new KPMg_Room();
            room.KPMg_RoomCode = createRoomInput.Code;
            //room.KPMg_Building = new Microsoft.Xrm.Sdk.EntityReference(KPMg_Building.EntityLogicalName, createRoomInput.BuildingId);
            room.KPMg_Name = createRoomInput.RoomName;
            return await this.organizationService.CreateAsync(room);
        }
    }
}
