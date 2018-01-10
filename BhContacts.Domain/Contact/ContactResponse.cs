using System;

namespace BhContacts.Domain.Contact
{
    public class ContactResponse
    {
        public Guid ContactReferenceId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Organization { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
