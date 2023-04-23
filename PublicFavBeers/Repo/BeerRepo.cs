using Dapper;
using Microsoft.Data.SqlClient;
using PublicFavBeers.Interfaces;
using PublicFavBeers.Models;

namespace PublicFavBeers.Repo
{
    public class BeerRepo : IBeerRepo
    {
        private readonly IConfig _config;
        public BeerRepo (IConfig config)
        {
            _config = config;
        }
        public IEnumerable<BeerModel> GetAllBeer()
        {
            using var conn = new SqlConnection(_config.GetConnectionString());
            conn.Open();
            return conn.Query<BeerModel>("SELECT * FROM dbo.PublicFavBeer");

        }

        Task<string> IBeerRepo.AddBeer(BeerModel beer)
        {
            throw new NotImplementedException();
        }
    }
}
