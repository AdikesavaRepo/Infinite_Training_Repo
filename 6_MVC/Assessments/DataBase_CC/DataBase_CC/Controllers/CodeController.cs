using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBase_CC.Models;

namespace DataBase_CC.Controllers
{
    public class CodeController : Controller
    {
        northwindEntities db = new northwindEntities();
        
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CustomersInGermany()
        {
            var cust = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(cust);
        }

        [HttpGet]
        public ActionResult CustomerDetails()
        {
            var orders = db.Orders.Find(10248);
            var orderdetails = orders.Customer;
            return View(orderdetails);

        }
    }
}