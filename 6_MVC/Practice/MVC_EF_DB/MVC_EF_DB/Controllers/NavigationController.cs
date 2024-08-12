using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EF_DB.Models;

namespace MVC_EF_DB.Controllers
{
    public class NavigationController : Controller
    {
        northwindEntities db = new northwindEntities();
        // GET: Navigation
        public ActionResult Index()
        {
            return View();
        }

        // fetch data from multiple tables using navigation prop
        public ActionResult MultipleData()
        {
            return View(db.Orders.ToList());
        }
    }
}