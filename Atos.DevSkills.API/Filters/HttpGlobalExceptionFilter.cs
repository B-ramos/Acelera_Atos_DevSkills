using Atos.DevSkills.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Atos.DevSkills.API.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {       
        public void OnException(ExceptionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            ErrorsViewModel errorsViewModel = new ErrorsViewModel($"{context.Exception.Message}");

            response.StatusCode = (int)HttpStatusCode.InternalServerError;           

            if (context.Exception is ArgumentException exception)
            {               
                response.StatusCode = (int)HttpStatusCode.BadRequest;               
            }

            response.ContentType = "application/json";

            context.ExceptionHandled = true;
            context.Result = new ObjectResult(errorsViewModel);
        }
    }
}

