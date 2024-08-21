using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EF_DB.Models;
using System.Data;
using System.Data.Entity;


namespace MVC_EF_DB.Controllers
{
    public class ProductsController : Controller
    {
        northwindEntities db = new northwindEntities();
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(Pl => Pl.Category).Include(Pl => Pl.Supplier);
            return View(products.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,productName,SupplierID,CategoryID,QuantityPerUnit," +
          "UnitPrice,UnitsinStock,UnitsOnorder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }
    }
}