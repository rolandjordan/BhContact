using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BhContacts.Api.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            // TODO: Log Exception here context context.Exception
            throw context.Exception;
            var result = new ObjectResult(new
            {
                message = "An internal server error occurred."
            })
            {
                StatusCode = 500
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
