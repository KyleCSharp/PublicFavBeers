using Microsoft.AspNetCore.Mvc;
using PublicFavBeers.Models;

namespace PublicFavBeers.Interfaces
{
    public interface IBeerRepo
    {
        public IEnumerable<BeerModel> GetAllBeer();
        public void InsertBeer(BeerModel beerToInsert);
        
        
    }
}
