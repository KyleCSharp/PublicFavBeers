﻿using Microsoft.AspNetCore.Mvc;
using PublicFavBeers.Models;

namespace PublicFavBeers.Interfaces
{
    public interface IBeerRepo
    { 
        public void InsertBeer(BeerModel beerToInsert);
        public IEnumerable<BeerModel> GetAllBeer();
        public BeerModel GetBeerById(int id);
    }
}
