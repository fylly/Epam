using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesDataLevel
{
    public class SaleItemRepository //: IRepository<>
 : RepositoryBase<SalesDataLevel.Models.SaleItem>
    {
        public SaleItemRepository()
            : base(new SalesModel.SalesContainer())
        { 
        }
    }
}
