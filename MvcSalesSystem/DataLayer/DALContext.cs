using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DALContext
    {
        private DbContext _dataContext;
        private ICustomerRepository _customers;
        private IProductRepository _products;
        private IManagerRepository _managers;
        private ISaleItemRepository _saleItems;
        private IInputFilesRepository _inputFiles;

        public DALContext() 
        {
            _dataContext = new ModelLayer.SalesModelContainer();
        }

        public ICustomerRepository Customers {
            get
            {
                if (_customers == null)
                {
                    _customers = new CustomerRepository(_dataContext);
                }
                return _customers;
            }
        }

        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(_dataContext);
                }
                return _products;
            }
        }

        public IManagerRepository Managers
        {
            get
            {
                if (_managers == null)
                {
                    _managers = new ManagerRepository(_dataContext);
                }
                return _managers;
            }
        }

        public ISaleItemRepository SaleItems
        {
            get
            {
                if (_saleItems == null)
                {
                    _saleItems = new SaleItemRepository(_dataContext);
                }
                return _saleItems;
            }
        }

        public IInputFilesRepository InputFiles
        {
            get
            {
                if (_inputFiles == null)
                {
                    _inputFiles = new InputFilesRepository(_dataContext);
                }
                return _inputFiles;
            }
        }
    }
}
