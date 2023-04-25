using Microsoft.AspNetCore.Mvc;
using PublicFavBeers.Interfaces;
using PublicFavBeers.Models;

namespace PublicFavBeers.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBeerRepo _BeerRepo;
        public HomeController(IBeerRepo beerRepo)
        { 
            _BeerRepo = beerRepo;
        }
        public IActionResult Index()
        {
            var beers = _BeerRepo.GetAllBeer();
            return View(beers);
        }
        
        [HttpGet]
        public IActionResult Upload()
        {
            var model = new ImageViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Upload(ImageViewModel model)

        {
            if (model == null)
            {
                // handle the null reference exception here
                return BadRequest();
            }
            byte[]? data = null;
            using (var ms = new MemoryStream())
            {
                model.Data.CopyTo(ms);
                data = ms.ToArray();
            }

            var picture = new BeerModel()
            {
                Name = model.Name,
                Image = data,
                id = model.id,
                Description= model.Description,
                BreweryName = model.BreweryName
            };

            _BeerRepo.InsertBeer(picture);

            return RedirectToAction("Index", "Image");
        }




    }
}