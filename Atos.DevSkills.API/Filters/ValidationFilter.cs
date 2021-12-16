using Atos.DevSkills.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Atos.DevSkills.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var erros = new ErrorsViewModel(context.ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList());

                context.Result = new BadRequestObjectResult(erros);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }        
    }
}
