﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using MvcSalesSystem.Models;

namespace MvcSalesSystem.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
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
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            try
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

                var editSalesItem = new EditSalesItem()
                {
                    Id = saleItem.Id,
                    SaleDate = saleItem.SaleDate,
                    SaleSum = saleItem.SaleSum,
                    Customer = saleItem.Customer.Id,
                    Product = saleItem.Product.Id,
                    Manager = saleItem.Manager.Id
                };

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_EditForm", editSalesItem);
                }
                return View("Edit", editSalesItem);
            }
            catch
            {
                return View("Error");
            }
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {            
            var customers = new SelectList(_customerRepository.GetAll(), "Id", "CustomerName");
            ViewBag.Customers = customers;
            var product = new SelectList(_productRepository.GetAll(), "Id", "ProductName");
            ViewBag.Product = product;
            var manager = new SelectList(_managerRepository.GetAll(), "Id", "ManagerName");
            ViewBag.Manager = manager;

            return View();
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Save(EditSalesItem item)
        {
            try
            {
                if (item == null)
                {
                    return View("Error");
                }
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

                return RedirectToAction("Index", "Sales");
            }
            catch
            {
                return View("Error");
            }
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                var saleItem = _saleItemRepository.GetById(id);
                if (saleItem == null)
                {
                    return View("Error");
                }

                _saleItemRepository.Delete(saleItem);
                _saleItemRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }


        [HttpGet]
        public ActionResult Search()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Search");
            }
            return View("Search");
        }

        [HttpPost]
        public ActionResult Search(SalesSearchForm item)
        {
            var qery = _saleItemRepository.GetAll();

            if (item.Product != null)
            {
                qery = qery.Where(x=>x.Product.ProductName.Contains(item.Product.Trim()));
            }
            if (item.Customer != null)
            {
                qery = qery.Where(x => x.Customer.CustomerName.Contains(item.Customer.Trim()));
            }
            if (item.Manager != null )
            {
                qery = qery.Where(x => x.Manager.ManagerName.Contains(item.Manager.Trim()));
            }
            if (item.SaleDate != null && item.SearchDateType != default(int))
            {
                switch (item.SearchDateType)
                {
                    case 1:
                        qery = qery.Where(x => x.SaleDate > item.SaleDate );
                        break;
                    case 2:
                        qery = qery.Where(x => x.SaleDate == item.SaleDate );
                        break;
                    case 3:
                        qery = qery.Where(x => x.SaleDate < item.SaleDate);
                        break;
                }
            }

            var resultList = qery.Select(x =>
                new ListSalesItem()
                {
                    Id = x.Id,
                    SaleDate = x.SaleDate,
                    SaleSum = x.SaleSum,
                    Customer = x.Customer.CustomerName,
                    Manager = x.Manager.ManagerName,
                    Product = x.Product.ProductName
                });

            return View("Search", new SalesSearchModel { SerchForm = item, ListSales = resultList });
        }
    }
}
