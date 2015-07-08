using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using MvcSalesSystem.Models;

namespace MvcSalesSystem.Controllers
{
    public class SalesController : Controller
    {
        //
        // GET: /Sales/

        private DALContext _dalContext;

        private IProductRepository _productRepository;
        private ICustomerRepository _customerRepository;
        private IManagerRepository _managerRepository;
        private IInputFilesRepository _inputFileRepository;
        private ISaleItemRepository _saleItemRepository;

        public SalesController()
        {
            _dalContext = new DALContext();
            _customerRepository = _dalContext.Customers;
            _inputFileRepository = _dalContext.InputFiles;
            _managerRepository = _dalContext.Managers;
            _productRepository = _dalContext.Products;
            _saleItemRepository = _dalContext.SaleItems;

        }
        
        [HttpGet]
        public ActionResult Index()
        {
            var saleItem = _saleItemRepository.GetAll().Select(x =>
                new ListSalesItem()
                {
                    Id = x.Id,
                    SaleDate = x.SaleDate,
                    SaleSum = x.SaleSum,
                    Customer = x.Customer.CustomerName,
                    Manager = x.Manager.ManagerName,
                    Product = x.Product.ProductName
                });

            return View(saleItem);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var saleItem = _saleItemRepository.GetById(id);
            if (saleItem == null)
            {
                return HttpNotFound();
            }

            _saleItemRepository.Delete(saleItem);
            _saleItemRepository.SaveChanges();
            return RedirectToAction("ShowAll", "Sales");
        }
     
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var saleItem = _saleItemRepository.GetById(id);
            if (saleItem == null)
            {
                return HttpNotFound();
            }
            var customers = new SelectList(_customerRepository.GetAll(), "Id", "CustomerName");
            ViewBag.Customers = customers;
            var producte = new SelectList(_productRepository.GetAll(), "Id", "ProductName");
            ViewBag.Producte = producte;
            var manager = new SelectList(_managerRepository.GetAll(), "Id", "ManagerName");
            ViewBag.Manager = manager;

            return View(new EditSalesItem() { Id = saleItem.Id, 
                SaleDate = saleItem.SaleDate, 
                SaleSum = saleItem.SaleSum, 
                Customer=saleItem.Customer.Id, 
                Product = saleItem.Product.Id,
                Manager = saleItem.Manager.Id
            });
        }

        [HttpGet]
        public ActionResult Create()
        {            
            var customers = new SelectList(_customerRepository.GetAll(), "Id", "CustomerName");
            ViewBag.Customers = customers;
            var producte = new SelectList(_productRepository.GetAll(), "Id", "ProductName");
            ViewBag.Producte = producte;
            var manager = new SelectList(_managerRepository.GetAll(), "Id", "ManagerName");
            ViewBag.Manager = manager;

            return View();
        }

        [HttpPost]
        public ActionResult Save(EditSalesItem item)
        {
            var saleItem = _saleItemRepository.GetById(item.Id);
            if (saleItem == null)
            {
                if (item.Id == default(int))
                {
                    saleItem = new ModelLayer.SaleItem();
                }
                else
                {
                    return HttpNotFound();
                }
            }

            saleItem.SaleDate = item.SaleDate;
            saleItem.SaleSum = item.SaleSum;
                        
            var customer = _customerRepository.GetById(item.Customer);
            saleItem.Customer = customer;

            var producte = _productRepository.GetById(item.Product);
            saleItem.Product = producte;

            var manager = _managerRepository.GetById(item.Manager);
            saleItem.Manager = manager;

            _saleItemRepository.InsertOrUpdate(saleItem);
            _saleItemRepository.SaveChanges();
     
            return RedirectToAction("ShowAll", "Sales");
        }
    }
}
