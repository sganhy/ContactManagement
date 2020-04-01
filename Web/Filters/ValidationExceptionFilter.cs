using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ContactManagement.ApplicationCore.Exceptions;
using ContactManagement.Web.Models;

namespace ContactManagement.Web.Filters
{
    public class ValidationExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IMapper _mapper;

        public ValidationExceptionFilter()
        {
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException e)
            {
                var viewModel = _mapper.Map<ValidationViewModel>(e.Result);
                context.Result = new BadRequestObjectResult(viewModel);
            }
        }
    }

}
