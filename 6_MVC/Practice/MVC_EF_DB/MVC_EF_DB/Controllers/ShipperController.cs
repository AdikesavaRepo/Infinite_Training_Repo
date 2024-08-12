using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EF_DB.Models;

namespace MVC_EF_DB.Controllers
{
    public class ShipperController : Controller
    {
        northwindEntities db = new northwindEntities();
        // GET: Shippers
        public ActionResult Index()
        {
            return View(db.Shippers.ToList());
        }

        // create using forms
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        // pass data from the view to the controller using forms collection
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            Shipper s = new Shipper();
            s.ShipperID = Convert.ToInt32(frm["ShipperID"]);
            s.CompanyName = frm["CompanyName"].ToString();
            s.Phone = frm["Phone"].ToString();
            db.Shippers.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // delete
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Shipper s = db.Shippers.Find(Id);
            return View(s);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteShipper(int Id)
        {
            Shipper ship = db.Shippers.Find(Id);
            db.Shippers.Remove(ship);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //update
        public ActionResult Update(int Id)
        {
            Shipper ship = db.Shippers.Find(Id);
            return View(ship);
        }

        // update using normal
        //[HttpPost]
        //public ActionResult Update(Shipper s)
        //{
        //    Shipper ship = db.Shippers.Find(s.ShipperID);
        //    ship.CompanyName = s.CompanyName;
        //    ship.Phone = s.Phone;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //Update using formcollection
        [HttpPost]
        public ActionResult Update(FormCollection frm)
        {
            Shipper ship = db.Shippers.Find(Convert.ToInt32(frm["ShipperId"]));
            ship.CompanyName = Convert.ToString(frm["CompanyName"]);
            ship.Phone = Convert.ToString(frm["Phone"]);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // calling stored Procedure with input

        public ActionResult SP_WithInput()
        {
            return View(db.CustOrdersOrders("ALFKI"));
        }
    }
}