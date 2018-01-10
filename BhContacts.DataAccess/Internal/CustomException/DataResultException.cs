using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace BhContacts.DataAccess.Internal.CustomException
{
    public class DataResultException : Exception
    {
        public ValidationResult[] ValidationResults { get; set; }

        public DataResultException(List<ValidationResult> results)
        {
            ValidationResults = results.ToArray();
        }
        public DataResultException(string message) : base(message) { }

        public DataResultException(string message, Exception innerException) : base(message, innerException) { }

        public DataResultException(string message, IEnumerable<ValidationResult> results) : base(message, null)
        {
            ValidationResults = results.ToArray();
        }

        // This constructor is needed for serialization.
        protected DataResultException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
