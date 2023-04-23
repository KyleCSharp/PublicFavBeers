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
        public IActionResult InsertBeerToDataBase(BeerModel beer)
        {
            _BeerRepo.InsertBeer(beer);
            return RedirectToAction("Index");
           
        }
        public IActionResult viewBeer (int id)
        {
            var beer = _BeerRepo.GetBeerById(id);
            return View(beer);
        }
        


    }
}