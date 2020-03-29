using benimalisverissitem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace benimalisverissitem.Controllers
{
    public class CartController : Controller
    {
        private ShoppingContext db = new ShoppingContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Ürünler.FirstOrDefault(i => i.Id==Id);
            //ürün veritbanında varsa GetCart()la bu ürünü alıyoruz.
            if(product!=null)
            {
                GetCart().AddProduct(product, 1);  
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Ürünler.FirstOrDefault(i => i.Id == Id);
            //ürün veritbanında varsa GetCart()la bu ürünü alıyoruz.
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {//cartı session içine atıyorum
            var cart = (Cart)Session["Cart"];
           //cart boşsa yeni bir kopyası oluşturulup session içine atılır 
            if(cart==null)
            {
                //Cartın yeni bir kopyasını cartın içine atıyorum
                cart = new Cart();
                //bu kopyayı Session içinde  saklıyorum
                Session["Cart"] = cart;
            }
            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            
            
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
               SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            foreach (var pr in cart.CartLines)
            {
                
                order.SiparisNo = "A" + (new Random()).Next(11111, 99999).ToString();
                order.Toplam = cart.Total();
                order.SiparisTarihi = DateTime.Now;
                order.SiparisDurumu = EnumOrderState.Bekliyor;
                order.Username = User.Identity.Name;
                order.ad = entity.ad;
                order.soyad = entity.soyad;



                order.Magaza = pr.Products.UserName;


                order.AdresBasligi = entity.AdresBasligi;
                order.Adres = entity.Adres;
                order.Sehir = entity.Sehir;
                order.Semt = entity.Semt;
                order.Mahalle = entity.Mahalle;
                order.PostaKodu = entity.PostaKodu;

                order.Orderlines = new List<OrderLine>();
            }
            foreach (var pr in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Fiyat= pr.Quantity * pr.Products.Fiyat;
                orderline.Products_Id = pr.Products.Id;
                orderline.magaza = pr.Products.UserName;
                

                order.Orderlines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}