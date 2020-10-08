﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovieDatabase.Domain.Services
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Create(T entity);
        T Update(int id, T entity);
        bool Delete(int id);
    }
}