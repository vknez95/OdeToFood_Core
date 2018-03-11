using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using OdeToFood.Models;

namespace OdeToFood.Binders
{
    public class RestaurantBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Restaurant))
            {
                return new BinderTypeModelBinder(typeof(RestaurantBinder));
            }

            return null;
        }
    }
}