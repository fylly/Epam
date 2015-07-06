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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAll()
        {
            return View(_saleItemRepository.GetAll().ToList());
        }

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

            return View(new EditSalesItem() { Id = saleItem.Id, SaleDate = saleItem.SaleDate, SaleSum = saleItem.SaleSum });
        }
        
        [HttpPost]
        public ActionResult Edit(EditSalesItem item)
        {
            Console.WriteLine(item.Id);

            var saleItem = _saleItemRepository.GetById(item.Id);
            saleItem.SaleDate = item.SaleDate;
            saleItem.SaleSum = item.SaleSum;

            _saleItemRepository.Update(saleItem);
            _saleItemRepository.SaveChanges();
           /* 
            var saleItem = _saleItemRepository.GetById(id);
            if (saleItem == null)
            {
                return HttpNotFound();
            }
             */         
            return RedirectToAction("ShowAll", "Sales");
        }
    }
}
