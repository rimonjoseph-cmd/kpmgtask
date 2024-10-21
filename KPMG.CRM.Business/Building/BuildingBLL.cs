using KPMG.CRM.Business.Models;
using KPMG.CRM.DAL;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public async Task<List<BuildingModel>> getall()
        {
            QueryExpression query = new QueryExpression(KPMg_Building.EntityLogicalName);
            query.ColumnSet = new ColumnSet(true);
            var result =  await _service.RetrieveMultipleAsync(query);
            List<BuildingModel> response = new List<BuildingModel>();
            if (result.Entities != null)
            {
                foreach (var entity in result.Entities)
                {
                    int active             = entity.GetAttributeValue<OptionSetValue>(KPMg_Building.Fields.StateCode).Value;
                    int activestatusreason = entity.GetAttributeValue<OptionSetValue>(KPMg_Building.Fields.StatusCode).Value;
                    BuildingModel model = new BuildingModel() {
                        Id = entity.Id.ToString(),
                        name = entity.GetAttributeValue<string>(KPMg_Building.Fields.KPMg_Name),
                        code = entity.GetAttributeValue<string>(KPMg_Building.Fields.KPMg_BuildingCode),
                        isactive = active == 0 ? true: false,
                        isblocked = activestatusreason == 736630002 ? true : false
                    };
                    response.Add(model);
                }
            }
            return response;
        }

        public bool UnBlock(Guid buildingid)
        {
            return this.changestatus(0, 1, buildingid);

        }

        public async Task<BuildingModel> createBuilding(BuildingModel obj)
        {
            try
            {
                KPMg_Building building = new KPMg_Building();
                building.KPMg_Name = obj.name;
                building.KPMg_BuildingCode = obj.code;
                obj.Id = (await this._service.CreateAsync(building)).ToString();

                if(obj.isactive == false)
                {
                    this.Block(new Guid (obj.Id));
                }
                return obj;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BuildingModel> get(string id)
        {
            var entity = await this._service.RetrieveAsync(KPMg_Building.EntityLogicalName, new Guid(id), new ColumnSet(true));
            int active = entity.GetAttributeValue<OptionSetValue>(KPMg_Building.Fields.StateCode).Value;
            int activestatusreason = entity.GetAttributeValue<OptionSetValue>(KPMg_Building.Fields.StatusCode).Value;
            return  new BuildingModel()
            {
                Id = entity.Id.ToString(),
                name = entity.GetAttributeValue<string>(KPMg_Building.Fields.KPMg_Name),
                code = entity.GetAttributeValue<string>(KPMg_Building.Fields.KPMg_BuildingCode),
                isactive = active == 0 ? true : false,
                isblocked = activestatusreason == 736630002 ? true : false
            };
        }

        public async Task<BuildingModel> updateBuilding(string id, BuildingModel value)
        {
            Entity entity = new Entity(KPMg_Building.EntityLogicalName);
            entity[KPMg_Building.Fields.KPMg_Name] = value.name;
            entity.Id = new Guid(value.Id);
            await this._service.UpdateAsync(entity);
            if (value.isactive)
                this.UnBlock(entity.Id);
            else this.Block(entity.Id);

            return value;
        }
    }
}
