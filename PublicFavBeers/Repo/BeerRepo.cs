using Dapper;
using Microsoft.Data.SqlClient;
using PublicFavBeers.Interfaces;
using PublicFavBeers.Models;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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

            //byte[] imageBytes;
            //using (var ms = new MemoryStream())
            //{
            //    beerToInsert.Image.CopyTo(ms);
            //    imageBytes = ms.ToArray();
            //}
            string imageString = Convert.ToBase64String(beerToInsert.Image);
            conn.Execute("INSERT INTO dbo.PublicFavBeer (Name, Image, Description, BreweryName) VALUES (@Name, @Image, @Description, @BreweryName);",
                new { beerToInsert.Name, Image = imageString, beerToInsert.Description, beerToInsert.BreweryName });


            conn.Close();
        }









    }
}
