﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using RestaurantHIVE.Data;
using RestaurantHIVE.Models;

namespace RestaurantHIVE
{
    public class ListModel : PageModel
    {
        //private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public string Environment { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(//IConfiguration configuration, 
                         IRestaurantData restaurantData)
        {
            //this.configuration = configuration;
            this.restaurantData = restaurantData;
        }

        public void OnGet(string searchTerm)
        {
            
            //Environment = configuration["Environment"];
            //Message = "Hello in my HIVE restaurant! This is message from the .cs file. ";
            Restaurants = restaurantData.GetRestaurantsByName(searchTerm);
        }
    }
}