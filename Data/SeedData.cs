using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Data
{
    public static class SeedData
    {
        public static void Initialize(OdeToFoodDbContext context)
        {
            // Look for any movies.
            if (context.Restaurants.Any())
            {
                return;   // DB has been seeded
            }

            context.Restaurants.AddRange(
                new Restaurant { Name = "Scott's Pizza Place", Cuisine = CuisineType.French },
                new Restaurant { Name = "Tersiguels", Cuisine = CuisineType.Italian },
                new Restaurant { Name = "King's Contrivance", Cuisine = CuisineType.German }
            );

            context.SaveChanges();
        }
    }
}