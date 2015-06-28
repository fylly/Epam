using SalesModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SalesDataLevel
{
    public abstract class RepositoryBase<T>: IRepository<T> where T : class
    {
        
        protected DbSet<T> dbSet;
        protected DbContext dbContext;

        public RepositoryBase(DbContext dataContext)
        {
            dbContext = dataContext;
            dbSet = dbContext.Set<T>();
        }


        public T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual void SaveChanges()
        {
            dbContext.SaveChanges();
        }
      
    }
}
