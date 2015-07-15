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
    public class ManagerController : Controller
    {
        private DALContext _dalContext;
        private IManagerRepository _managerRepository;

        public ManagerController()
        {
            _dalContext = new DALContext();
            _managerRepository = _dalContext.Managers;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var managerItem = _managerRepository.GetAll().Select(x => 
                new ListManagerItem() 
                { 
                    Id = x.Id,
                    ManagerName = x.ManagerName
                });

            return View(managerItem);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(EditManagerItem item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var managerItem = new ModelLayer.Manager() { ManagerName = item.ManagerName };

                    _managerRepository.InsertOrUpdate(managerItem);
                    _managerRepository.SaveChanges();

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
            var managerItem = _managerRepository.GetById(id);
            if (managerItem == null)
            {
                return View("Error");
            }
            
            var editManagerItem = new EditManagerItem()
            {
                Id = managerItem.Id,
                ManagerName = managerItem.ManagerName
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("_EditPartial", editManagerItem);
            }
            return View("Edit", editManagerItem);
        }


        

       
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(EditManagerItem item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var managerItem = _managerRepository.GetById(item.Id);
                    
                    managerItem.ManagerName = item.ManagerName;

                    _managerRepository.InsertOrUpdate(managerItem);
                    _managerRepository.SaveChanges();

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
                var productItem = _managerRepository.GetById(id);
                if (productItem != null && !productItem.SaleItem.Any())
                {
                    _managerRepository.Delete(productItem);
                    _managerRepository.SaveChanges();

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
