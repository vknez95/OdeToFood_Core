using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IGreeter _greeter;

        public IndexModel(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IEnumerable<Restaurant> Restaurants => _restaurantData.GetAll();
        public String CurrentMessage => _greeter.GetMessageOfTheDay();

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
