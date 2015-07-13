using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class ManagerRepository : RepositoryBase<ModelLayer.Manager>, IManagerRepository
    {
        public ManagerRepository(DbContext dataContext)
            : base(dataContext)
        {
        }

        public ModelLayer.Manager GetById(int item)
        {
            return base.dbSet.FirstOrDefault(x => x.Id == item);
        }
        
        public void InsertOrUpdate(ModelLayer.Manager item)
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
