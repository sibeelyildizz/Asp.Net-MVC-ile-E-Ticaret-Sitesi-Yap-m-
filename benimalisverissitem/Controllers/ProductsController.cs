using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using benimalisverissitem.Models;

namespace benimalisverissitem.Controllers
{
    [Authorize(Roles ="MagazaUser")]
    public class ProductsController : Controller
    {
        private ShoppingContext db = new ShoppingContext();

        // GET: Products


        public ActionResult Index()
        {
            
            var username = User.Identity.Name;
            var products = db.Ürünler
            .Where(i => i.UserName == username)
            .Select(i => new ProductModel()
            {
                UrunAdi = i.UrunAdi,
                Barkod=i.Barkod,
                KategoriId = i.KategoriId,
                CinsiyetID = i.CinsiyetID,
                MarkaID = i.MarkaID,
                BedenID = i.BedenID,
                RenkID = i.RenkID,
                IndirimID = i.IndirimID,
                Il_ID = i.Il_ID,
                Ilce_ID = i.Ilce_ID,
                eklenmeTarihi = i.eklenmeTarihi,
                Aciklama = i.Aciklama,
                Resim = i.Resim
            }).ToList();
            return View(products);
        }
            ////.AsQueryable();

            //if (User.Identity.Name == username)
            //{

            //    var ürünler = db.Ürünler.Include(x => x.Category);
            //    var ürünler2 = db.Ürünler.Include(y => y.Gender);
            //    var ürünler3 = db.Ürünler.Include(z => z.Brand);
            //    var ürünler4 = db.Ürünler.Include(t => t.Size);
            //    var ürünler5 = db.Ürünler.Include(u => u.Color);
            //    var ürünler6 = db.Ürünler.Include(v => v.Discount);
            //    var ürünler7 = db.Ürünler.Include(y => y.City);
            //    var ürünler8 = db.Ürünler.Include(z => z.Town);
            //}
           

        

        // GET: Products/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Ürünler.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            ViewBag.CinsiyetID= new SelectList(db.Cinsiyetler, "Id", "Cinsiyet");
            ViewBag.MarkaID = new SelectList(db.Markalar, "Id", "Marka");
            ViewBag.BedenID = new SelectList(db.Bedenler, "Id", "Beden");
            ViewBag.RenkID = new SelectList(db.Renkler, "Id", "Renk");
            ViewBag.IndirimID = new SelectList(db.Indirimler, "Id", "Indirim");
            ViewBag.Il_ID = new SelectList(db.Iller, "Id", "Il");
            ViewBag.Ilce_ID = new SelectList(db.Ilceler, "Id", "Ilce");


            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrunAdi,Barkod,Aciklama,KategoriId,MarkaID,BedenID,RenkID,CinsiyetID,Resim,ImageFile,MagazaID,Fiyat,Il_ID,Ilce_ID,KampanyaID")] Products products)
        {
            if (ModelState.IsValid)
            {
                products.Barkod = "S" + (new Random()).Next(11111, 99999).ToString();
                products.UserName = User.Identity.Name;
                products.eklenmeTarihi = DateTime.Now;
                string fileName = Path.GetFileNameWithoutExtension(products.ImageFile.FileName);
                string extension = Path.GetExtension(products.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                products.Resim = "~/RESIMLER/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/RESIMLER/"), fileName);
                products.ImageFile.SaveAs(fileName);

                db.Ürünler.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Ürünler.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            ViewBag.CinsiyetID = new SelectList(db.Cinsiyetler, "Id", "Cinsiyet");
            ViewBag.MarkaID = new SelectList(db.Markalar, "Id", "Marka");
            ViewBag.BedenID = new SelectList(db.Bedenler, "Id", "Beden");
            ViewBag.RenkID = new SelectList(db.Renkler, "Id", "Renk");
            ViewBag.IndirimID = new SelectList(db.Indirimler, "Id", "Indirim");
            ViewBag.Il_ID = new SelectList(db.Iller, "Id", "Il");
            ViewBag.Ilce_ID = new SelectList(db.Ilceler, "Id", "Ilce");

            return View(products);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UrunAdi,Barkod,Aciklama,KategoriId,MarkaID,BedenID,RenkID,CinsiyetID,Resim,MagazaID,Fiyat,Il_ID,Ilce_ID,KampanyaID")] Products products)
        {
            if (ModelState.IsValid)
            {

                var entity = db.Ürünler.Find(products.Id);
                if(entity!=null)
                {
                    entity.UrunAdi = products.UrunAdi;
                    entity.Barkod= products.Barkod;
                    entity.Aciklama= products.Aciklama;
                    entity.KategoriId= products.KategoriId;
                    entity.MarkaID= products.MarkaID;
                    entity.BedenID= products.BedenID;
                    entity.RenkID= products.RenkID;
                    entity.CinsiyetID= products.CinsiyetID;
                    entity.Resim= products.Resim;
               
                    entity.Fiyat= products.Fiyat;
                    entity.Il_ID= products.Il_ID;
                    entity.Ilce_ID= products.Ilce_ID;
                    entity.IndirimID = products.IndirimID;
                    db.SaveChanges();
                    TempData["Products"] = entity;
                   return RedirectToAction("Index");
                }
            }
        
        ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", products.KategoriId);
            return View(products);
            
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Ürünler.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Ürünler.Find(id);
            db.Ürünler.Remove(products);
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
