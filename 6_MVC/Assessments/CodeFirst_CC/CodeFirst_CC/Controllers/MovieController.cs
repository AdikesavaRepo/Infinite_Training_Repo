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

        //3. Edit a product
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

        //4. deleteing a given product
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

        //5. details of a given product

        public ActionResult Details(int Id)
        {
            var mov = _movrepo.GetById(Id);
            return View(mov);
        }

        //display movie in given year
        

        public ActionResult MovieYear(int year)
        {
            List<Movie> my = db.Movies.Where(mov => mov.DateOfRelease.Year == year).ToList();
            return View(my);
        }
    }
}