using SalesBusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem
{
    class Program
    {
        SalesBusinessLayer.FilesWoker test = new SalesBusinessLayer.FilesWoker();

        static void Main(string[] args)
        {
            // FileSystemWatcher

            FileWatcher fileWorker = new FileWatcher(@".\csv\");
            fileWorker.Run();
            
            Console.ReadKey();
        }

        

    }
}
