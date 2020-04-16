using RestaurantHIVE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RestaurantHIVE.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
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
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from rest in restaurants
                   where string.IsNullOrEmpty(name) || rest.Name.StartsWith(name)
                   orderby rest.Name
                   select rest;
        }
    }
}
