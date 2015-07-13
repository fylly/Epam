using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface IManagerRepository : IRepository<ModelLayer.Manager>
    {
        ModelLayer.Manager GetById(int item);
        void InsertOrUpdate(ModelLayer.Manager item);
    }
}
