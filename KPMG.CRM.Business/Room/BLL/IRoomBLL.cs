
using KPMG.CRM.Business.Room.DTO;

namespace KPMG.CRM.Business.Room.BLL
{
    public  interface IRoomBLL
    {
        Task<Guid> createRoom(CreateRoomInputDTO createRoomInput);
        Task<List<RoomModel>> getAvailable(DateTime dateInput);
        Task<RoomModel> getRoom(string id);
    }
}
