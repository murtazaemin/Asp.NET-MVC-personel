using MVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCUI.Controllers
{
    public class SecurityController : Controller
    {

        PersonelDbEntity db = new PersonelDbEntity();
        // GET: /Security/
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var kullaniciDb = db.Kullanici.FirstOrDefault(x=>x.Ad == kullanici.Ad && x.Sifre == kullanici.Sifre);
            if(kullaniciDb != null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciDb.Ad, false);
                return RedirectToAction("Index","Departman");
            }
            else 
            {
                return View();
            }

        }

        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}
