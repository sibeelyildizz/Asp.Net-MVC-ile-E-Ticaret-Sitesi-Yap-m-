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
    public class SizesController : Controller
    {
        private ShoppingContext db = new ShoppingContext();

        public PartialViewResult SizeList()
        {
            return PartialView(db.Bedenler.ToList());
        }
        // GET: Sizes
        public ActionResult Index()
        {
            return View(db.Bedenler.ToList());
        }

        // GET: Sizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sizes sizes = db.Bedenler.Find(id);
            if (sizes == null)
            {
                return HttpNotFound();
            }
            return View(sizes);
        }

        // GET: Sizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Beden")] Sizes sizes)
        {
            if (ModelState.IsValid)
            {
                db.Bedenler.Add(sizes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sizes);
        }

        // GET: Sizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sizes sizes = db.Bedenler.Find(id);
            if (sizes == null)
            {
                return HttpNotFound();
            }
            return View(sizes);
        }

        // POST: Sizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Beden")] Sizes sizes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sizes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sizes);
        }

        // GET: Sizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sizes sizes = db.Bedenler.Find(id);
            if (sizes == null)
            {
                return HttpNotFound();
            }
            return View(sizes);
        }

        // POST: Sizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sizes sizes = db.Bedenler.Find(id);
            db.Bedenler.Remove(sizes);
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
