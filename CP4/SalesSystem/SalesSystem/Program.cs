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
            SalesDataLevel.IRepository<SalesModel.Product> context = new SalesDataLevel.ProductRepository();

            //context.Add(new SalesModel.Product() { ProductName = "Coca-Cola", Barcode = "0178995445" });
            //context.SaveChanges();

            foreach (var i in context.GetAll())
            {
                Console.WriteLine("{0} - {1} \t- {2}", i.Id, i.ProductName, i.Barcode);
            }

            Console.ReadKey();
        }
    }
}
