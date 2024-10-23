using KPMG.CRM.Business.BookRoom;
using KPMG.CRM.Business.BookRoom.DTO;
using KPMG.CRM.Business.Building;
using KPMG.CRM.Business.Contact;
using KPMG.CRM.Business.Models;
using KPMG.CRM.Integration.API.Extensions;
using KPMG.CRM.Integration.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KPMG.CRM.Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRoomBLL _bookRoomBLL;
        private IConfiguration _config;
        public BookController(IBookRoomBLL contactBLL, IConfiguration config)
        {
            _bookRoomBLL = contactBLL;
            _config = config;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET: api/<BookController>
        [Authorize]
        [HttpGet("own")]
        public async Task<BaseResponse<List<BookRoomModel>>> Getown()
        {
            var r = HttpContext.User.FindFirst("contactid");

            return new BaseResponse<List<BookRoomModel>> (){
                message = "success retrieve",
                result= true,
                data =  await this._bookRoomBLL.getBookRoomsRelatedToContact(r.Value),
            };
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [HttpPost]
        [Authorize]
        public async Task<BaseResponse<string>> Post([FromBody] CreateBookRoom obj)
        {
            obj.convertedutcbookeddate = DateTime.Parse(obj.bookedDate); //obj.bookedDate.ConvertToUtcDateTime();
            obj.contactid = HttpContext.User.FindFirst("contactid").Value;
            var result = (await this._bookRoomBLL.createBookroom(obj));
            return new BaseResponse<string>()
            {
                result = result.issuccess,
                message = result.message,
                data = result.bookroomid
            };
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
