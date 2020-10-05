using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace MovieDatabase.EntityFramework
{
    public class MovieDatabaseDbContextFactory : IDesignTimeDbContextFactory<MovieDatabaseDBContext>
    {
        public MovieDatabaseDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<MovieDatabaseDBContext>();
            
            var password = ConfigurationManager.AppSettings.Get("DBConnectionPassword");
            var server = ConfigurationManager.AppSettings.Get("Server");
            var dbName = ConfigurationManager.AppSettings.Get("DBName");
            var dbUser = ConfigurationManager.AppSettings.Get("DBUser");

            options.UseMySQL($"server={server};database={dbName};user={dbUser};password={password}");

            return new MovieDatabaseDBContext(options.Options);
        }
    }
}