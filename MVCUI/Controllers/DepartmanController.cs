using MVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Controllers
{
    public class DepartmanController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        //
        // GET: /Departman/

        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            return View(model);
        }


        [HttpGet]

        public ActionResult Yeni()
        {
            return View("DepartmanForm",new Departman());
        }

        [HttpPost]

        public ActionResult Kaydet(Departman departman) 
        {
            if (!ModelState.IsValid) 
            {
                return View("DepartmanForm");
            }
            if (departman.Id == 0)// Departman Ekleme
            {
                db.Departman.Add(departman);
            }
            else // Departman Güncelleme
            {
                var guncellenecekDepartman = db.Departman.Find(departman.Id);
                if (guncellenecekDepartman == null)
                {
                    return HttpNotFound();
                }
                guncellenecekDepartman.Ad = departman.Ad;

            }
            db.SaveChanges();
            return RedirectToAction("Index","Departman");
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("DepartmanForm",model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekDepartman = db.Departman.Find(id);

            if (silinecekDepartman == null)
            {
                return HttpNotFound();
            }
            db.Departman.Remove(silinecekDepartman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
