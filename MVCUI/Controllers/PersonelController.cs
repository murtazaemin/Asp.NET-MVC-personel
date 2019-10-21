using MVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCUI.ViewModels;

namespace MVCUI.Controllers
{
    public class PersonelController : Controller
    {
        //
        // GET: /Personel/

        PersonelDbEntity db = new PersonelDbEntity();

        public ActionResult Index()
        {
            var model = db.Personel.Include(x=>x.Departman).ToList();
            return View(model);
        }

        [HttpGet]

        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = new Personel()
            };
            return View("PersonelForm",model);
        }

        [HttpPost]

        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = db.Departman.ToList(),
                    Personel = personel
                };
                return View("PersonelForm", model);
            }

            if (personel.Id == 0)// Personel Ekleme
            {
                db.Personel.Add(personel);
            }
            else
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;        
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var model = new ViewModels.PersonelFormViewModel(){
                Departmanlar = db.Departman.ToList(),
                Personel = db.Personel.Find(id)
            };
            if (model == null)
                return HttpNotFound();
            return View("PersonelForm", model);
        }

        public ActionResult Sil(int id) 
        {
            var silinecekPersonel = db.Personel.Find(id);

            if (silinecekPersonel == null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(silinecekPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
