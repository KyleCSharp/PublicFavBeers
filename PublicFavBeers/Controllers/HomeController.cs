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
        public IActionResult InsertBeer()
        {
            return View("BeerViews/InsertBeer", new BeerModel());
        }
        [HttpPost]
        public IActionResult InsertBeerToDataBase(BeerModel beerToInsert)
        {
            _BeerRepo.InsertBeer(beerToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult viewBeer (int id)
        {
            var beer = _BeerRepo.GetBeerById(id);
            return View(beer);
        }
        [HttpGet]
        public IActionResult Upload()
        {
            var model = new BeerModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Upload(BeerModel model)
        {
            byte[]? data = null;
            using (var ms = new MemoryStream())
            {
                model.Data.CopyToAsync(ms);
                data = ms.ToArray();
            }

            var picture = new BeerModel()
            {
               
                Image = data
            };

            _BeerRepo.InsertBeer(picture);

            return RedirectToAction("Index", "Image");
        }




    }
}