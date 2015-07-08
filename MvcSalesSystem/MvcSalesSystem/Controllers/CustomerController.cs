using DataLayer;
using MvcSalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSalesSystem.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
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
                
        //
        // GET: /Customer/Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Save(EditCustomerItem item)
        {
            var customerItem = _customerRepository.GetById(item.Id);
            if (customerItem == null)
            {
                if (item.Id == default(int))
                {
                    customerItem = new ModelLayer.Customer();
                }
                else
                {
                    return HttpNotFound();
                }
            }

            customerItem.CustomerName = item.CustomerName;

            _customerRepository.InsertOrUpdate(customerItem);
            _customerRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Customer/Edit/5

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customerItem = _customerRepository.GetById(id);
            if (customerItem == null)
            {
                return HttpNotFound();
            }

            return View(new EditCustomerItem()
            {
                Id = customerItem.Id,
                CustomerName = customerItem.CustomerName
            });
        }

        //
        // POST: /Customer/Edit/5
                
        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Delete/5
                
    }
}
