using KPMG.CRM.Business.Building;
using KPMG.CRM.Business.Room.BLL;
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
        public async Task<EntityCollection> Get()
        {
            return await this.buildingBLL.getall();
        }

        // GET api/<BuildingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BuildingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BuildingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BuildingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
