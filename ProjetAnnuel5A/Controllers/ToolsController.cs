using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetAnnuel5A.Controllers
{
    public class ToolsController : Controller
    {
        //
        // GET: /Tools/
        [HttpPost]
        public ActionResult GetCityFromPattern()
        {
            //Renvoie un json des noms de villes repondant au pattern defini + idVille
            return View();
        }

    }
}
