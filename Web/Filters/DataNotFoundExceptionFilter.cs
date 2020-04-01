using ContactManagement.ApplicationCore.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ContactManagement.Web.Filters
{
    public class DataNotFoundExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is DataNotFoundException) context.Result = new StatusCodeResult(404);
        }
    }
}
