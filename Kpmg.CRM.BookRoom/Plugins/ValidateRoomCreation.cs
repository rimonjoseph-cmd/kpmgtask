﻿using Kpmg.CRM.BookRooms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kpmg.CRM.BookRoom.Plugins
{
    public class ValidateRoomCreation : IPlugin
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

                try
                {
                    if (entityRoom.LogicalName == "kpmg_room")
                    {
                        Entity entityBuilding = service.Retrieve("kpmg_building",
                        entityRoom.GetAttributeValue<EntityReference>("kpmg_building").Id, new ColumnSet("kpmg_buildingcode"));

                        string roomcode = entityRoom.GetAttributeValue<string>("kpmg_roomcode");
                        string buildingCode = entityBuilding.GetAttributeValue<string>("kpmg_buildingcode");
                        string autoGeneratedRoomCode = entityBuilding.GetAttributeValue<string>("kpmg_buildingcode").Trim() + "-" + roomcode.Trim();
                        // kpmg_generatedcode
                        QueryExpression queryroomCodeAlreadyExist = new QueryExpression("kpmg_room")
                        {
                            ColumnSet = new ColumnSet(false),
                            Criteria =
                                {
                                    Conditions =
                                    {
                                        new ConditionExpression("kpmg_generatedcode", ConditionOperator.Equal, autoGeneratedRoomCode)
                                    }
                                }
                        };
                        var existingrooms = service.RetrieveMultiple(queryroomCodeAlreadyExist);

                        if (existingrooms?.Entities.Count > 0)
                        {
                            throw new InvalidPluginExecutionException("building with room codes is already exist");
                        }

                        entityRoom["kpmg_generatedcode"] = autoGeneratedRoomCode;
                    }
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in book room.", ex);
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
