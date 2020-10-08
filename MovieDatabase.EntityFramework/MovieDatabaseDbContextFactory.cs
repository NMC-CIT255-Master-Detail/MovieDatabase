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

            options.UseMySQL("server=sharedcloud1.squidix.net;database=pbswebde_movies;user=pbswebde_movie_user;password=1!2@3#4$5%6^7&8*9(");

            return new MovieDatabaseDBContext(options.Options);
        }
    }
}