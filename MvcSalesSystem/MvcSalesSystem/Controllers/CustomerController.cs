using DataLayer;
using MvcSalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSalesSystem.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {        
        private DALContext _dalContext;
        private ICustomerRepository _customerRepository;

        public CustomerController()
        {
            _dalContext = new DALContext();
            _customerRepository = _dalContext.Customers;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var customerItem = _customerRepository.GetAll().Select(x =>
                new ListCustomerItem()
                {
                    Id = x.Id,
                    CustomerName = x.CustomerName                    
                });

            return View(customerItem);
        }
       

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var customerItem = _customerRepository.GetById(id);
            if (customerItem == null)
            {
                return View("Error");
            }

            var editCustomerItem = new EditCustomerItem()
            {
                Id = customerItem.Id,
                CustomerName = customerItem.CustomerName
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Edit", editCustomerItem);
            }
            return View("Edit", editCustomerItem);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(EditCustomerItem item)
        {
            if (ModelState.IsValid)
            {
                try
                {   
                    var customerItem = new ModelLayer.Customer(){ CustomerName = item.CustomerName};

                    _customerRepository.InsertOrUpdate(customerItem);
                    _customerRepository.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.MessageError = "Data error";
                }
            }
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(EditCustomerItem item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var customerItem = _customerRepository.GetById(item.Id);
                    
                    customerItem.CustomerName = item.CustomerName;
                    
                    _customerRepository.InsertOrUpdate(customerItem);
                    _customerRepository.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.MessageError = "Data error";
                }
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                var productItem = _customerRepository.GetById(id);
                if (productItem != null && !productItem.SaleItem.Any())
                {
                   _customerRepository.Delete(productItem);
                    _customerRepository.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            catch
            {
                ViewBag.MessageError = "Data error"; 
            }
            return View("Error");
        }
    }
}
