using System;
using System.Collections.Generic;
using System.Linq;
using BhContacts.DataAccess.Internal.DbConnector;
using BhContacts.Domain.Contact;

namespace BhContacts.DataAccess.Contact
{
    public class ContactService : IContactService
    {
        public ContactResponse GetContact(ContactReferenceIdRequest request)
        {
            return DataConnection.GetData<ContactReferenceIdRequest, ContactResponse>("dbo.up_GetContact", request).FirstOrDefault();
        }

        public List<ContactResponse> GetContacts()
        {
            return DataConnection.GetData<ContactResponse>("dbo.up_GetContacts").ToList();
        }

        public ContactResponse UpdateContact(ContactRequest request)
        {
            return DataConnection.GetData<ContactRequest, ContactResponse>("dbo.up_UpdateContact", request).FirstOrDefault();
        }

        public ContactResponse AddContact(ContactRequest request)
        {
            request.ContactReferenceId = Guid.NewGuid();
            return DataConnection.GetData<ContactRequest, ContactResponse>("dbo.up_AddContact", request).FirstOrDefault();
        }

        public bool DeleteContact(ContactReferenceIdRequest request)
        {
            DataConnection.GetData<ContactReferenceIdRequest, ContactResponse>("dbo.up_DeleteContact", request);
            return true;
        }
    }
}
