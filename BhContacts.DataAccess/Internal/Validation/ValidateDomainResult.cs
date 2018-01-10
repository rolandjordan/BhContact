using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BhContacts.DataAccess.Internal.CustomException;

namespace BhContacts.DataAccess.Internal.Validation
{
    internal static class ValidateDomainResult
    {
        public static bool IsValid<TRequest>(this TRequest domain)
        {
            var validationResults = new List<ValidationResult>();
            var vc = new ValidationContext(domain, null, null);

            if (!Validator.TryValidateObject(domain, vc, validationResults, true))
            {
                throw new DataResultException(validationResults);
            }

            return true;
        }
    }
}
