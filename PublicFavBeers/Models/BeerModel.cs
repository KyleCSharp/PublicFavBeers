using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Reflection;

namespace PublicFavBeers.Models
{
    public class BeerModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
       
        public string Description { get; set; }
        public string BreweryName { get; set; }

        
    }
}
