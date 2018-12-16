using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Filters.Models
{
    public class JsonErrorMessage
    {
        public string Text { get; set; }
        public object Data { get; set; }
        public JsonErrorMessage InnerException { get; set; }
        public IEnumerable<JsonErrorMessage> ModelStateErrors { get; set; }

        public static JsonErrorMessage GetJsonErrorMessage(Exception ex, IStringLocalizer stringLocalizer = null)
        {
            return new JsonErrorMessage
            {
                Text = stringLocalizer == null ? ex.Message : stringLocalizer.GetString(ex.Message, ex.Data),
                Data = ex.Data,
                InnerException = ex.InnerException == null ? null : GetJsonErrorMessage(ex.InnerException)
            };
        }
        public static JsonErrorMessage GetJsonErrorMessage(ModelStateDictionary modelState, IStringLocalizer stringLocalizer = null)
        {
            var modelStateErrors = modelState.SelectMany(keyValuePair => keyValuePair.Value.Errors.Select(err => new JsonErrorMessage
            {
                Text = stringLocalizer == null ? err.ErrorMessage : stringLocalizer.GetString(err.ErrorMessage)
            }));
            return new JsonErrorMessage { ModelStateErrors = modelStateErrors };
        }
    }
}