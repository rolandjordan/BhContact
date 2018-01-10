using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BhContacts.DataAccess.Contact;
using BhContacts.Domain.Contact;

namespace BhContacts.Api.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("api/contacts/get-all-contacts")]
        public List<ContactResponse> GetContacts()
        {
            return _contactService.GetContacts();
        }

        [HttpGet("api/contacts/get-contact/{id:guid}")]
        public ContactResponse GetContact(Guid id)
        {
            return _contactService.GetContact(new ContactReferenceIdRequest
            {
                ContactReferenceId = id
            });
        }

        [HttpPost("api/contacts/add-contact")]
        public ContactResponse AddContact([FromBody]ContactRequest request)
        {
            return _contactService.AddContact(request);
        }

        [HttpPut("api/contacts/update-contact/{id:guid}")]
        public ContactResponse UpdateContact([FromBody]ContactRequest request, Guid id)
        {
            request.ContactReferenceId = id;
            return _contactService.UpdateContact(request);
        }

        [HttpDelete("api/contacts/delete-contact/{id:guid}")]
        public bool DeleteContact(Guid id)
        {
            return _contactService.DeleteContact(new ContactReferenceIdRequest
            {
                ContactReferenceId = id
            });
        }
    }
}
