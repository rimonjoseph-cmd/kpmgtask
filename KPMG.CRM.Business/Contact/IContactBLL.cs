using KPMG.CRM.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Contact
{
    public interface IContactBLL
    {
        Task<ContactModel> createContact(ContactModel createContact);
        Task<ContactModel> checklogin(string username, string password);
    }
}
