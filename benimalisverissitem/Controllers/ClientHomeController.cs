using benimalisverissitem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace benimalisverissitem.Controllers
{
    public class ClientHomeController : Controller
    {
        private ShoppingContext context = new ShoppingContext();
        //  private object urunler1;

        // GET: ClientHome
        public ActionResult Index()
        {
            //var products = new Products();
            //var il = products.Il_ID;

            //  .Where(i => i.Il_ID == il)         ////lazım olacak bana
            var urunler = context.Ürünler

                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    UrunAdi = i.UrunAdi,
                    Aciklama = i.Aciklama,
                    KategoriId = i.KategoriId,
                    MarkaID = i.MarkaID,
                    BedenID = i.BedenID,
                    RenkID = i.RenkID,
                    CinsiyetID = i.CinsiyetID,
                    Resim = i.Resim,

                    Fiyat = i.Fiyat,
                    Il_ID = i.Il_ID,
                    Ilce_ID = i.Ilce_ID,
                    IndirimID = i.IndirimID,
                });
            
            return View(urunler.ToList());
        }
        public ActionResult AddToFav(int id,Favorites entity)
        {

            if (ModelState.IsValid)
            {
                
                SaveFav(id,entity);
            }
            return RedirectToAction("Index");
        }
        private void SaveFav(int id, Favorites entity)
        {
            var fav = new Favorites();
            var urunler = new Products();
            var urunadi = urunler.UrunAdi;
            var aciklama = urunler.Aciklama;
            var resim = urunler.Resim;
            var fiyat = urunler.Fiyat;

         
                fav.Username = User.Identity.Name;

                fav.Products_Id1 = id;
                fav.UrunAdi = urunadi;
                fav.Aciklama = aciklama;
                fav.Resim = resim;
                fav.Fiyat = fiyat;

                context.Favorites.Add(fav);
                context.SaveChanges();
            
            
        }
        public ActionResult FavList()
        {



            var fav = new Favorites();
            var username = User.Identity.Name;
            var products = new ProductModel();
            var id = fav.Products_Id1;
              fav.Products_Id1 = id;

            var favs = context.Favorites
           .Where(i => i.Username == username)
            .Select(i => new Favorites()
            {
                Id = i.Id,
                UrunAdi = i.UrunAdi,
                Aciklama = i.Aciklama,
                Resim = i.Resim,
                Fiyat = i.Fiyat

            }).ToList();
            

            return View(favs);

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = context.Ürünler.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }

            return View(context.Ürünler.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult Index2()
        {
            ViewBag.KategoriId = new SelectList(context.Kategoriler, "Id", "KategoriAdi");
            return View();


        }








      

        public ActionResult List(int[] categories, int[] genders,int[] brands)
        {

            List<Products> urunler = new List<Products>();


            if (categories == null && genders == null)
            {
                urunler = context.Ürünler.ToList();
            }
            else if (categories == null )
            {
                var query = context.Ürünler.Where(p => genders.Any(g => g == p.CinsiyetID)).ToList();
                urunler.AddRange(query);
            }
            else if (genders == null )
            {
                var query = context.Ürünler.Where(p => categories.Any(g => g == p.KategoriId)).ToList();
                urunler.AddRange(query);
            }
            //else if (categories == null && genders == null)
            //{
            //    var query = context.Ürünler.Where(p => brands.Any(g => g == p.MarkaID)).ToList();
            //    urunler.AddRange(query);
            //}
            //else if (categories != null && brands != null)
            //{
            //    var query = context.Ürünler.Where(p => brands.Any(g => g == p.MarkaID)&& categories.Any(g => g == p.KategoriId)).ToList();
            //    urunler.AddRange(query);
            //}
            else
            {
                var query = context.Ürünler.Where(p => categories.Any(g => g == p.KategoriId) && genders.Any(g => g == p.CinsiyetID)).ToList();
                urunler.AddRange(query);
            }


            return View(urunler);


        }
        public ActionResult List2(int? id)
        {
            var urunler = context.Ürünler

                   .Select(i => new ProductModel()
                   {

                       UrunAdi = i.UrunAdi,
                       Aciklama = i.Aciklama,
                       KategoriId = i.KategoriId,
                       MarkaID = i.MarkaID,
                       BedenID = i.BedenID,
                       RenkID = i.RenkID,
                       CinsiyetID = i.CinsiyetID,
                       Resim = i.Resim,
                 //      MagazaID = i.MagazaID,
                       Fiyat = i.Fiyat,
                       Il_ID = i.Il_ID,
                       Ilce_ID = i.Ilce_ID,
                       IndirimID = i.IndirimID,
                   }).AsQueryable();
            if (id != null )
            {
                urunler = urunler.Where(i => i.Ilce_ID == id );
            }
            return View(urunler.ToList());
        }


    }

   
}