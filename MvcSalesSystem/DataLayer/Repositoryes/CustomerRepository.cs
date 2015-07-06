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
        public ModelLayer.Customer GetCustomerByName(string item)
        {
            return base.dbSet.FirstOrDefault(x => x.CustomerName == item);
        }
    }
}
