using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;

namespace OdeToFood.ViewModels
{
    [ModelMetadataType(typeof(Restaurant))]
    public class RestaurantEditModel
    {
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}