using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class InputFilesRepository : RepositoryBase<ModelLayer.InputFile>,IInputFilesRepository
    {
        public InputFilesRepository(DbContext dataContext)
            : base(dataContext)
        {
        }

        public ModelLayer.InputFile GetFileByName(string item)
        {
            return base.dbSet.FirstOrDefault(x => x.FileTitle == item);
        }
    }
}
