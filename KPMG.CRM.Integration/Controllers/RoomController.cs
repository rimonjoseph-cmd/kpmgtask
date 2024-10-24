using KPMG.CRM.Business.Room.BLL;
using KPMG.CRM.Business.Room.DTO;
using KPMG.CRM.Integration.API.Extensions;
using KPMG.CRM.Integration.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpGet]
        public async Task<BaseResponse<List<RoomModel>>> Get()
        {
            return new BaseResponse<List<RoomModel>>()
            {
                message = "success retrieve",
                result = true,
                data = await this.roomBLL.getAll()
            };
        }

        [HttpGet("getavailable")]
        public async Task<BaseResponse<List<RoomModel>>> GetAvailable(string bookedDate)
        {
            DateTime dateTime = DateTime.Parse(bookedDate);// bookedDate.ConvertToUtcDateTime();
            return new BaseResponse<List<RoomModel>>()
            {
                message = "success retrieve",
                result = true,
                data = await this.roomBLL.getAvailable(dateTime)
            };
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<RoomModel>> Get(string id)
        {
            return new BaseResponse<RoomModel>()
            {
                data = await this.roomBLL.getRoom(id),
                message = "success",
                result = true
            };
        }

        [HttpPost]
        public async Task<Guid> Post([FromBody] CreateRoomInputDTO createRoomInput)
        {
           return await this.roomBLL.createRoom(createRoomInput);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
