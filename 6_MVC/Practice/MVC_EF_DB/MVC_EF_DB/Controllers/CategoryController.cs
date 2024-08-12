using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EF_DB.Models;

namespace MVC_EF_DB.Controllers
{
    public class CategoryController : Controller
    {
        // obj of context class
        northwindEntities db = new northwindEntities();
        // GET: Category
        //1 Scaffolded View templete for list
        public ActionResult Index()
        {
            List<Category> catlist = db.Categories.ToList();
            return View(catlist);
        }

        //2 fetch data from category
        public ActionResult GetCategoryDetails()
        {
            List<Category> catlist = db.Categories.ToList();
            return View(catlist);
        }

        //3 insert new category
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // delete a record
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Category cat = db.Categories.Find(Id);
            return View(cat);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteCategory(int Id)
        {
            Category cat = db.Categories.Find(Id);
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // update a record
        [HttpGet]
        public ActionResult Update(int Id)
        {
            Category c = db.Categories.Find(Id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Update(Category c)
        {
            Category cat = db.Categories.Find(c.CategoryID);
            cat.CategoryName = c.CategoryName;
            cat.Description = c.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Details
        
        public ActionResult Details(int Id)
        {
            Category c = db.Categories.Find(Id);
            return View(c);
            //return RedirectToAction("Index");
        }
        





    }
}