using Microsoft.Extensions.Configuration;
using System.IO;


namespace DataLayer.AppConfig
{
    public class AppConfiguration
    {
        public readonly string _connectionString = string.Empty;
        public string ConnectionString{get => _connectionString;}
        public AppConfiguration()
        {
             var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            _connectionString = configurationBuilder.Build().GetSection("DBConnections").GetSection("SqlConnectionString").Value;
        }
    }
}