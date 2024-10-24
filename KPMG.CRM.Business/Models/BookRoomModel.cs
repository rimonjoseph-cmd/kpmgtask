
namespace KPMG.CRM.Business.Models
{
    public  class BookRoomModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public RoomBookModel room { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public DateTime bookedDate { get; set; }
        public string contactName { get; set; }
    }
    public class RoomBookModel
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
