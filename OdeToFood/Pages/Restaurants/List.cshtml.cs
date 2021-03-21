using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } // two way binded

        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        // responds to a HTTP GET request : /Restaurant/List
        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
            logger.LogWarning("Executing ListModel");
        }
    }
}
