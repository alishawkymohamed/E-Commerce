using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApi.Filters.Models;
using Microsoft.Extensions.Localization;

namespace WebApi.Filters
{
    public class ModelStateValidationFilter: ActionFilterAttribute
    {
        private readonly IStringLocalizer _StringLocalizer;
        public ModelStateValidationFilter(IStringLocalizer stringLocalizer)
        {
            _StringLocalizer = stringLocalizer;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new JsonResult(JsonErrorMessage.GetJsonErrorMessage(context.ModelState, _StringLocalizer));
                context.HttpContext.Response.StatusCode = StatusCodes.Status412PreconditionFailed;
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}
