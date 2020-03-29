using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using benimalisverissitem.Models;

namespace benimalisverissitem.Controllers
{
    public class DiscountsController : Controller
    {
        private ShoppingContext db = new ShoppingContext();

        // GET: Discounts
        public ActionResult Index()
        {
            return View(db.Indirimler.ToList());
        }

        // GET: Discounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discounts discounts = db.Indirimler.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            return View(discounts);
        }

        // GET: Discounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Discounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Indirim")] Discounts discounts)
        {
            if (ModelState.IsValid)
            {
                db.Indirimler.Add(discounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discounts);
        }

        // GET: Discounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discounts discounts = db.Indirimler.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            return View(discounts);
        }

        // POST: Discounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Indirim")] Discounts discounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discounts);
        }

        // GET: Discounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discounts discounts = db.Indirimler.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            return View(discounts);
        }

        // POST: Discounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Discounts discounts = db.Indirimler.Find(id);
            db.Indirimler.Remove(discounts);
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
    }
}
