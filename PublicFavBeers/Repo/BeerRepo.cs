using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PublicFavBeers.Interfaces;
using PublicFavBeers.Models;
namespace PublicFavBeers.Repo
{
    public class BeerRepo : IBeerRepo
    {
        private readonly IConfig _config;
        public BeerRepo(IConfig config)
        {
            _config = config;
        }
        public IEnumerable<BeerModel> GetAllBeer()
        {
            using var conn = new SqlConnection(_config.GetConnectionString());
            conn.Open();

            return conn.Query<BeerModel>("SELECT * FROM dbo.PublicFavBeer");
        }

        [HttpPost]
        public void InsertBeer(BeerModel beerToInsert)
        {
            using var conn = new SqlConnection(_config.GetConnectionString());
            conn.Open();
            conn.Execute("INSERT INTO dbo.PublicFavBeer (Name, Image, Description, BreweryName) VALUES (@Name, @Image, @Description, @BreweryName);",
                new { beerToInsert.Name, image = beerToInsert.Image, beerToInsert.Description, beerToInsert.BreweryName });
            conn.Close();
        }
    }
}
