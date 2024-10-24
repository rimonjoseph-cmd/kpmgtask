using KPMG.CRM.Business.BookRoom.DTO;
using KPMG.CRM.Business.Models;
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
using Contacts = KPMG.CRM.DAL.Contact;

namespace KPMG.CRM.Business.BookRoom
{
    public class bookroomresponse
    {
        public bool issuccess {  get; set; }
        public string message { get; set; }
        public string bookroomid { get; set; }
    }
    public class BookRoomBLL : IBookRoomBLL
    {
        private readonly IOrganizationServiceAsync _service;
        string fromtimeslot = "fromtimeslot";
        string totimeslot = "totimeslot";
        public BookRoomBLL(IOrganizationServiceAsync organizationService)
        {
            _service = organizationService;
        }

        public async Task<bookroomresponse> createBookroom(CreateBookRoom obj)
        {
            bookroomresponse bookroomresponse = new bookroomresponse();
            try
            {
                Entity entity = new Entity(KPMg_BookRoom.EntityLogicalName);
                entity[KPMg_BookRoom.Fields.title] = obj.title;
                entity[KPMg_BookRoom.Fields.KPMg_BookedZoneDependent] = obj.convertedutcbookeddate;
                entity[KPMg_BookRoom.Fields.KPMg_Room]       = new EntityReference(KPMg_Room.EntityLogicalName,new Guid(obj.roomid));
                entity[KPMg_BookRoom.Fields.KPMg_Contact]    = new EntityReference(Contacts.EntityLogicalName, new Guid(obj.contactid));
                entity[KPMg_BookRoom.Fields.KPMg_From]       = new EntityReference(KPMg_PredefinedTimeSlots.EntityLogicalName, new Guid(obj.fromid));
                entity[KPMg_BookRoom.Fields.KPMg_To]         = new EntityReference(KPMg_PredefinedTimeSlots.EntityLogicalName, new Guid(obj.toid));
                var id  = await _service.CreateAsync(entity);

                bookroomresponse = new bookroomresponse()
                {
                    message = "Book Room Successfully Booked",
                    issuccess = true,
                    bookroomid = id.ToString()
                };
            }
            catch(Exception ex)
            {
                bookroomresponse=  new bookroomresponse()
                {
                    message = ex.Message,
                    issuccess = false,
                    bookroomid = string.Empty
                };
            }
            
            return bookroomresponse;
            
        }
        private QueryExpression getbookroomQueryExpression()
        {
            QueryExpression queryExpression = new QueryExpression(KPMg_BookRoom.EntityLogicalName);
            queryExpression.ColumnSet = new ColumnSet(true);
            // Add sorting by the "createdon" attribute in descending order
            queryExpression.AddOrder(KPMg_BookRoom.Fields.CreatedOn, OrderType.Descending);

            LinkEntity timeslotLinkFrom = new LinkEntity(KPMg_BookRoom.EntityLogicalName, KPMg_PredefinedTimeSlots.EntityLogicalName, KPMg_BookRoom.Fields.KPMg_From, KPMg_PredefinedTimeSlots.PrimaryIdAttribute, JoinOperator.Inner);
            timeslotLinkFrom.Columns = new ColumnSet(KPMg_PredefinedTimeSlots.Fields.KPMg_Name);
            timeslotLinkFrom.EntityAlias = fromtimeslot;
            queryExpression.LinkEntities.Add(timeslotLinkFrom);
            
            LinkEntity totimeslotLink = new LinkEntity(KPMg_BookRoom.EntityLogicalName, KPMg_PredefinedTimeSlots.EntityLogicalName, KPMg_BookRoom.Fields.KPMg_To, KPMg_PredefinedTimeSlots.PrimaryIdAttribute, JoinOperator.Inner);
            totimeslotLink.Columns = new ColumnSet(KPMg_PredefinedTimeSlots.Fields.KPMg_Name);
            totimeslotLink.EntityAlias = totimeslot;
            queryExpression.LinkEntities.Add(totimeslotLink);
            return queryExpression;
        }
        private async Task<List<BookRoomModel>> retriveBookrooms(QueryExpression queryExpression)
        {
            List<BookRoomModel> bookRoomModels = new List<BookRoomModel>();

            var result = await this._service.RetrieveMultipleAsync(queryExpression);
            if (result != null)
            {
                if (result.Entities.Count > 0)
                {
                    foreach (var bookroomitem in result.Entities)
                    {
                        int from = Convert.ToInt32(bookroomitem.GetAttributeValue<AliasedValue>($"{fromtimeslot}.{KPMg_PredefinedTimeSlots.Fields.KPMg_TimeId}")?.Value);
                        int to = Convert.ToInt32(bookroomitem.GetAttributeValue<AliasedValue>($"{totimeslot}.{KPMg_PredefinedTimeSlots.Fields.KPMg_TimeId}")?.Value);
                        bookRoomModels.Add(new BookRoomModel()
                        {
                            id = bookroomitem.Id.ToString(),
                            name = bookroomitem.GetAttributeValue<string>(KPMg_BookRoom.Fields.KPMg_Name),
                            bookedDate = bookroomitem.GetAttributeValue<DateTime>(KPMg_BookRoom.Fields.KPMg_BookedZoneDependent),
                            from = bookroomitem.GetAttributeValue<AliasedValue>($"{fromtimeslot}.{KPMg_PredefinedTimeSlots.Fields.KPMg_Name}")?.Value?.ToString(),
                            to = bookroomitem.GetAttributeValue<AliasedValue>($"{totimeslot}.{KPMg_PredefinedTimeSlots.Fields.KPMg_Name}")?.Value?.ToString(),
                            room = null
                        });
                    }
                }
            }
            return bookRoomModels;

        }
        public async Task<List<BookRoomModel>> getBookRoomsRelatedToContact(string contactid)
        {
            QueryExpression queryExpression = this.getbookroomQueryExpression();

            queryExpression.Criteria.AddCondition(KPMg_BookRoom.Fields.KPMg_Contact,ConditionOperator.Equal,contactid);
           
            return await this.retriveBookrooms(queryExpression);
        }

        public async Task<List<BookRoomModel>> getAllBookRooms()
        {
            return await this.retriveBookrooms(this.getbookroomQueryExpression());
        }
    }
}
