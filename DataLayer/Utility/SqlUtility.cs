using System.Data.SqlClient;
using DataLayer.AppConfig;


namespace DataLayer.Utility
{
    public static class SqlUtility
    {
        public static SqlConnection GetConnection() => new(new AppConfiguration().ConnectionString);
    }
}