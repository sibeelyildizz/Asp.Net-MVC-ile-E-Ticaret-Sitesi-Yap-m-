﻿using System;
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
    
    public class TownsController : Controller
    {
        private ShoppingContext db = new ShoppingContext();
        public PartialViewResult TownsList()
        {
            ViewBag.Id= new SelectList(db.Ilceler, "Id", "Ilce");
            //ViewBag.CinsiyetID = new SelectList(db.Cinsiyetler, "Id", "Cinsiyet");
            return PartialView();

        }


        // GET: Towns
        public ActionResult Index()
        {
            return View(db.Ilceler.ToList());
        }

        // GET: Towns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towns towns = db.Ilceler.Find(id);
            if (towns == null)
            {
                return HttpNotFound();
            }
            return View(towns);
        }

        // GET: Towns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Towns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ilce")] Towns towns)
        {
            if (ModelState.IsValid)
            {
                db.Ilceler.Add(towns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(towns);
        }

        // GET: Towns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towns towns = db.Ilceler.Find(id);
            if (towns == null)
            {
                return HttpNotFound();
            }
            return View(towns);
        }

        // POST: Towns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ilce")] Towns towns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(towns).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(towns);
        }

        // GET: Towns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towns towns = db.Ilceler.Find(id);
            if (towns == null)
            {
                return HttpNotFound();
            }
            return View(towns);
        }

        // POST: Towns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Towns towns = db.Ilceler.Find(id);
            db.Ilceler.Remove(towns);
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
