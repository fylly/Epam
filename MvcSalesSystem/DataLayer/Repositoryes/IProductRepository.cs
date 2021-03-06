﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface IProductRepository : IRepository<ModelLayer.Product>
    {
        ModelLayer.Product GetById(int item);
        void InsertOrUpdate(ModelLayer.Product item);
    }
}
