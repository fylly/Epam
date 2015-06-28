using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBusinessLayer
{
    public class FilesWoker
    {
        private SalesDataLevel.IRepository<SalesModel.Product> _contextProduct = new SalesDataLevel.ProductRepository();
        private SalesDataLevel.IRepository<SalesModel.Customer> _contextCustomer = new SalesDataLevel.CustomerRepository();
        private SalesDataLevel.IRepository<SalesModel.Manager> _contextManager = new SalesDataLevel.ManagerRepository();
        private SalesDataLevel.IRepository<SalesModel.InputFile> _contextInputFile = new SalesDataLevel.InputFilesRepository();
        private SalesDataLevel.IRepository<SalesModel.SaleItem> _contextSaleItem = new SalesDataLevel.SaleItemRepository();

        private object _customerOpSync = new object();
        private object _producteOpSync = new object();
        private object _managerOpSync = new object();

        private Task _taskArray;

        public void Work(List<String> item, String fileName)
        {
            var cvsParse = SalesBusinessLayer.CSVParser.CSVParser.Parse(item.ToList());
            
            var fileNameSet = (_contextInputFile as SalesDataLevel.InputFilesRepository).GetFileByName(fileName);
            if (fileNameSet != null)
            {
                return;
            }
            else
            {
                fileNameSet = _contextInputFile.Add(new SalesModel.InputFile() { FileTitle = fileName });
                _contextInputFile.SaveChanges();
            }
            
            _taskArray = Task.Factory.StartNew(() => NewTask1(cvsParse.ToList(), fileNameSet));
        }

        private void NewTask1(List<SalesBusinessLayer.CSVParser.ParseItem> item,SalesModel.InputFile inputFile)
        {
            SalesModel.Customer customerSet = null;
            SalesModel.Product productSet = null;
            SalesModel.Manager managerSet = null;

            foreach (var c in item)
            {
                lock (_customerOpSync)
                {
                    customerSet = (_contextCustomer as SalesDataLevel.CustomerRepository).GetCustomerByName(c.CustomerName);
                    if (customerSet == null)
                    {
                        customerSet = _contextCustomer.Add(new SalesModel.Customer() { CustomerName = c.CustomerName });
                        _contextCustomer.SaveChanges();
                    }
                }
                
                lock (_producteOpSync)
                {
                    productSet = (_contextProduct as SalesDataLevel.ProductRepository).GetProductByName(c.ProductName);
                    if (productSet == null)
                    {
                        productSet = _contextProduct.Add(new SalesModel.Product() { ProductName = c.ProductName, Barcode = c.Barcode });
                        _contextProduct.SaveChanges();                        
                    }
                }

                lock (_managerOpSync)
                {
                    managerSet = (_contextManager as SalesDataLevel.ManagerRepository).GetManagerByName(c.ManagerName);
                    if (managerSet == null)
                    {
                        managerSet = _contextManager.Add(new SalesModel.Manager() { ManagerName = c.ManagerName });
                        _contextManager.SaveChanges();                        
                    }
                }
                
                var saleItemSet = 
                    new SalesModel.SaleItem() { 
                        Customer = customerSet, 
                        Product = 
                        productSet, 
                        InputFile = inputFile, 
                        Manager = managerSet, 
                        SaleSum = Convert.ToDouble(c.SaleSum), 
                        SaleDate = c.SaleDate 
                    };

                Console.WriteLine("Sale item - {0}, {1}, {2}, {3}, {4} - sum - date - {5}, {6}", 
                    saleItemSet.Customer.Id,
                    saleItemSet.Product.Id,
                    saleItemSet.Manager.Id,
                    saleItemSet.InputFile.Id,
                    saleItemSet.Id, 
                    saleItemSet.SaleSum,
                    saleItemSet.SaleDate);

                _contextSaleItem.Add(saleItemSet);

                _contextSaleItem.SaveChanges();

            }
        }
    }
}
