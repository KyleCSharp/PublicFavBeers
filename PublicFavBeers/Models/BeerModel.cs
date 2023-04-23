using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace PublicFavBeers.Models
{
    public class BeerModel : Controller
    {
        public int id { get; set; }
        public byte[] Image { get; set; }
        public string BeerName { get; set; }
        public string BreweryName { get; set; }
        public string Description { get; set; }
    }
}
