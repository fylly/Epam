using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBusinessLayer
{
    public static class CommunicationMethods
    {
        public static bool IsExistInInputFile(String fileName)
        {
            SalesDataLevel.IRepository<SalesModel.InputFile> _contextInputFile = new SalesDataLevel.InputFilesRepository();

            var fileNameSet = (_contextInputFile as SalesDataLevel.InputFilesRepository).GetFileByName(fileName);
            if (fileNameSet == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }
}
