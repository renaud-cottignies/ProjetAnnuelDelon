using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsertBase;

namespace ProjetAnnuel5A.Controllers
{
    public class InitDataController : Controller
    {
        //
        // GET: /InitData/

        public ActionResult init()
        {
            InsertDB idb = new InsertDB();

            return View();
        }

    }
}
