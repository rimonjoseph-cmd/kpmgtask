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
using System.Security.Cryptography.Xml;
using Microsoft.Xrm.Sdk.Query;

namespace KPMG.CRM.Business.Contact
{
    enum contactRoleEnum
    {
        admin = 0,
        employee = 1,
        cleaningstaff = 2
    }
    public class ContactBLL : IContactBLL
    {
        private readonly string originalText = "SensitiveData123";
        private readonly string key = "ThisIsASecretKey";
        private readonly IOrganizationServiceAsync _service;
        public ContactBLL(IOrganizationServiceAsync organizationService)
        {
            _service = organizationService;
        }
        public async Task<ContactModel> createContact(ContactModel createContact)
        {
            string encryptedData = createContact.paswword;// CryptoHelper.ComputeHash(originalText, key);

            // TODO : check email is not exist before
            Entity entity = new Entity(Contacts.EntityLogicalName);
            entity[Contacts.Fields.FirstName] = createContact.firstName;
            entity[Contacts.Fields.LastName] = createContact.lastName;
            entity[Contacts.Fields.EmailAddress1] = createContact.email;
            entity[Contacts.Fields.AdX_Identity_Username] = createContact.username;
            //entity[Contacts.Fields.AdX_Identity_PasswordHash] = encryptedData;
            entity[Contacts.Fields.JobTitle] = encryptedData;

            createContact.id = (await this._service.CreateAsync(entity)).ToString();
            createContact.paswword = null;
            return createContact;
        }
        private  string GetroleName(int colorValue)
        {
            if (Enum.IsDefined(typeof(contactRoleEnum), colorValue))
            {
                contactRoleEnum color = (contactRoleEnum)colorValue;
                return Enum.GetName(typeof(contactRoleEnum), color);
            }

            return "Invalid color value";
        }
        public async Task<ContactModel> checklogin(string username, string password)
        {
            QueryExpression getcontact = new QueryExpression(Contacts.EntityLogicalName);
            getcontact.ColumnSet = new ColumnSet(true);
            getcontact.Criteria.AddCondition(Contacts.Fields.AdX_Identity_Username, ConditionOperator.Equal, username);
            var resultContact = await this._service.RetrieveMultipleAsync(getcontact);
            if (resultContact != null)
            {
               if(resultContact.Entities.Count > 0)
                {
                    var con = resultContact.Entities.First();
                   // string crmpass = con.GetAttributeValue<string>(Contacts.Fields.AdX_Identity_PasswordHash);
                    string crmpass = con.GetAttributeValue<string>(Contacts.Fields.JobTitle);
                    string decryptedText = CryptoHelper.ComputeHash(password, key);
                    //if (decryptedText == crmpass) {
                    if (password == crmpass) {
                        int contactrole = con.Contains(Contacts.Fields.contactrole) ?
                            con.GetAttributeValue<OptionSetValue>(Contacts.Fields.contactrole).Value : (int)contactRoleEnum.employee;
                        return new ContactModel
                        {
                            id = con.Id.ToString(),
                            email = con.GetAttributeValue<string>(Contacts.Fields.EmailAddress1),
                            role = this.GetroleName(contactrole),
                            username = con.GetAttributeValue<string>(Contacts.Fields.AdX_Identity_Username)
                        };
                    }
                    else
                    {
                        throw new Exception("user is not registered or username and password is not correct");
                    }
                }

                }
                else
                {
                    throw new Exception("user is not registered or username and password is not correct");
                }
            return null;
            }

        }
    }

