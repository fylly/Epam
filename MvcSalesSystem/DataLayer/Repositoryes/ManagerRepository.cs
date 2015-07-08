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

        public ModelLayer.Manager GetManagerByName(string item)
        {
            return base.dbSet.FirstOrDefault(x => x.ManagerName == item);
        }


        public ModelLayer.Manager GetById(int item)
        {
            return base.dbSet.FirstOrDefault(x => x.Id == item);
        }
    }
}
