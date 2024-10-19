
using KPMG.CRM.Business.TimeSlot.DTO;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;

namespace KPMG.CRM.Business.TimeSlot.BLL
{
    public class TimeSlotBLL : ITimeSlotBLL
    {
        private readonly IOrganizationServiceAsync organizationService;

        public TimeSlotBLL(IOrganizationServiceAsync organizationService)
        {
            this.organizationService = organizationService;
        }

        public void createtimeslotconfiguration()
        {
            // Simulated TimeData object with multiple entries
            List< TimeSlotDTO> timeData = new List<TimeSlotDTO>
            {
                 new TimeSlotDTO { TimeId = 17, Time = "8:00AM" },
                new TimeSlotDTO { TimeId = 18, Time =  "8:30AM" },
                new TimeSlotDTO { TimeId = 19, Time =  "9:00AM" },
                new TimeSlotDTO { TimeId = 20, Time =  "9:30AM" },
                new TimeSlotDTO { TimeId = 21, Time =  "10:00AM" },
                new TimeSlotDTO { TimeId = 22, Time =  "10:30AM" },
                new TimeSlotDTO { TimeId = 23, Time =  "11:00AM" },
                new TimeSlotDTO { TimeId = 24, Time =  "11:30AM" },
                new TimeSlotDTO { TimeId = 25, Time =  "12:00PM" },
                new TimeSlotDTO { TimeId = 26, Time =  "12:30PM" },
                new TimeSlotDTO { TimeId = 27, Time =  "1:00PM" },
                new TimeSlotDTO { TimeId = 28, Time =  "1:30PM" },
                new TimeSlotDTO { TimeId = 29, Time =  "2:00PM" },
                new TimeSlotDTO { TimeId = 30, Time =  "2:30PM" },
                new TimeSlotDTO { TimeId = 31, Time =  "3:00PM" },
                new TimeSlotDTO { TimeId = 32, Time =  "3:30PM" },
                new TimeSlotDTO { TimeId = 33, Time =  "4:00PM" },
                new TimeSlotDTO { TimeId = 34, Time =  "4:30PM" },
                new TimeSlotDTO { TimeId = 35, Time =  "5:00PM" }
            };
           
            ExecuteMultipleRequest request = new ExecuteMultipleRequest()
            {
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                Requests = new OrganizationRequestCollection()
            };

            foreach (var timeSlot in timeData)
            {
                Entity timeSlotEntity = new Entity("kpmg_predefinedtimeslots");
                timeSlotEntity["kpmg_timeid"] = timeSlot.TimeId;
                timeSlotEntity["kpmg_name"]   = timeSlot.Time;

                CreateRequest createRequest = new CreateRequest { Target = timeSlotEntity };
                request.Requests.Add(createRequest);
            }

            ExecuteMultipleResponse response = (ExecuteMultipleResponse)organizationService.Execute(request);

            Console.WriteLine("Records created successfully in Dynamics CRM.");
        }

        public async Task<List<TimeSlotDTO>> getAll()
        {
            QueryExpression queryExpression = new QueryExpression("kpmg_predefinedtimeslots");
            queryExpression.ColumnSet = new ColumnSet("kpmg_name", "kpmg_timeid");

            EntityCollection result = await organizationService.RetrieveMultipleAsync(queryExpression);

            List<TimeSlotDTO> timeSlotDTOs = new List<TimeSlotDTO>();

            if (result.Entities != null && result.Entities.Count > 0)
            {
                foreach (var entity in result.Entities)
                {
                    TimeSlotDTO timeSlotDTO = new TimeSlotDTO
                    {
                        Time = entity.GetAttributeValue<string>("kpmg_name"),
                        TimeId = entity.GetAttributeValue<int>("kpmg_timeid"),
                        timeSlotID = entity.Id
                    };
                    timeSlotDTOs.Add(timeSlotDTO);
                }
            }

            return timeSlotDTOs;
        }

    }
}
