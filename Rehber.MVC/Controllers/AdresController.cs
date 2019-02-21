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
    public class AdresController : Controller
    { AdresManager _adresManager;
        // GET: Adres
        public ActionResult Index()
        {
            return View();
        }
KisiManager _kisiManager;
        public AdresController()
        {
            _adresManager = new AdresManager();
            _kisiManager = new KisiManager();
        }
        [HttpGet]
        public ActionResult AdresEkle()
        {
            ViewBag.kisiListesi = DropDownDoldur();
            
            return View();
        }
        [HttpPost]
        public ActionResult AdresEkle(AdresViewModel adresvm)
        {
            //Adres a = new Adres();
            //a.AdresID = adresvm.AdresID;
            //a.İI = adresvm.İl;
            //a.İlce = adresvm.İlce;
            //return View(a);
            TempData["Message"] = _adresManager.AddAdres(new Adres {
                İI = adresvm.İl,
                İlce=adresvm.İlce,
                KisiID=adresvm.KisiID


            });
            return RedirectToAction("../Home/Index");
        }
        //guncelleme ıslemı ıcın sayfaya verılerın cekılecegı kısım
        [HttpGet]
        public ActionResult AdresGuncelle(int id)
        {
            ViewBag.kisiListesi = DropDownDoldur();
            var adres = _adresManager.GetAllAdres(x => x.AdresID == id);
            AdresViewModel adresvm = new AdresViewModel
            {
                AdresID = adres.FirstOrDefault().AdresID,
                İl = adres.FirstOrDefault().İI,
                İlce = adres.FirstOrDefault().İlce,
                KisiID=adres.FirstOrDefault().KisiID
            };
            return View(adresvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdresGuncelle(AdresViewModel adresvm)
        {
            Adres a = new Adres
            {
                AdresID = adresvm.AdresID,
                İI = adresvm.İl,
                İlce = adresvm.İlce,
                KisiID = adresvm.KisiID
            };
            TempData["Message"] = _adresManager.UpdateAdres(a);
            return RedirectToAction("../Home/Index");

        }
        [HttpGet]
        public ActionResult AdresSil(int id)
        {
            var adres = _adresManager.GetAllAdres(x => x.AdresID == id);
            AdresViewModel ads = new AdresViewModel
            {
                AdresID = adres.FirstOrDefault().AdresID,
                İl = adres.FirstOrDefault().İI,
                İlce = adres.FirstOrDefault().İlce,
                KisiID = adres.FirstOrDefault().KisiID

            };
            var Kisi = _kisiManager.GetAllKisi(x => x.KisiID == ads.KisiID).FirstOrDefault();
            ViewBag.AdSoyad = Kisi.Adi + " " + Kisi.Soyadi;
            return View(ads);
        }
        [HttpPost]
        [ActionName("AdresSil")]
        public ActionResult AdresSilinsinMi(int id)
        {
            Adres adres = _adresManager.GetAllAdres(x => x.AdresID == id).FirstOrDefault();
            TempData["Message"] = _adresManager.DeleteAdres(adres);
            return RedirectToAction("../Home/Index");
        }
       [HttpPost]
       [ValidateAntiForgeryToken]
      
        public List<SelectListItem> DropDownDoldur()
        {
            List<SelectListItem> kisilistesi = (from p in _kisiManager.GetAllKisi().ToList()
                                                select new SelectListItem
                                                {
                                                    Text = p.Adi + " " + p.Soyadi,
                                                    Value = p.KisiID.ToString()
                                                }
                                            ).ToList();

            return kisilistesi;
        }
       
    }
}