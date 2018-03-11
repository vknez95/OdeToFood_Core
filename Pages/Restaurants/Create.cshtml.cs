using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Binders;
using OdeToFood.Extensions;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.Utils;
using OdeToFood.ViewModels;

namespace OdeToFood.Pages.Restaurants
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public CreateModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        [BindProperty]
        public RestaurantEditModel Restaurant { get; set; }
        public IEnumerable<SelectListItem> CuisineTypes => EnumUtils.ToSelectListItems<CuisineType>();

        public IActionResult OnGet()
        {
            return Page();
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newRestaurant = new Restaurant
            {
                Name = Restaurant.Name,
                Cuisine = Restaurant.Cuisine
            };
            newRestaurant = _restaurantData.Add(newRestaurant);

            return RedirectToPage(nameof(DetailsModel).ToPageName(), new { id = newRestaurant.Id });
        }
    }
}
