using Rehber.DAL.KisiService;
using Rehber.Entities.Entities;
using Rehber.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rehber.MVC.Controllers
{
    public class KisiController : Controller
    {
        // GET: Kisi
        AdresManager _adresManager;
        KisiManager _kisiManager;
        public ActionResult Index()
        {
            return View();
        }
        public KisiController()
        {
            _adresManager = new AdresManager();
            _kisiManager = new KisiManager();
        }

        [HttpGet]
        public ActionResult KisiEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KisiEkle(KisiViewModel kisivm)
        {
            string mesaj = _kisiManager.AddKisi(new Kisi { Adi = kisivm.Adi, Soyadi = kisivm.Soyadi, Yas = kisivm.Yas });
            TempData["Message"] = mesaj;
            return RedirectToAction("../Home/Index");
        }

        [HttpGet]
        public ActionResult KisiGuncelle(int id)
        {
            var kisi = _kisiManager.GetAllKisi(x => x.KisiID == id);
                 KisiViewModel kis = new KisiViewModel
                 {
                     KisiID = kisi.FirstOrDefault().KisiID,
                     Adi = kisi.FirstOrDefault().Adi,
                     Soyadi = kisi.FirstOrDefault().Soyadi,
                     Yas = kisi.FirstOrDefault().Yas
                 };
            return View(kis);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KisiGuncelle(KisiViewModel kisis)
        {
            Kisi k = new Kisi
            {
                KisiID = kisis.KisiID,
                Adi = kisis.Adi,
                Soyadi = kisis.Soyadi,
                Yas = kisis.Yas
            };
            TempData["Message"] = _kisiManager.Update(k);
            return RedirectToAction("../Home/Index");

        }
        [HttpGet]
        public ActionResult KisiSil(int id)
        {
            var kisi = _kisiManager.GetAllKisi(x => x.KisiID == id);
            KisiViewModel ki = new KisiViewModel
            {
                KisiID = kisi.FirstOrDefault().KisiID,
                Adi = kisi.FirstOrDefault().Adi,
                Soyadi = kisi.FirstOrDefault().Soyadi,
                Yas = kisi.FirstOrDefault().Yas

            };
          
            return View(ki);
        }
        [HttpPost]
        [ActionName("KisiSil")]
        public ActionResult KisiSilinsinMi(int id)
        {
            Kisi kisi = _kisiManager.GetAllKisi(x => x.KisiID == id).FirstOrDefault();
            TempData["Message"] = _kisiManager.DeleteKisi(kisi);
            return RedirectToAction("../Home/Index");
        }
    }
}