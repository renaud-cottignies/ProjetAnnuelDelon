using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataSerializer;

namespace ProjetAnnuel5A.Controllers
{
    public class LogementController : Controller
    {
        //
        // GET: /Logement/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Formulaire()
        {
            return View();
        }

        public ActionResult Carte()
        {
            return View();
        }

        public ActionResult DeposerAnnonceLogement()
        {
            return View();
        }

     
        //-Usefull ci dessous
        public ActionResult NouvelleAnnonceColoc()
        {
            return View();
        }
        public ActionResult Find()
        {
            return View();
        }
        public ActionResult NouvelleAnnonceLogement()
        {
            return View();
        }
        //APPELS AJAX
        [HttpPost]
        public JsonResult CreateColocAnnonce(ColocSerializer annonce)
        {
            return Json("ok");
        }
    }
}
