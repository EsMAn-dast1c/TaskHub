using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Attributes;

public sealed class FromRouteTaskIdAttribute : ModelBinderAttribute
{
    public FromRouteTaskIdAttribute() : base(typeof(FromRouteTaskIdBinder))
    {
    }

    private sealed class FromRouteTaskIdBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ActionContext.RouteData.Values["id"]?.ToString();

            if (string.IsNullOrWhiteSpace(value))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName,
                    "Идентификатор задачи не задан");
                return Task.CompletedTask;
            }

            if (!Guid.TryParse(value, out var guid))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName,
                    "Идентификатор задачи имеет некорректный формат");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(guid);
            return Task.CompletedTask;
        }
    }
}