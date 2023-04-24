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

        public BeerModel GetBeerById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task InsertBeer(BeerModel beerToInsert)
        {
            //byte[] data = null;
            //using (var ms = new MemoryStream())
            //{
            //    await beerToInsert.Data.CopyToAsync(ms);
            //    data = ms.ToArray();
            //}

            //var picture = new BeerModel()
            //{
            //    Image = data
            //};

            using var conn = new SqlConnection(_config.GetConnectionString());
            conn.Open();
            conn.Execute("INSERT INTO dbo.PublicFavBeer (Name, Image, Description, BreweryName) VALUES (@Name, @Image, @Description, @BreweryName);",
                new { beerToInsert.Name, beerToInsert.Image, beerToInsert.Description, beerToInsert.BreweryName });
            conn.Close();
        }

    }
}
