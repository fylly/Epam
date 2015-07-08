using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class SaleItemRepository : RepositoryBase<ModelLayer.SaleItem>, ISaleItemRepository
    {
        public SaleItemRepository(DbContext dataContext)
            : base(dataContext)
        {
        }
        public ModelLayer.SaleItem GetById(int item)
        {
            return base.dbSet.FirstOrDefault(x => x.Id == item);
        }
        public void InsertOrUpdate(ModelLayer.SaleItem item)
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
