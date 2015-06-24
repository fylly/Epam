using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesDataLevel
{
    public class InputFilesRepository 
         : RepositoryBase<SalesDataLevel.Models.InputFile>
    {
        public InputFilesRepository()
            : base(new SalesModel.SalesContainer())
        {
        }
    }
}
