﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly MovieDatabaseDbContextFactory _contextFacory;

        public GenericDataService(MovieDatabaseDbContextFactory contextFacory)
        {
            _contextFacory = contextFacory;
        }

        public T Create(T entity)
        {
            using (var context = _contextFacory.CreateDbContext())
            {
                var result = context.Set<T>().Add(entity);
                context.SaveChanges();
                return result.Entity;
            }
        }

        public bool Delete(int id)
        {
            using (var context = _contextFacory.CreateDbContext())
            {
                var entity = context.Set<T>().FirstOrDefault((e) => e.Id == id);
                context.Set<T>().Remove(entity);
            }

            return true;
        }

        public T Get(int id)
        {
            using (var context = _contextFacory.CreateDbContext())
            {
                var entity = context.Set<T>().FirstOrDefault((e) => e.Id == id);
                return entity;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var context = _contextFacory.CreateDbContext())
            {
                IEnumerable<T> entities = context.Set<T>().ToList();
                return entities;
            }
        }

        public T Update(int id, T entity)
        {
            using (var context = _contextFacory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                context.SaveChanges();
                return entity;
            }
        }
    }
}