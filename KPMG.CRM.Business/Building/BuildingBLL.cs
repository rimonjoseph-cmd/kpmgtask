using KPMG.CRM.DAL;
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

        public async Task<EntityCollection> getall()
        {
            QueryExpression query = new QueryExpression(KPMg_Building.EntityLogicalName);
            query.ColumnSet = new ColumnSet(true);
            return await _service.RetrieveMultipleAsync(query);
        }

        public void testbuildingbll()
        {
        }
    }
}
