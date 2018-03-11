using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Extensions;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.Utils;

namespace OdeToFood.Pages.Restaurants
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public EditModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> CuisineTypes => EnumUtils.ToSelectListItems<CuisineType>();

        public IActionResult OnGet(int id)
        {
            Restaurant = _restaurantData.Get(id);

            if (Restaurant == null)
            {
                return RedirectToPage(nameof(IndexModel).ToPageName());
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Restaurant = _restaurantData.Update(Restaurant);
                return RedirectToPage(nameof(DetailsModel).ToPageName(), new { id = Restaurant.Id });
            }
            return Page();
        }
    }
}