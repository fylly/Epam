using DataLayer;
using MvcSalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSalesSystem.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Producte/
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

        //
        // GET: /Producte/Create
        
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Producte/Create

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var producteItem = _productRepository.GetById(id);
            if (producteItem == null)
            {
                return HttpNotFound();
            }
            
            return View(new EditProductItem()
            {
                Id = producteItem.Id,
                ProductName = producteItem.ProductName,
                Barcode = producteItem.Barcode
            });
        }

        //
        // POST: /Producte/Edit/5

        [HttpPost]
        public ActionResult Save(EditProductItem item)
        {
            var productItem = _productRepository.GetById(item.Id);
            if (productItem == null)
            {
                if (item.Id == default(int))
                {
                    productItem = new ModelLayer.Product();
                }
                else
                {
                    return HttpNotFound();
                }
            }

            productItem.ProductName = item.ProductName;
            productItem.Barcode = item.Barcode;

            _productRepository.InsertOrUpdate(productItem);
            _productRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // POST: /Producte/Delete/5

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var productItem = _productRepository.GetById(id);
                if (productItem == null)
                {
                    return HttpNotFound();
                }

                if (!productItem.SaleItem.Any())
                {
                    return RedirectToAction("ShowAll", "Sales", new {  Model = productItem.SaleItem });
                }

                _productRepository.Delete(productItem);
                _productRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
