using KPMG.CRM.Business.Room.DTO;
using KPMG.CRM.Business.TimeSlot.BLL;
using KPMG.CRM.DAL;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Room.BLL
{
    public class RoomBLL : IRoomBLL
    {
        private readonly IOrganizationServiceAsync organizationService;
        private readonly ITimeSlotBLL timeSlotBLL;
        
        public RoomBLL(IOrganizationServiceAsync organizationService,ITimeSlotBLL timeSlotBLL)
        {
            this.organizationService = organizationService;
            this.timeSlotBLL = timeSlotBLL;
        }
        public async Task<Guid> createRoom(CreateRoomInputDTO createRoomInput)
        {
            KPMg_Room room = new KPMg_Room();
            room.KPMg_RoomCode = createRoomInput.Code;
            //room.KPMg_Building = new Microsoft.Xrm.Sdk.EntityReference(KPMg_Building.EntityLogicalName, createRoomInput.BuildingId);
            room.KPMg_Name = createRoomInput.RoomName;
            return await this.organizationService.CreateAsync(room);
        }

        public async Task<List<RoomModel>> getAvailable(DateTime dateInput)
        {

            QueryExpression roomsqueryExpression = new QueryExpression(KPMg_Room.EntityLogicalName);
            roomsqueryExpression.ColumnSet = new ColumnSet(true);
            roomsqueryExpression.Criteria.AddCondition(KPMg_Room.Fields.StateCode,ConditionOperator.Equal, (int)KPMg_Room_StateCode.Active);

            #region building check not blocked
            // Create a LinkEntity for the Building relationship
            string buildingalias = "building";
            LinkEntity buildingLink = new LinkEntity(KPMg_Room.EntityLogicalName, KPMg_Building.EntityLogicalName, KPMg_Room.Fields.KPMg_Building, KPMg_Building.PrimaryIdAttribute, JoinOperator.Inner);
            buildingLink.Columns = new ColumnSet(KPMg_Building.Fields.KPMg_BuildingCode, KPMg_Building.Fields.StateCode);
            buildingLink.EntityAlias = buildingalias;
            // Add a condition to filter for active buildings (statecode = 0)
            buildingLink.LinkCriteria.AddCondition(KPMg_Building.Fields.StateCode, ConditionOperator.Equal, (int)KPMg_Building_StateCode.Active);

            // Add the LinkEntity to the QueryExpression
            roomsqueryExpression.LinkEntities.Add(buildingLink);
            #endregion
            var rooms  =  await this.organizationService.RetrieveMultipleAsync(roomsqueryExpression);
            List<RoomModel> roomsModel = new List<RoomModel>();
            if (rooms != null && rooms?.Entities.Count > 0)
            {
               
                foreach (var roomEntity in rooms.Entities)
                {
                    roomsModel.Add(new RoomModel() {
                        id = roomEntity.Id,
                        code = roomEntity.GetAttributeValue<string>(KPMg_Room.Fields.KPMg_RoomCode),
                        name = roomEntity.GetAttributeValue<string>(KPMg_Room.Fields.KPMg_Name),
                        isActive = true,
                        building = new Models.BuildingModel()
                        {
                            Id = roomEntity.GetAttributeValue<Guid>(KPMg_Room.Fields.Id),
                            code = roomEntity.GetAttributeValue<AliasedValue>(buildingalias + "." + KPMg_Building.Fields.KPMg_BuildingCode)?.Value as string,
                            Name = roomEntity.GetAttributeValue<AliasedValue>(buildingalias + "." + KPMg_Building.Fields.KPMg_Name)?.Value as string,
                            isActive = true
                        }
                    });
                }
            }

            #region get bookRoom available
            foreach (var roomitem in roomsModel) { 
                QueryExpression roomitemBookQuery = new QueryExpression(KPMg_BookRoom.EntityLogicalName);
                roomitemBookQuery.ColumnSet = new ColumnSet(true);
                roomitemBookQuery.Criteria.AddCondition(KPMg_BookRoom.Fields.KPMg_BookingDay,ConditionOperator.Equal, new DateTime(2024, 10, 19));
                roomitemBookQuery.Criteria.AddCondition(KPMg_BookRoom.Fields.KPMg_BookRoomId,ConditionOperator.Equal, roomitem.id);

                //LinkEntity timeslotLink = new LinkEntity(KPMg_BookRoom.EntityLogicalName, "kpmg_predefinedtimeslots",
                //    KPMg_BookRoom.Fields., KPMg_Building.PrimaryIdAttribute, JoinOperator.Inner);
                 
                //buildingLink.Columns = new ColumnSet(KPMg_Building.Fields.KPMg_BuildingCode, KPMg_Building.Fields.StateCode);
                //buildingLink.EntityAlias = buildingalias;
                //// Add a condition to filter for active buildings (statecode = 0)
                //buildingLink.LinkCriteria.AddCondition(KPMg_Building.Fields.StateCode, ConditionOperator.Equal, (int)KPMg_Building_StateCode.Active);

                //// Add the LinkEntity to the QueryExpression
                //roomsqueryExpression.LinkEntities.Add(buildingLink);
                var bookroom = await this.organizationService.RetrieveMultipleAsync(roomitemBookQuery);
                
            }
            #endregion

            return roomsModel;
        }
    }
}
