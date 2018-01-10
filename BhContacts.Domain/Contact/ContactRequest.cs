using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BhContacts.Domain.Contact
{
    public class ContactRequest
    {
        [JsonIgnore]
        [Required(ErrorMessage = "Contact Reference ID is required")]
        public Guid ContactReferenceId { get; set; }

        [Required(ErrorMessage = "Firstname is a required field")]
        [MaxLength(200, ErrorMessage = "Firstname cannot contain more tha 200 characters")]
        public string FirstName { get; set; }

        [MaxLength(200, ErrorMessage = "Lastname cannot contain more tha 200 characters")]
        public string LastName { get; set; }

        [MaxLength(200, ErrorMessage = "Organization cannot contain more tha 200 characters")]
        public string Organization { get; set; }

        [MaxLength(200, ErrorMessage = "Email cannot contain more tha 200 characters")]
        [EmailAddress(ErrorMessage = "Not a valide Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is a required field")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Please provide a valide phone number")]
        public string PhoneNumber { get; set; }
    }
}
