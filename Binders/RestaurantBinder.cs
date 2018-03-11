using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OdeToFood.Services;

namespace OdeToFood.Binders
{
    public class RestaurantBinder : IModelBinder
    {
        private readonly IRestaurantData _restaurantData;
        public RestaurantBinder(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.BinderModelName ?? "id";
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            int id = 0;
            if (!int.TryParse(value, out id))
            {
                bindingContext.ModelState
                              .TryAddModelError(modelName, "Restaurant Id must be an integer.");
                return Task.CompletedTask;
            }

            var result = _restaurantData.Get(id);
            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }
    }
}