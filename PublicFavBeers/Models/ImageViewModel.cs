namespace PublicFavBeers.Models
{
    public class ImageViewModel
    { 
        public int id { get; set; }
        public string Name { get; set; }
        public IFormFile? Data { get; set; }
        public string Description { get; set; }
        public string BreweryName { get; set; }
    }
}
