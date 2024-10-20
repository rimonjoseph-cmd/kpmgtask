using KPMG.CRM.DAL;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Building
{
    public class BuildingBLL : IBuildingBLL
    {
        private readonly IOrganizationServiceAsync _service;
        public BuildingBLL(IOrganizationServiceAsync organizationService) {
            _service = organizationService;
        }
        private bool changestatus(int statusValue, int statusReasonValue, Guid buildingid)
        {
            try
            {
                EntityReference entityRef = new EntityReference(KPMg_Building.EntityLogicalName, buildingid);

                SetStateRequest setStateRequest = new SetStateRequest
                {
                    EntityMoniker = entityRef,
                    State = new OptionSetValue(statusValue),
                    Status = new OptionSetValue(statusReasonValue)
                };

                // Execute the request to change the status of the record
                _service.Execute(setStateRequest);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Block(Guid buildingid)
        {
            return this.changestatus(1, 736630002,buildingid);
        }

        public async Task<EntityCollection> getall()
        {
            QueryExpression query = new QueryExpression(KPMg_Building.EntityLogicalName);
            query.ColumnSet = new ColumnSet(true);
            return await _service.RetrieveMultipleAsync(query);
        }

        public bool UnBlock(Guid buildingid)
        {
            return this.changestatus(0, 1, buildingid);

        }
    }
}
