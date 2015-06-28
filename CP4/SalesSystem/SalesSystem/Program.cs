using SalesBusinessLayer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesDataLevel.IRepository<SalesModel.Product> context = new SalesDataLevel.ProductRepository();
                        
            string[] lines1 = System.IO.File.ReadAllLines(@".\fileInput.csv");
            string[] lines2 = System.IO.File.ReadAllLines(@".\fileInput1.csv");

            var iii = new SalesBusinessLayer.FilesWoker();

            iii.Work(lines1.ToList(), "fileInput.csv");
            iii.Work(lines2.ToList(), "454555454");

            Console.ReadKey();
        }
    }
}
