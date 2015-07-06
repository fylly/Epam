using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface IInputFilesRepository : IRepository<ModelLayer.InputFile>
    {
        ModelLayer.InputFile GetFileByName(string item);
       
    }
}
