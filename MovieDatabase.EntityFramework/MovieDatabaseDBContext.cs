using Microsoft.EntityFrameworkCore;
using MovieDatabase.Domain.Models;

namespace MovieDatabase.EntityFramework
{
    public class MovieDatabaseDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Studio> Studios { get; set; }

        public MovieDatabaseDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}