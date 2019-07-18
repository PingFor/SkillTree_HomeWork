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
        public IUnitOfWork UnitOfWork { get; set; }
        private DbSet<T> _dbSet;
        private DbSet<T> objSet => _dbSet ?? (UnitOfWork.Context.Set<T>());
        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public void Create(T entity)
        {
            objSet.Add(entity);
        }

        public T GetSingle(Expression<Func<T, bool>> filter)
        {
            return objSet.SingleOrDefault(filter);
        }

        public IQueryable<T> LookupAll()
        {
            return objSet;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return objSet.Where(filter);
        }

        public void Remomve(T entity)
        {
            objSet.Remove(entity);
        }
    }
}