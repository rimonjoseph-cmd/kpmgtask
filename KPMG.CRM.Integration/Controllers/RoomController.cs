using KPMG.CRM.Business.Room.BLL;
using KPMG.CRM.Business.Room.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KPMG.CRM.Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomBLL roomBLL;

        public RoomController(IRoomBLL roomBLL) {
            this.roomBLL = roomBLL;
        }
        // GET: api/<RoomController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
       
        [HttpGet("getavailable")]
        public async Task<List<RoomModel>> GetAvailable(string bookedDate)
        {
            DateTime f = DateTime.Parse(bookedDate);
            return await this.roomBLL.getAvailable(f);
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoomController>
        [HttpPost]
        public async Task<Guid> Post([FromBody] CreateRoomInputDTO createRoomInput)
        {
           return await this.roomBLL.createRoom(createRoomInput);
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
