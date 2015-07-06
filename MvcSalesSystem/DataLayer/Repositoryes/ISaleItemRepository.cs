using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface ISaleItemRepository : IRepository<ModelLayer.SaleItem>
    {
        ModelLayer.SaleItem GetById(int item);
    }
}
