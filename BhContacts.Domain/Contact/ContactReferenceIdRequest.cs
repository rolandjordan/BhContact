using System;
using System.ComponentModel.DataAnnotations;

namespace BhContacts.Domain.Contact
{
    public class ContactReferenceIdRequest
    {
        [Required(ErrorMessage = "Contact Reference ID is required")]
        public Guid ContactReferenceId { get; set; }
    }
}
