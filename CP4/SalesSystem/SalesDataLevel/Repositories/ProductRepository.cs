﻿using System;
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
        
        public SalesModel.Product GetProductByName(String item)
        {
            return base.dbSet.FirstOrDefault(x => x.ProductName == item);
        }
    }
}
