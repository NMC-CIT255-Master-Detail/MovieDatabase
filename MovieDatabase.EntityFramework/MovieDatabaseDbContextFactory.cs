using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MovieDatabase.EntityFramework
{
    public class MovieDatabaseDbContextFactory : IDesignTimeDbContextFactory<MovieDatabaseDBContext>
    {
        public MovieDatabaseDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<MovieDatabaseDBContext>();
            options.UseMySQL("");

            return new MovieDatabaseDBContext(options.Options);
        }
    }
}