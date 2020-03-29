using benimalisverissitem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace benimalisverissitem.Controllers
{
    [Authorize(Roles = "MagazaUser")]
    public class OrderController : Controller
    {
        private ShoppingContext db = new ShoppingContext();
        // GET: Order
        public ActionResult Index()
        {


            var order = new Order();
            var username = User.Identity.Name;
            var products = new ProductModel();

            var magaza = products.UserName;
            order.Magaza = magaza;


            var orders = db.Orders

             
            .Where(i => i.Magaza== username)
            
            .Select(i => new MagazaOrderModel()
            {
                Id = i.Id,
                SiparisNo=i.SiparisNo,
                SiparisTarihi=i.SiparisTarihi,
                SiparisDurumu=i.SiparisDurumu,
                Toplam=i.Toplam,
                Count=i.Orderlines.Count
            

            }).OrderByDescending(i=>i.SiparisTarihi).ToList();
            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                   .Select(i => new OrderDetailsModel()
                   {
                       OrderId = i.Id,
                       UserName=i.Username,
                       SiparisNo = i.SiparisNo,
                       Toplam = i.Toplam,
                       SiparisTarihi = i.SiparisTarihi,
                       SiparisDurumu = i.SiparisDurumu,
                       AdresBasligi = i.AdresBasligi,
                       Adres = i.Adres,
                       Sehir = i.Sehir,
                       Semt = i.Semt,
                       ad=i.ad,
                       soyad=i.soyad,
                       Mahalle = i.Mahalle,
                       PostaKodu = i.PostaKodu,
                       Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                       {
                           Products_Id = a.Products_Id,
                           UrunAdi = a.Products.UrunAdi.Length > 50 ? a.Products.UrunAdi.Substring(0, 47) + "..." : a.Products.UrunAdi,
                           Resim = a.Products.Resim,
                           Quantity = a.Quantity,
                           Fiyat = a.Fiyat
                       }).ToList()
                   }).FirstOrDefault();

            return View(entity);
        }
        public ActionResult UpdateOrderState(int OrderId, EnumOrderState SiparisDurumu)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);

            if (order != null)
            {
                order.SiparisDurumu = SiparisDurumu;
                db.SaveChanges();

                TempData["message"] = "Bilgileriniz Kayıt Edildi";

                return RedirectToAction("Details", new { id = OrderId });
            }

            return RedirectToAction("Index");
        }
    }
}