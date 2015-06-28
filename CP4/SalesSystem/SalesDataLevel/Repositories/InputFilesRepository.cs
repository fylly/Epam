using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesDataLevel
{
    public class InputFilesRepository 
         : RepositoryBase<SalesModel.InputFile>
    {
        public InputFilesRepository()
            : base(new SalesModel.SalesContainer())
        {
        }

        public SalesModel.InputFile GetFileByName(String item)
        {
            return base.dbSet.FirstOrDefault(x => x.FileTitle == item);
        }
    }
}
