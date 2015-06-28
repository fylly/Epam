using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesDataLevel
{
    public class ManagerRepository : RepositoryBase<SalesModel.Manager>
    {
        public ManagerRepository()
            : base(new SalesModel.SalesContainer())
        {
        }

        public SalesModel.Manager GetManagerByName(String item)
        {
            return base.dbSet.FirstOrDefault(x => x.ManagerName == item);
        }
    }
}
