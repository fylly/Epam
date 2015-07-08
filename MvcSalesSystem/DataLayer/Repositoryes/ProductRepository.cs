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

        public void InsertOrUpdate(ModelLayer.Product item)
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

        public ModelLayer.Product GetById(int item)
        {
            return base.dbSet.FirstOrDefault(x=>x.Id == item);
        }
    }
}
