using Dapper;
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

        public void InsertBeer(BeerModel beerToInsert)
        {
            using var conn = new SqlConnection(_config.GetConnectionString());
            conn.Open();
            conn.Execute("(INSERT INTO dbo.PublicFavBeer (ID,Name,Image, Description, BreweryName ) VALUES (@ID, @Name, @Image, @Description, @BreweryName);",
                new { Name = beerToInsert.Name, Image = beerToInsert.Image, Description = beerToInsert.Description, BreweryName = beerToInsert.BreweryName});
            conn.Close();
          
        }
    }
}
