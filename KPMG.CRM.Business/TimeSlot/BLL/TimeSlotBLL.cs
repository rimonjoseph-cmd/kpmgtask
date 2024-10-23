
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
                 new TimeSlotDTO {timeid = 17,time = "8:00AM" },
                new TimeSlotDTO { timeid = 18, time =  "8:30AM" },
                new TimeSlotDTO { timeid = 19, time =  "9:00AM" },
                new TimeSlotDTO { timeid = 20, time =  "9:30AM" },
                new TimeSlotDTO { timeid = 21, time =  "10:00AM" },
                new TimeSlotDTO { timeid = 22, time =  "10:30AM" },
                new TimeSlotDTO { timeid = 23, time =  "11:00AM" },
                new TimeSlotDTO { timeid = 24, time =  "11:30AM" },
                new TimeSlotDTO { timeid = 25, time =  "12:00PM" },
                new TimeSlotDTO { timeid = 26, time =  "12:30PM" },
                new TimeSlotDTO { timeid = 27, time =  "1:00PM" },
                new TimeSlotDTO { timeid = 28, time =  "1:30PM" },
                new TimeSlotDTO { timeid = 29, time =  "2:00PM" },
                new TimeSlotDTO { timeid = 30, time =  "2:30PM" },
                new TimeSlotDTO { timeid = 31, time =  "3:00PM" },
                new TimeSlotDTO { timeid = 32, time =  "3:30PM" },
                new TimeSlotDTO { timeid = 33, time =  "4:00PM" },
                new TimeSlotDTO { timeid = 34, time =  "4:30PM" },
                new TimeSlotDTO { timeid = 35, time =  "5:00PM" }
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
                timeSlotEntity["kpmg_timeid"] = timeSlot.timeid;
                timeSlotEntity["kpmg_name"]   = timeSlot.time;

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
                        time = entity.GetAttributeValue<string>("kpmg_name"),
                        timeid = entity.GetAttributeValue<int>("kpmg_timeid"),
                        timeslotid = entity.Id
                    };
                    timeSlotDTOs.Add(timeSlotDTO);
                }
            }

            return timeSlotDTOs;
        }

    }
}
