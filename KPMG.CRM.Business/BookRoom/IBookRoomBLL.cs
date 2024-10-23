using KPMG.CRM.Business.BookRoom.DTO;
using KPMG.CRM.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.BookRoom
{
    public interface IBookRoomBLL
    {
        Task<bookroomresponse> createBookroom(CreateBookRoom obj);
        Task<List<BookRoomModel>> getBookRoomsRelatedToContact(string contactid);
    }
}