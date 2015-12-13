using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeerShop.Models;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;

namespace BeerShop.Controllers
{
    public class BeersController : Controller
    {
        private Beercontext db = new Beercontext();
        // GET: Beers
        public ActionResult Index()
        {
            string email = User.Identity.GetUserName();
            User us = db.Users.First(c => c.Email == email);
            ViewBag.isadmin = us.IsAdmin;

            var beers = db.Beers.Include(b => b.Country);
            return View(beers.ToList());
        }

        // GET: Beers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = db.Beers.Find(id);
            string email = User.Identity.GetUserName();
            User us = db.Users.First(c => c.Email == email);
            ViewBag.isadmin = us.IsAdmin;
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // GET: Beers/Create
        public ActionResult Create()
        {
            ViewBag.Country_ID = new SelectList(db.Countries, "ID", "Name");
            return View();
        }

        // POST: Beers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Country_ID,Type_ID,Price")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                db.Beers.Add(beer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Country_ID = new SelectList(db.Countries, "ID", "Name", beer.Country_ID);
            return View(beer);
        }

        // GET: Beers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Country_ID = new SelectList(db.Countries, "ID", "Name", beer.Country_ID);
            return View(beer);
        }

        // POST: Beers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Country_ID,Type_ID,Price")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country_ID = new SelectList(db.Countries, "ID", "Name", beer.Country_ID);
            return View(beer);
        }

        // GET: Beers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // POST: Beers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Beer beer = db.Beers.Find(id);
            db.Beers.Remove(beer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
        public ActionResult Cart()
        {
            //var beers = JsonConvert.DeserializeObject(json);
            var beers = db.Beers.Include(b => b.Country);
            return View(beers.ToList());
        }
        [Authorize]
        public ActionResult Checkout(string json) {
            List<OrderItem> orderitems = new List<OrderItem>();
            Order order = new Order();
            if (json != "") {
                orderitems = JsonConvert.DeserializeObject<List<OrderItem>>(json);
                string email = User.Identity.GetUserName();
                User us = db.Users.First(c => c.Email == email);
                order.User = us;
                double total=0;
                if (ModelState.IsValid) {

                
                    foreach (OrderItem item in orderitems) {
                
                            item.Order = order;
                            db.OrderItem.Add(item);
                        total = total + item.SubTotal;

                    
                    }
                    order.Total = total;
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
