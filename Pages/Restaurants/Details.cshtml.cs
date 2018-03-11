using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Binders;
using OdeToFood.Extensions;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public DetailsModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public Restaurant Restaurant { get; private set; }

        public IActionResult OnGet([ModelBinder(Name = "id", BinderType = typeof(RestaurantBinder))]
                                   Restaurant restaurant)
        {
            if (restaurant == null)
            {
                return RedirectToPage($"/{nameof(IndexModel).ToPageName()}");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToPage($"/{nameof(IndexModel).ToPageName()}");
            }

            Restaurant = restaurant;
            return Page();
        }
    }
}
