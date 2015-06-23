using SalesModel;

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
            var context = new SalesContainer();


            foreach (var i in context.Products.ToList())
            {
                Console.WriteLine("{0} - {1}", i.ProductName, i.Barcode);
            }

            Console.ReadKey();
        }
    }
}
