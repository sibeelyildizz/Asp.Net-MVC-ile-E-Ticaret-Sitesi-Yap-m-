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
    public class GendersController : Controller
    {
        private ShoppingContext db = new ShoppingContext();
        public PartialViewResult GenderList()
        {
            return PartialView(db.Cinsiyetler.ToList());
        }

        // GET: Genders
        public ActionResult Index()
        {
            return View(db.Cinsiyetler.ToList());
        }
       

        // GET: Genders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genders genders = db.Cinsiyetler.Find(id);
            if (genders == null)
            {
                return HttpNotFound();
            }
            return View(genders);
        }

        // GET: Genders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cinsiyet")] Genders genders)
        {
            if (ModelState.IsValid)
            {
                db.Cinsiyetler.Add(genders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genders);
        }

        // GET: Genders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genders genders = db.Cinsiyetler.Find(id);
            if (genders == null)
            {
                return HttpNotFound();
            }
            return View(genders);
        }

        // POST: Genders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,cinsiyet")] Genders genders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genders);
        }

        // GET: Genders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genders genders = db.Cinsiyetler.Find(id);
            if (genders == null)
            {
                return HttpNotFound();
            }
            return View(genders);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genders genders = db.Cinsiyetler.Find(id);
            db.Cinsiyetler.Remove(genders);
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
