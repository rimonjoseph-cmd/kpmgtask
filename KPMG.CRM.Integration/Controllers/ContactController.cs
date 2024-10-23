using KPMG.CRM.Business.Building;
using KPMG.CRM.Business.Contact;
using KPMG.CRM.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Xrm.Sdk;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using ClaimTypes = System.Security.Claims.ClaimTypes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using KPMG.CRM.Integration.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KPMG.CRM.Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactBLL _contactBLL;
        private IConfiguration _config;
        public ContactController(IContactBLL contactBLL, IConfiguration config)
        {
            _contactBLL = contactBLL;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            ContactModel getContactCRM = await this._contactBLL.checklogin(loginRequest.username, loginRequest.password);
            if(getContactCRM == null)
            {
                Unauthorized(new BaseResponse<string>()
                {
                    result = false,
                    message = "unauthorized",
                    data = ""
                });
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginRequest.username),
                    new Claim("contactid", getContactCRM.id.ToString() ),
                    new Claim(ClaimTypes.Role, getContactCRM.role)
                };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Issuer"],
                Expires = DateTime.Now.AddMinutes(120),
                SigningCredentials = credentials
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var tokenString = jwtTokenHandler.WriteToken(token);

            return Ok(new BaseResponse<string>()
            {
                result = true,
                message = "login successfully",
                data = tokenString
            });
        }
        // GET: api/<ContactController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<BaseResponse<ContactModel>> Post([FromBody] ContactModel createContact)
        {
            return new BaseResponse<ContactModel>()
            {
                result = true,
                message = "Contact Registered Successfully",
                data = await this._contactBLL.createContact(createContact)
            };
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       
        public class LoginRequest
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}
