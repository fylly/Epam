using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface ICustomerRepository : IRepository<ModelLayer.Customer>
    {
        ModelLayer.Customer GetCustomerByName( string item);
    }
}
