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
        IRepository<Movie> movrepo = null;
        ContextClass db = new ContextClass();
        

        public MovieController()
        {
            movrepo = new Repository<Movie>();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var mov = movrepo.GetAll();
            return View(mov);
        }

        //2. create movie 
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
                movrepo.Insert(m);
                movrepo.Save();
                return RedirectToAction("Index");
            }
            return View(m);
        }

       // editing movie details
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var mov = movrepo.GetById(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                movrepo.Update(m);
                movrepo.Save();
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
            var mov = movrepo.GetById(Id);
            return View(mov);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int Id)
        {
            var mov = movrepo.GetById(Id);
            movrepo.Delete(Id);
            movrepo.Save();
            return RedirectToAction("Index");
        }

      

        public ActionResult Details(int Id)
        {
            var mov = movrepo.GetById(Id);
            return View(mov);
        }


        public ActionResult ReleasedInYear(int year)
        {
            List<Movie> moviesInYear = db.Movies.Where(m => m.DateOfRelease.Year == year).ToList();
            return View(moviesInYear);
        }








    }
}