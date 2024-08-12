using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CodeFirst.Models;
using MVC_CodeFirst.Repository;

namespace MVC_CodeFirst.Controllers
{
    public class SalesController : Controller
    {
        IProductRepository<Sales> _prdrepo = null;

        public SalesController()
        {
            _prdrepo = new ProductRepository<Sales>();
        }
        // GET: Sales
        public ActionResult Index()
        {
            var sal = _prdrepo.GetAll();
            return View(sal);
        }

        //2. create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sales s)
        {
            if (ModelState.IsValid)
            {
                _prdrepo.Insert(s);
                _prdrepo.Save();
                return RedirectToAction("Index");
            }
            return View(s);
        }

        //3. Edit a sale
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            var sale = _prdrepo.GetById(Id);
            return View(sale);
        }

        [HttpPost]
        public ActionResult Edit(Sales s)
        {
            if (ModelState.IsValid)
            {
                _prdrepo.Update(s);
                _prdrepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(s);
            }
        }

        //4. deleteing a given product
        [HttpGet]
        public ActionResult Delete(string Id)
        {
            var sale = _prdrepo.GetById(Id);
            return View(sale);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(string Id)
        {
            var sale = _prdrepo.GetById(Id);
            _prdrepo.Delete(Id);
            _prdrepo.Save();
            return RedirectToAction("Index");
        }

        //5. details of a given product

        public ActionResult Details(string Id)
        {
            var sale = _prdrepo.GetById(Id);
            return View(sale);
        }
    }
}