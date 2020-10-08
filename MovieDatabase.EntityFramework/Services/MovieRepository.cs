using Microsoft.EntityFrameworkCore;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieDatabase.EntityFramework.Services
{
    public class MovieRepository : IDataService<Movie>
    {

        private readonly MovieDatabaseDbContextFactory _contextFactory;

        public MovieRepository(MovieDatabaseDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }


        public Movie Create(Movie entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var result = context.Set<Movie>().Add(entity);
                context.SaveChanges();
                return result.Entity;
            }
        }

        public bool Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = context.Set<Movie>().FirstOrDefault((e) => e.Id == id);
                context.Set<Movie>().Remove(entity);
                context.SaveChanges();

            }

            return true;
        }

        public Movie Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = context.Set<Movie>().FirstOrDefault((e) => e.Id == id);
                return entity;
            }
        }

        public IEnumerable<Movie> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Movie> entities = context.Movies.Include(m => m.Producer).Include(m => m.Studio).ToList();
                return entities;
            }
        }

        public Movie Update(int id, Movie entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<Movie>().Update(entity);
                context.SaveChanges();
                return entity;
            }
        }
    }
}
