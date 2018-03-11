using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OdeToFood.Utils
{
    public static class EnumUtils
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<T>() where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException($"Invalid Enum Type. {typeof(T)} must be an Enum");
            }

            return Enum
                .GetValues(typeof(T))
                .Select<T, SelectListItem>
                (type =>
                    new SelectListItem
                    {
                        Text = type.ToString(),
                        Value = type.ToString().ToLower()
                    }
                );
        }
    }
}