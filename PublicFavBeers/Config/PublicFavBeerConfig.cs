using PublicFavBeers.Interfaces;

namespace PublicFavBeers.Config
{
    public class PublicFavBeerConfig : IConfig
    {

        public string GetConnectionString()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return config[_configKey] ?? throw new ApplicationException("No config found for database connection");// if appsetting is not found throw ex
        }

        private const string _configKey = "ConnectionStrings:DefaultConnection";
    }

}
