using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class CustomerRepository 
        : RepositoryBase<ModelLayer.Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dataContext)
            : base(dataContext)
        {
        }

        public ModelLayer.Customer GetById(int item)
        {
            return base.dbSet.FirstOrDefault(x => x.Id == item);
        }

        public void InsertOrUpdate(ModelLayer.Customer item)
        {
            if (item.Id == default(int))
            {
                Add(item);
            }
            else
            {
                Update(item);
            };
        }
    }
}
