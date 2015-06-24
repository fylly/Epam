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
        
        protected DbSet<T> _DbSet;
        protected DbContext _DbContext;

        public RepositoryBase(DbContext dataContext)
        {
            _DbContext = dataContext;
            _DbSet = _DbContext.Set<T>();
        } 
        
        
        public void Add(T entity)
        {
            _DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _DbSet.Attach(entity);
            _DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _DbSet.ToList();
        }

        public void SaveChanges()
        {
            _DbContext.SaveChanges();
        }
 /*
        //_________________________________________________________________________________________
        #region IRepository<T> Members

        public T GetById(int id)
        {
            return _DbSet.Find(id);
        }

        public System.Collections.Generic.IEnumerable<T> GetByQuery(Expression<Func<T, bool>> query = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> queryResult = _DbSet;
 
            //If there is a query, execute it against the dbset
            if (query != null)
            {
                queryResult = queryResult.Where(query);
            }
 
            //get the include requests for the navigation properties and add them to the query result
            foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                queryResult = queryResult.Include(property);
            }
 
            //if a sort request is made, order the query accordingly.
            if (orderBy != null)
            {
                return orderBy(queryResult).ToList();
            }
            //if not, return the results as is
            else
            {
                return queryResult.ToList();
            }
        }

        public T GetFirst(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.First(predicate);
        }

 
        public void UpdateById(int id)
        {
            T entity = _DbSet.Find(id);
            _DbSet.Attach(entity);
            _DbContext.Entry(entity).State = EntityState.Modified;
 
        }
 
        public void Delete(T entity)
        {
            if (_DbContext.Entry(entity).State == EntityState.Detached)
                _DbSet.Attach(entity);
 
            _DbSet.Remove(entity);
        }

        public void DeleteByID(int id)
        {
            T entity = _DbSet.Find(id);
            _DbSet.Remove(entity);
        }
 
        #endregion
*/









       
    }
}
