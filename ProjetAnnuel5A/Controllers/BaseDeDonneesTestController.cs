using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domaine.CoursService;
using BootStraper;
using System.Web.Mvc;
using InsertBase;

namespace ProjetAnnuel5A.Controllers
{
    public class BaseDeDonneesTestController : Controller
    {
        //
        // GET: /BaseDeDonneesTest/

        private ISubjectRepository subjectRepository;
        private ILevelRepository levelRepository;
        private ICoursRepository coursRepository;

        public BaseDeDonneesTestController ()
	    {
            subjectRepository = SubjectRepositoryFactory.Current.GetSubjectRepository();
            levelRepository = LevelRepositoryFactory.Current.GetLevelRepository();
            coursRepository = CoursRepositoryFactory.Current.GetCoursRepository();
	    }

        public ActionResult Index()
        {
            ViewBag.test = coursRepository.GetById(1).titleCours;
            return View();
        }

    }
}
