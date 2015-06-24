using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesDataLevel
{
    public class ProductRepository : RepositoryBase<SalesModel.Product>
    {
        public ProductRepository()
            : base(new SalesModel.SalesContainer())
        {
        }
    }
}
