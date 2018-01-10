using System.Collections.Generic;
using BhContacts.Domain.Contact;

namespace BhContacts.DataAccess.Contact
{
    public interface IContactService
    {
        ContactResponse GetContact(ContactReferenceIdRequest request);

        List<ContactResponse> GetContacts();

        ContactResponse UpdateContact(ContactRequest request);

        ContactResponse AddContact(ContactRequest request);

        bool DeleteContact(ContactReferenceIdRequest request);
    }
}
