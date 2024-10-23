using KPMG.CRM.Business.TimeSlot.BLL;
using KPMG.CRM.Business.TimeSlot.DTO;
using KPMG.CRM.Integration.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KPMG.CRM.Integration.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private readonly ITimeSlotBLL timeSlotBLL;

        public TimeSlotController(ITimeSlotBLL timeSlotBLL)
        {
            this.timeSlotBLL = timeSlotBLL;
        }

        //[Authorize(Policy = "RequireAdminRole,RequireEmployeeRole")]
       // [Authorize(Policy = "RequireEmployeeRole")]
        [HttpGet]
        public async Task<BaseResponse<IEnumerable<TimeSlotDTO>>> Get()
        {
            return new BaseResponse<IEnumerable<TimeSlotDTO>>()
            {
                result = true,
                message = "timeslot retrived successfully",
                data = await this.timeSlotBLL.getAll()
            };
        }

        // GET api/<TimeSlotController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TimeSlotController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            this.timeSlotBLL.createtimeslotconfiguration();
        }

        // PUT api/<TimeSlotController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TimeSlotController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
