using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesDataLevel
{
    public class CustomerRepository : RepositoryBase<SalesModel.Customer>
    {
        public CustomerRepository()
            : base(new SalesModel.SalesContainer())
        {
            
        }
        public SalesModel.Customer GetCustomerByName(String item)
        {
            return base.dbSet.FirstOrDefault(x => x.CustomerName == item);
        }

    }
}
