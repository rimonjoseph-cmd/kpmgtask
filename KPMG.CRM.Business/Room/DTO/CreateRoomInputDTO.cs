namespace KPMG.CRM.Business.Room.DTO
{
    public class CreateRoomInputDTO
    {
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
        public Guid BuildingId { get; set; }
        public bool IsRoomActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Code { get; set; }

    }
}
