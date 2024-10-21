using KPMG.CRM.Business.Models;
using Contacts = KPMG.CRM.DAL.Contact;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPMG.CRM.Business.Helper;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace KPMG.CRM.Business.Contact
{
    public class ContactBLL : IContactBLL
    {
        private readonly IOrganizationServiceAsync _service;
        public ContactBLL(IOrganizationServiceAsync organizationService)
        {
            _service = organizationService;
        }
        public async Task<ContactModel> createContact(ContactModel createContact)
        {

            string originalText = "SensitiveData123";
            string key = "ThisIsASecretKey";

            string encryptedData = CryptoHelper.EncryptData(originalText, key);
            string decryptedText = CryptoHelper.DecryptData(encryptedData, key);

            // TODO : check email is not exist before
            Entity entity = new Entity(Contacts.EntityLogicalName);
            entity[Contacts.Fields.FirstName] = createContact.firstName;
            entity[Contacts.Fields.LastName] = createContact.lastName;
            entity[Contacts.Fields.EmailAddress1] = createContact.email;
            entity[Contacts.Fields.AdX_Identity_Username] = createContact.username;
            entity[Contacts.Fields.AdX_Identity_PasswordHash] = encryptedData;

            createContact.id = (await this._service.CreateAsync(entity)).ToString();
            return createContact;
        }
    }
}
