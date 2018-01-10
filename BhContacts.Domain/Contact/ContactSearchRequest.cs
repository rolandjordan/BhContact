using System.ComponentModel.DataAnnotations;

namespace BhContacts.Domain.Contact
{
    public class ContactSearchRequest
    {
        [Required(ErrorMessage = "Firstname is a required field")]
        [MaxLength(200, ErrorMessage = "Firstname cannot contain more tha 200 characters")]
        public string FirstName { get; set; }
    }
}
