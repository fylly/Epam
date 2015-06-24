using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesDataLevel
{
    public class CustomerRepository : RepositoryBase<SalesDataLevel.Models.Customer>
    {
        public CustomerRepository()
            : base(new SalesModel.SalesContainer())
        {
        }
    }
}
