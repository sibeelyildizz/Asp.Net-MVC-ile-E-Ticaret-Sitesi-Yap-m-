using benimalisverissitem.Identity;
using benimalisverissitem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace benimalisverissitem.Controllers
{
    public class AccountController : Controller
    {
        private ShoppingContext db = new ShoppingContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i => i.Username == username)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    SiparisNo = i.SiparisNo,
                    SiparisTarihi= i.SiparisTarihi,
                    SiparisDurumu = i.SiparisDurumu,
                    Toplam= i.Toplam
                }).OrderByDescending(i => i.SiparisTarihi).ToList();

            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    SiparisNo = i.SiparisNo,
                    Toplam = i.Toplam,
                    SiparisTarihi = i.SiparisTarihi,
                    SiparisDurumu = i.SiparisDurumu,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    Mahalle = i.Mahalle,
                    PostaKodu = i.PostaKodu,
                    Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                    {
                        Products_Id= a.Products_Id,
                        UrunAdi = a.Products.UrunAdi.Length > 50 ? a.Products.UrunAdi.Substring(0, 47) + "..." : a.Products.UrunAdi,
                        Resim = a.Products.Resim,
                        Quantity = a.Quantity,
                        Fiyat= a.Fiyat
                    }).ToList()
                }).FirstOrDefault();

            return View(entity);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt işlemleri

                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;
              

                var result = UserManager.Create(user, model.Password);

                if (result.Succeeded) //kayıt işlemi gerçekleşti
                {
                    //kullanıcı oluştu ve kullanıcıyı bir role atanabilir
                    if (RoleManager.RoleExists("User"))
                    {
                        UserManager.AddToRole(user.Id, "User");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı  oluşturma hatası.");
                }

            }

            return View(model);
        }
        public ActionResult MagazaRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MagazaRegister(MagazaRegister model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt işlemleri

                var user = new ApplicationUser();
                user.StoreName= model.StoreName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Address = model.Address;


                var result = UserManager.Create(user, model.Password);

                if (result.Succeeded) //kayıt işlemi gerçekleşti
                {
                    //kullanıcı oluştu ve kullanıcıyı bir role atanabilir
                    if (RoleManager.RoleExists("MagazaUser"))
                    {
                        UserManager.AddToRole(user.Id, "MagazaUser");
                    }
                    return RedirectToAction("MagazaLogin", "Account");
                }
                else
                {
                    ModelState.AddModelError("MagazaRegisterUserError", "Kullanıcı  oluşturma hatası.");
                }

            }

            return View(model);
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
          

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login işlemleri
                var user = UserManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    // varolan kullanıcıyı sisteme dahil et.
                    // ApplicationCookie oluşturup sisteme bırak.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("List", "ClientHome");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }

            return View(model);
        }
        public ActionResult MagazaLogin()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MagazaLogin(MagazaLogin model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    // varolan kullanıcıyı sisteme dahil et.
                    // ApplicationCookie oluşturup sisteme bırak.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ModelState.AddModelError("MagazaLoginUserError", "Böyle bir kullanıcı yok.");
                }

            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login işlemleri
                var user = UserManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    // varolan kullanıcıyı sisteme dahil et.
                    // ApplicationCookie oluşturup sisteme bırak.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }

            return View(model);
        }





        public ActionResult MagazaLogout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("List", "ClientHome");
        }
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("List", "ClientHome");
        }

    }
}

