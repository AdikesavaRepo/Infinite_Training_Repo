using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirst_CC.Models;
using CodeFirst_CC.Repository;
using System.Data.Entity;

namespace CodeFirst_CC.Controllers
{
    public class MovieController : Controller
    {
        IRepository<Movie> _movrepo = null;
        ContextClass db = new ContextClass();
        

        public MovieController()
        {
            _movrepo = new Repository<Movie>();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var mov = _movrepo.GetAll();
            return View(mov);
        }

        //2. create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                _movrepo.Insert(m);
                _movrepo.Save();
                return RedirectToAction("Index");
            }
            return View(m);
        }

       
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var mov = _movrepo.GetById(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                _movrepo.Update(m);
                _movrepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(m);
            }
        }

       
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var mov = _movrepo.GetById(Id);
            return View(mov);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int Id)
        {
            var mov = _movrepo.GetById(Id);
            _movrepo.Delete(Id);
            _movrepo.Save();
            return RedirectToAction("Index");
        }

      

        public ActionResult Details(int Id)
        {
            var mov = _movrepo.GetById(Id);
            return View(mov);
        }

        
        

        
    }
}