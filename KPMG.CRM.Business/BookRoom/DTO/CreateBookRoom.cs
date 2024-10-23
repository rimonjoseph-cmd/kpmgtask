using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.BookRoom.DTO
{
    public class CreateBookRoom
    {
        public string title { get; set; }
        public string roomid { get; set; }
        public string fromid { get; set; }
        public string toid { get; set; }
        public string bookedDate { get; set; }
        public DateTime convertedutcbookeddate { get; set; }
        public string contactid { get; set; }
    }
}
