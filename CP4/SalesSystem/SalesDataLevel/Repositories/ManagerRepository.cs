using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesDataLevel
{
    public class ManagerRepository : RepositoryBase<SalesDataLevel.Models.Manager>
    {
        public ManagerRepository()
            : base(new SalesModel.SalesContainer())
        {
        }
    }
}
