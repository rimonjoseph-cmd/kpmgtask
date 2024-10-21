using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpmg.CRM.BookRoom.Plugins
{
    public class ValidateBuildingCreation : IPlugin
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
               
                    Entity entityRoom = (Entity)context.InputParameters["Target"];

                    if (entityRoom.Contains("kpmg_buildingcode"))
                    {
                        string buildingCode = entityRoom.GetAttributeValue<string>("kpmg_buildingcode");
                        if (string.IsNullOrEmpty(buildingCode)) {
                            throw new InvalidPluginExecutionException("Buidling Code can not be Empty or null");
                        }
                        QueryExpression queryExpression = new QueryExpression("kpmg_building");
                        queryExpression.ColumnSet = new ColumnSet(false);
                        queryExpression.Criteria.AddCondition("kpmg_buildingcode", ConditionOperator.Equal, buildingCode);
                        var result = service.RetrieveMultiple(queryExpression);
                        if (result != null) {
                            if (result.Entities.Count > 0) {
                                throw new InvalidPluginExecutionException("Building Code Already Exist");
                            }
                        }
                    }
                    else {
                        throw new InvalidPluginExecutionException("Buidling Code can not be Empty or null");
                    }
                }


            }
        }
}
