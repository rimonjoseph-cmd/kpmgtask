using KPMG.CRM.Business.Building;
using KPMG.CRM.Business.Models;
using KPMG.CRM.Business.Room.BLL;
using KPMG.CRM.Integration.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Xrm.Sdk;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KPMG.CRM.Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingBLL buildingBLL;

        public BuildingController(IBuildingBLL buildingBLL)
        {
            this.buildingBLL = buildingBLL;
        }
        // GET: api/<BuildingController>
        [HttpGet]
        public async Task<BaseResponse<List<BuildingModel>>> Get()
        {
            return new BaseResponse<List<BuildingModel>>()
            {
                data = await this.buildingBLL.getall(),
                result = true,
                message = "Success"
            };
        }

        // GET api/<BuildingController>/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<BuildingModel>> Get(string id)
        {
            return new BaseResponse<BuildingModel>()
            {
                data = await this.buildingBLL.get(id),
                result = true,
                message = "Success"
            };
        }

        // POST api/<BuildingController>
        [HttpPost]
        public async Task<BaseResponse<BuildingModel>> Post([FromBody] BuildingModel value)
        {

            return new BaseResponse<BuildingModel>()
            {
                data = await this.buildingBLL.createBuilding(value),
                result = true,
                message = "Success"
            };
        }

        // POST api/<BuildingController>
        [HttpPost("block/{buildingid}")]
        public string blockBuilding(Guid buildingid)
        {
            return this.buildingBLL.Block(buildingid) ? "building blocked successfully" : "no action taken";
        }

        // POST api/<BuildingController>
        [HttpPost("unblock/{buildingid}")]
        public string unblockBuilding(Guid buildingid)
        {
            return this.buildingBLL.UnBlock(buildingid) ? "building activated successfully" : "no action taken";
        }

        // PUT api/<BuildingController>/5
        [HttpPut("{id}")]
        public async Task<BaseResponse<BuildingModel>> Put(string id, [FromBody] BuildingModel value)
        {
            return new BaseResponse<BuildingModel>()
            {
                data = await this.buildingBLL.updateBuilding(id, value),
                result = true,
                message = "Success update Building"
            };
        }

        // DELETE api/<BuildingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
