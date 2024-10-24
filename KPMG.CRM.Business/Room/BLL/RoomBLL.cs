using KPMG.CRM.Business.Room.DTO;
using KPMG.CRM.Business.TimeSlot.BLL;
using KPMG.CRM.Business.TimeSlot.DTO;
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
using System.Xml.Linq;

namespace KPMG.CRM.Business.Room.BLL
{
    public class RoomBLL : IRoomBLL
    {
        private readonly IOrganizationServiceAsync organizationService;
        private readonly ITimeSlotBLL timeSlotBLL;
        string fromtimeslot = "fromtimeslot";
        string totimeslot = "totimeslot";
        string buildingalias = "building";

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

        public LinkEntity getbuildingwithroomlink()
        {
            LinkEntity buildingLink = new LinkEntity(KPMg_Room.EntityLogicalName, KPMg_Building.EntityLogicalName, KPMg_Room.Fields.KPMg_Building, KPMg_Building.PrimaryIdAttribute, JoinOperator.Inner);
            buildingLink.Columns = new ColumnSet(KPMg_Building.Fields.KPMg_BuildingCode, KPMg_Building.Fields.StateCode, KPMg_Building.Fields.KPMg_Name);
            buildingLink.EntityAlias = buildingalias;
            // Add a condition to filter for active buildings (statecode = 0)
            buildingLink.LinkCriteria.AddCondition(KPMg_Building.Fields.StateCode, ConditionOperator.Equal, (int)KPMg_Building_StateCode.Active);
            return buildingLink;
        }
        public async Task<List<RoomModel>> getAvailable(DateTime dateInput)
        {
            List<RoomModel> result = new List<RoomModel>();

            QueryExpression roomsqueryExpression = new QueryExpression(KPMg_Room.EntityLogicalName);
            roomsqueryExpression.ColumnSet = new ColumnSet(true);
            roomsqueryExpression.Criteria.AddCondition(KPMg_Room.Fields.StateCode,ConditionOperator.Equal, (int)KPMg_Room_StateCode.Active);

            #region building check not blocked
            // Create a LinkEntity for the Building relationship
            roomsqueryExpression.LinkEntities.Add(this.getbuildingwithroomlink());
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
                        isactive = true,
                        building = new Models.BuildingModel()
                        {
                            Id = roomEntity.GetAttributeValue<Guid>(KPMg_Room.Fields.Id).ToString(),
                            code = roomEntity.GetAttributeValue<AliasedValue>(buildingalias + "." + KPMg_Building.Fields.KPMg_BuildingCode)?.Value.ToString(),
                            name = roomEntity.GetAttributeValue<AliasedValue>(buildingalias + "." + KPMg_Building.Fields.KPMg_Name)?.Value.ToString(),
                            isactive = true
                        }
                    });
                }
            }

            #region get bookRoom available
            var timeslotArr = await this.timeSlotBLL.getAll();
            TimeSlotDTO firsttimeslot = timeslotArr.OrderBy(n => n.timeid).First();
            TimeSlotDTO lasttimeslot = timeslotArr.OrderBy(n => n.timeid).Last();
            
            foreach (var roomitem in roomsModel) { 
                Dictionary<int,bool> keyValuePairs = new Dictionary<int,bool>();
                foreach (var timesl in timeslotArr) { 
                    keyValuePairs.Add(timesl.timeid, false);
                }
                QueryExpression roomitemBookQuery = new QueryExpression(KPMg_BookRoom.EntityLogicalName);
                roomitemBookQuery.ColumnSet = new ColumnSet(true);
                roomitemBookQuery.Criteria.AddCondition(KPMg_BookRoom.Fields.KPMg_BookedZoneDependent,ConditionOperator.On, dateInput);
                roomitemBookQuery.Criteria.AddCondition(KPMg_BookRoom.Fields.KPMg_Room,ConditionOperator.Equal, roomitem.id);

                
                LinkEntity timeslotLinkFrom = new LinkEntity(KPMg_BookRoom.EntityLogicalName, KPMg_PredefinedTimeSlots.EntityLogicalName, KPMg_BookRoom.Fields.KPMg_From, KPMg_PredefinedTimeSlots.PrimaryIdAttribute, JoinOperator.Inner);
                timeslotLinkFrom.Columns = new ColumnSet(KPMg_PredefinedTimeSlots.Fields.KPMg_TimeId);
                timeslotLinkFrom.EntityAlias = fromtimeslot;
                roomitemBookQuery.LinkEntities.Add(timeslotLinkFrom);

                LinkEntity totimeslotLink = new LinkEntity(KPMg_BookRoom.EntityLogicalName, KPMg_PredefinedTimeSlots.EntityLogicalName, KPMg_BookRoom.Fields.KPMg_To, KPMg_PredefinedTimeSlots.PrimaryIdAttribute, JoinOperator.Inner);
                totimeslotLink.Columns = new ColumnSet(KPMg_PredefinedTimeSlots.Fields.KPMg_TimeId);
                totimeslotLink.EntityAlias = totimeslot;
                roomitemBookQuery.LinkEntities.Add(totimeslotLink);
                var bookroom = await this.organizationService.RetrieveMultipleAsync(roomitemBookQuery);

                foreach (var bookroomitem in bookroom.Entities)
                {
                    int from = Convert.ToInt32(bookroomitem.GetAttributeValue<AliasedValue>($"{fromtimeslot}.{KPMg_PredefinedTimeSlots.Fields.KPMg_TimeId}")?.Value);
                    int to = Convert.ToInt32(bookroomitem.GetAttributeValue<AliasedValue>($"{totimeslot}.{KPMg_PredefinedTimeSlots.Fields.KPMg_TimeId}")?.Value);
                    for (int i = from; i < to; i++)
                        keyValuePairs[i] = true ;
                    if(to == lasttimeslot.timeid)
                        keyValuePairs[to] = true ;
                }
                if (keyValuePairs.ContainsValue(false))
                    result.Add(roomitem);
            }
            #endregion

            return result;
        }

      
        public async Task<RoomModel> getRoom(string id)
        {
            QueryExpression roomsqueryExpression = new QueryExpression(KPMg_Room.EntityLogicalName);
            roomsqueryExpression.ColumnSet = new ColumnSet(true);
            roomsqueryExpression.Criteria.AddCondition(KPMg_Room.Fields.Id, ConditionOperator.Equal, id);

            RoomModel response = new RoomModel();

            var result = await this.organizationService.RetrieveMultipleAsync(roomsqueryExpression);
            if(result != null)
            {
                if (result.Entities.Count > 0)
                {
                    var roomEntity = result.Entities[0];
                    return new RoomModel()
                    {
                        id = roomEntity.Id,
                        code = roomEntity.GetAttributeValue<string>(KPMg_Room.Fields.KPMg_RoomCode),
                        name = roomEntity.GetAttributeValue<string>(KPMg_Room.Fields.KPMg_Name),
                        isactive = true
                    };
                }
            }
            return response;

        }
        public async Task<List<RoomModel>> getAll()
        {
            List<RoomModel> roomsModel = new List<RoomModel>();

            QueryExpression roomsqueryExpression = new QueryExpression(KPMg_Room.EntityLogicalName);
            roomsqueryExpression.ColumnSet = new ColumnSet(true);

            LinkEntity buildingLink = new LinkEntity(KPMg_Room.EntityLogicalName, KPMg_Building.EntityLogicalName, KPMg_Room.Fields.KPMg_Building, KPMg_Building.PrimaryIdAttribute, JoinOperator.Inner);
            buildingLink.Columns = new ColumnSet(KPMg_Building.Fields.KPMg_BuildingCode, KPMg_Building.Fields.StateCode, KPMg_Building.Fields.KPMg_Name);
            buildingLink.EntityAlias = buildingalias;
            roomsqueryExpression.LinkEntities.Add(buildingLink);

            var result = await this.organizationService.RetrieveMultipleAsync(roomsqueryExpression);
            if (result != null && result?.Entities.Count > 0)
            {

                foreach (var roomEntity in result.Entities)
                {
                    roomsModel.Add(new RoomModel()
                    {
                        id = roomEntity.Id,
                        code = roomEntity.GetAttributeValue<string>(KPMg_Room.Fields.KPMg_RoomCode),
                        name = roomEntity.GetAttributeValue<string>(KPMg_Room.Fields.KPMg_Name),
                        isactive = true,
                        building = new Models.BuildingModel()
                        {
                            Id = roomEntity.GetAttributeValue<Guid>(KPMg_Room.Fields.Id).ToString(),
                            code = roomEntity.GetAttributeValue<AliasedValue>(buildingalias + "." + KPMg_Building.Fields.KPMg_BuildingCode)?.Value.ToString(),
                            name = roomEntity.GetAttributeValue<AliasedValue>(buildingalias + "." + KPMg_Building.Fields.KPMg_Name)?.Value.ToString(),
                            isactive = true
                        }
                    });
                }
            }
            return roomsModel;
        }
    }
}
