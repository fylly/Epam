using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class ProductRepository : RepositoryBase<ModelLayer.Product>, IProductRepository
    {
        public ProductRepository(DbContext dataContext)
            : base(dataContext)
        {
        }

        public ModelLayer.Product GetProductByName(string item)
        {
            return base.dbSet.FirstOrDefault(x => x.ProductName == item);
        }
    }
}
