using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Kpmg.CRM.BookRooms;
using Microsoft.Xrm.Sdk.Query;
namespace Kpmg.CRM.BookRoom.Plugins
{
    public class ValidateBookRoomPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the tracing service
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Obtain the organization service
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            // The InputParameters collection contains all the data passed in the message request.   
            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parameters.  
                Entity entityBookRoom = (Entity)context.InputParameters["Target"];

                try
                {
                    var roomId = entityBookRoom.GetAttributeValue<EntityReference>("kpmg_room"); 
                    var bookingDate = entityBookRoom.GetAttributeValue<DateTime>("kpmg_bookedzonedependent"); 
                    if(service == null)
                    {
                        throw new InvalidPluginExecutionException("service is null");
                    }
                    new BookRoomClass(service).validateifBookedExistBefore(service,bookingDate,roomId,entityBookRoom);
                }

                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in book room."+ ex.Message);
                }

                catch (Exception ex)
                {
                    tracingService.Trace("Book Room: {0}", ex.ToString());
                    throw;
                }
            }
        }
    }
}
