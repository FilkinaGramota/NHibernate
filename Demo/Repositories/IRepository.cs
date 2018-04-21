using System;
using System.Collections.Generic;
using Demo.Entities;

namespace Demo.Repositories
{
    public interface IRepository<T>
    {
        void CreateDataBase();
        void Save(T entity);
        void Delete(T entity);
        IList<T> GetAll();
        T GetById(int id);
    }
}
