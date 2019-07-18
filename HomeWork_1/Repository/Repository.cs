using HomeWork_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HomeWork_1.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _dbSet;
        public Repository()
        {
            _dbSet = new DbEntities().Set<T>();
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public T GetSingle(Expression<Func<T, bool>> filter)
        {
            return _dbSet.SingleOrDefault(filter);
        }

        public IQueryable<T> LookupAll()
        {
            return _dbSet;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public void Remomve(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}