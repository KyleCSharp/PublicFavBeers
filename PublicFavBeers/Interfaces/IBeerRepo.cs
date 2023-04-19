using Microsoft.AspNetCore.Mvc;
using PublicFavBeers.Models;

namespace PublicFavBeers.Interfaces
{
    public interface IBeerRepo
    { 
        public Task<string> AddBeer(BeerModel beer);
        public IEnumerable<BeerModel> GetAllBeer();
    }
}
