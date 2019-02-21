using Rehber.DAL.KisiService;
using Rehber.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rehber.MVC.Controllers
{
    public class HomeController : Controller
    {
        KisiManager _kisiManager;
        AdresManager _adresManager;

        public HomeController()
        {
            _kisiManager = new KisiManager();
            _adresManager = new AdresManager();
        }
        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel hm = new HomeViewModel();
            hm.Adresler = _adresManager.GetAllAdres().ToList();
            hm.Kisiler = _kisiManager.GetAllKisi().ToList();
            return View(hm);
        }
    }
}