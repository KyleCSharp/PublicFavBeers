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
        public async Task<IActionResult> Index()
        {
            var beers = _BeerRepo.GetAllBeer();
            return View(beers);
        }
        public IActionResult InsertBeer()
        {
            return View("InsertBeer",new BeerModel());
        }
        public async Task<IActionResult> AddBeer(BeerModel beer)
        {
            var beerInserted = await _BeerRepo.AddBeer(beer);

            if (beerInserted != null)
            {
                return View("ErrorPage");
            }
            return RedirectToAction("Index");
            
        }


    }
}