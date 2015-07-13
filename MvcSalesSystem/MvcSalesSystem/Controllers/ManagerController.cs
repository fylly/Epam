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
                return PartialView("_Edit", editManagerItem);
            }
            return View("Edit", editManagerItem);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Save(EditManagerItem item)
        {
            try
            {
                if (item == null)
                {
                    return View("Error");
                }
                var managerItem = _managerRepository.GetById(item.Id);
                if (managerItem == null)
                {
                    if (item.Id == default(int))
                    {
                        managerItem = new ModelLayer.Manager();
                    }
                    else
                    {
                        return View("Error");
                    }
                }

                managerItem.ManagerName = item.ManagerName;

                _managerRepository.InsertOrUpdate(managerItem);
                _managerRepository.SaveChanges();

                return RedirectToAction("Index");
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
                var productItem = _managerRepository.GetById(id);
                if (productItem == null)
                {
                    return View("Error");
                }
                if (productItem.SaleItem.Any())
                {
                    return View("Error");
                }

                _managerRepository.Delete(productItem);
                _managerRepository.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
