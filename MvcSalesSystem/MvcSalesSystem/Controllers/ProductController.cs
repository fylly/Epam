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
    public class ProductController : Controller
    {
        private DALContext _dalContext;
        private IProductRepository _productRepository;

        public ProductController()
        {
            _dalContext = new DALContext();
            _productRepository = _dalContext.Products;
        }

        [HttpGet]    
        public ActionResult Index()
        {
            var productItem = _productRepository.GetAll().Select(x =>
                new ListProductItem()
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    Barcode = x.Barcode
                });

            return View(productItem);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(EditProductItem item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productItem = new ModelLayer.Product() { ProductName = item.ProductName, Barcode = item.Barcode};

                    _productRepository.InsertOrUpdate(productItem);
                    _productRepository.SaveChanges();

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
        public ActionResult Edit(int id)
        {
            var producteItem = _productRepository.GetById(id);
            if (producteItem == null)
            {
                return View("Error");
            }

            var editProductItem = new EditProductItem()
                {
                    Id = producteItem.Id,
                    ProductName = producteItem.ProductName,
                    Barcode = producteItem.Barcode
                };

            if (Request.IsAjaxRequest())
            {
                return PartialView("_EditPartial", editProductItem);
            }
            return View(editProductItem);
        }
        

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(EditProductItem item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productItem = _productRepository.GetById(item.Id);
                    
                    productItem.ProductName = item.ProductName;
                    productItem.Barcode = item.Barcode;

                    _productRepository.InsertOrUpdate(productItem);
                    _productRepository.SaveChanges();

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
                var productItem = _productRepository.GetById(id);
                if (productItem != null && !productItem.SaleItem.Any())
                {
                    _productRepository.Delete(productItem);
                    _productRepository.SaveChanges();
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
