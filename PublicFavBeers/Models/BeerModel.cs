using Microsoft.AspNetCore.Mvc;

namespace PublicFavBeers.Models
{
    public class BeerModel : Controller
    {
        public string ImageData { get; set; }
        public string ImageName { get; set; }
        public string BeerName { get; set; }
        public string BreweryName { get; set; }
        public string Description { get; set; }
    }
}
