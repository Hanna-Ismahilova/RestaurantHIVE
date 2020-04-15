using RestaurantHIVE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RestaurantHIVE.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurants();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "Viking", Location = "Norway", Cuisine = CuisineType.Norvegian},
                new Restaurant{Id = 2, Name = "Mona", Location = "France", Cuisine = CuisineType.French},
                new Restaurant{Id = 3, Name = "Бочка", Location = "Russia", Cuisine = CuisineType.Russian}
            };

        }
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return from rest in restaurants
                   orderby rest.Name
                   select rest;
        }
    }
}
