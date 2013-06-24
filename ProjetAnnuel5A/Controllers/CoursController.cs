using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataDisplayer;
using Domaine.CoursService;
using BootStraper;
using System.Web.Script.Serialization;
using DataSerializer;

using System.Dynamic;
using DataSerializer.Cours;

namespace ProjetAnnuel5A.Controllers
{
    public class CoursController : Controller
    {
        //
        // GET: /Cours/

        // On déclare les Repository
        private ISubjectRepository subjectRepository;
        private ILevelRepository levelRepository;
        private ICoursRepository coursRepository;

        public CoursController()
        {
            subjectRepository = SubjectRepositoryFactory.Current.GetSubjectRepository();
            levelRepository = LevelRepositoryFactory.Current.GetLevelRepository();
            coursRepository = CoursRepositoryFactory.Current.GetCoursRepository();
        }

        /*
         * Affichage de la liste des Themes
         */
        public ActionResult Browse()
        {


            // On récupère dans la BDD, la liste de tous les Subjects
            List<Subject> listOfSubject = subjectRepository.GetAll().ToList<Subject>();

            // On crée une liste des ThemeDisplayer, qui contiendra la liste des ThemeDisplayer
            // retournée
            List<ThemeDisplayer> listOfThemeDisplayer = new List<ThemeDisplayer>();

            // Remplissage de la liste des ThemeDisplayer
            foreach (Subject tempSubject in listOfSubject)
            {
                ThemeDisplayer tempThemeDisplayer = new ThemeDisplayer();
                tempThemeDisplayer.themeID = tempSubject.ID;
                tempThemeDisplayer.nom = tempSubject.Name;
                tempThemeDisplayer.iconUrl = tempSubject.IconPath;
                tempThemeDisplayer.nombreDeCours = coursRepository.GetCoursBySubjectID(tempSubject.ID).ToList<Cours>().Count();
                listOfThemeDisplayer.Add(tempThemeDisplayer);
            }
            ViewBag.listThemes = listOfThemeDisplayer;
            return View();
        }

        /*
         * Affichage de la liste des cours pour un ID_SUBJECT donné
         */
        public ActionResult List(int themeID)
        {
            List<Cours> listOfCours = coursRepository.GetCoursBySubjectID(themeID).ToList();
            // Je récupère les valeurs du Theme ici, pour ne pas le faire à chaque passe de Cours vers
            // CoursEspacePersoDisplayer
            Subject tempSubject = subjectRepository.GetById(themeID);

            ViewBag.iconThemeGeneral = tempSubject.IconPath;

            string subjectIconUrl = tempSubject.IconPath;
            string subjectName = tempSubject.Name;
            //List<Cours> listOfSubject = new List<Cours>();

            List<CoursEspacePersoDisplayer> listOfCoursDisplayer = new List<CoursEspacePersoDisplayer>();

            // Remplissage des objets CoursEspacePersoDisplayer
            foreach (Cours tempCours in listOfCours)
            {
                CoursEspacePersoDisplayer tempCoursDisplayer = new CoursEspacePersoDisplayer();
                tempCoursDisplayer.id = tempCours.ID;
                tempCoursDisplayer.urlIcon = subjectIconUrl;
                tempCoursDisplayer.theme = subjectName;
                tempCoursDisplayer.niveau = levelRepository.GetLevelName(tempCours.idLevel);
                tempCoursDisplayer.droits = tempCours.visibility.ToString();
                tempCoursDisplayer.votesPour = tempCours.vote_positif;
                tempCoursDisplayer.votesContre = tempCours.vote_negatif;
                tempCoursDisplayer.nom = tempCours.titleCours;
                listOfCoursDisplayer.Add(tempCoursDisplayer);
            }
            ViewBag.listCoursByTheme = listOfCoursDisplayer;
            ViewBag.themeid = themeID;
            ViewBag.Theme = subjectRepository.GetById(themeID).Name;
            // On récupère dans la BDD, la liste de tous les Levels
            List<Level> listOfLevel = levelRepository.GetAll().ToList<Level>();



            // On crée une liste des NiveauDisplayer, qui contiendra la liste des NiveauDisplayer
            // retournée
            List<NiveauDisplayer> listOfNiveauDisplayer = new List<NiveauDisplayer>();

            foreach (Level tempLevel in listOfLevel)
            {
                NiveauDisplayer tempNiveauDisplayer = new NiveauDisplayer();
                tempNiveauDisplayer.niveauID = tempLevel.ID;
                tempNiveauDisplayer.niveauName = tempLevel.Name;
                listOfNiveauDisplayer.Add(tempNiveauDisplayer);
            }

            ViewBag.listNiveaux = listOfNiveauDisplayer;

            return View();
        }

        public ActionResult BrowseBySubjectAndLevel(int idSubject, int idLevel)
        {
            List<Cours> listOfCours = coursRepository.GetCoursBySubjectIDandLevelID(idSubject, idLevel).ToList();
            // Je récupère les valeurs du Theme ici, pour ne pas le faire à chaque passage de Cours vers
            // CoursEspacePersoDisplayer
            string subjectIconUrl = subjectRepository.GetById(idSubject).IconPath;
            string subjectName = subjectRepository.GetById(idSubject).Name;
            string levelName = levelRepository.GetLevelName(idLevel);

            List<CoursEspacePersoDisplayer> listOfCoursDisplayer = new List<CoursEspacePersoDisplayer>();

            // Remplissage des objects CoursEspacePersoDisplayer
            foreach (Cours tempCours in listOfCours)
            {
                CoursEspacePersoDisplayer tempCoursDisplayer = new CoursEspacePersoDisplayer();
                tempCoursDisplayer.id = tempCours.ID;
                tempCoursDisplayer.urlIcon = subjectIconUrl;
                tempCoursDisplayer.theme = subjectName;
                tempCoursDisplayer.niveau = levelName;
                tempCoursDisplayer.droits = tempCours.visibility.ToString();
                tempCoursDisplayer.votesPour = tempCours.vote_positif;
                tempCoursDisplayer.votesContre = tempCours.vote_negatif;

                listOfCoursDisplayer.Add(tempCoursDisplayer);
            }
            ViewBag.listCoursByThemeAndLevel = listOfCoursDisplayer;
            return View();
        }

        public ActionResult BrowseBySubjectAndLevelOrderByDateLastModiASC(int idSubject, int idLevel)
        {
            List<Cours> listOfCours = coursRepository.GetCoursBySubjectIDandLevelIDorderByDateLastModifASC(idSubject, idLevel).ToList();
            // Je récupère les valeurs du Theme ici, pour ne pas le faire à chaque passage de Cours vers
            // CoursEspacePersoDisplayer
            Subject tempSubject = subjectRepository.GetById(idSubject);
            string subjectIconUrl = tempSubject.IconPath;
            string subjectName = tempSubject.Name;
            string levelName = levelRepository.GetLevelName(idLevel);

            List<CoursEspacePersoDisplayer> listOfCoursDisplayer = new List<CoursEspacePersoDisplayer>();

            // Remplissage des objects CoursEspacePersoDisplayer
            foreach (Cours tempCours in listOfCours)
            {
                CoursEspacePersoDisplayer tempCoursDisplayer = new CoursEspacePersoDisplayer();
                tempCoursDisplayer.id = tempCours.ID;
                tempCoursDisplayer.urlIcon = subjectIconUrl;
                tempCoursDisplayer.theme = subjectName;
                tempCoursDisplayer.niveau = levelName;
                tempCoursDisplayer.droits = tempCours.visibility.ToString();
                tempCoursDisplayer.votesPour = tempCours.vote_positif;
                tempCoursDisplayer.votesContre = tempCours.vote_negatif;

                listOfCoursDisplayer.Add(tempCoursDisplayer);
            }
            ViewBag.listCoursByThemeAndLevel = listOfCoursDisplayer;
            return View();
        }

        public ActionResult BrowseBySubjectAndLevelOrderByDateLastModiDESC(int idSubject, int idLevel)
        {
            List<Cours> listOfCours = coursRepository.GetCoursBySubjectIDandLevelIDorderByDateLastModifDESC(idSubject, idLevel).ToList();
            // Je récupère les valeurs du Theme ici, pour ne pas le faire à chaque passage de Cours vers
            // CoursEspacePersoDisplayer
            Subject tempSubject = subjectRepository.GetById(idSubject);
            string subjectIconUrl = tempSubject.IconPath;
            string subjectName = tempSubject.Name;
            string levelName = levelRepository.GetLevelName(idLevel);

            List<CoursEspacePersoDisplayer> listOfCoursDisplayer = new List<CoursEspacePersoDisplayer>();

            // Remplissage des objects CoursEspacePersoDisplayer
            foreach (Cours tempCours in listOfCours)
            {
                CoursEspacePersoDisplayer tempCoursDisplayer = new CoursEspacePersoDisplayer();
                tempCoursDisplayer.id = tempCours.ID;
                tempCoursDisplayer.urlIcon = subjectIconUrl;
                tempCoursDisplayer.theme = subjectName;
                tempCoursDisplayer.niveau = levelName;
                tempCoursDisplayer.droits = tempCours.visibility.ToString();
                tempCoursDisplayer.votesPour = tempCours.vote_positif;
                tempCoursDisplayer.votesContre = tempCours.vote_negatif;

                listOfCoursDisplayer.Add(tempCoursDisplayer);
            }
            ViewBag.listCoursByThemeAndLevel = listOfCoursDisplayer;
            return View();
        }



        public ActionResult DocEditor()
        {
            // On récupère dans la BDD, la liste de tous les Subjects
            List<Subject> listOfSubject = subjectRepository.GetAll().ToList<Subject>();
            // On récupère dans la BDD, la liste de tous les Levels
            List<Level> listOfLevel = levelRepository.GetAll().ToList<Level>();

            // On crée une liste des ThemeDisplayer, qui contiendra la liste des ThemeDisplayer
            // retournée
            List<ThemeDisplayer> listOfThemeDisplayer = new List<ThemeDisplayer>();

            // On crée une liste des NiveauDisplayer, qui contiendra la liste des NiveauDisplayer
            // retournée
            List<NiveauDisplayer> listOfNiveauDisplayer = new List<NiveauDisplayer>();

            // Remplissage de la liste des ThemeDisplayer
            foreach (Subject tempSubject in listOfSubject)
            {
                ThemeDisplayer tempThemeDisplayer = new ThemeDisplayer();
                tempThemeDisplayer.themeID = tempSubject.ID;
                tempThemeDisplayer.nom = tempSubject.Name;
                tempThemeDisplayer.iconUrl = tempSubject.IconPath;
                tempThemeDisplayer.nombreDeCours = coursRepository.GetCoursBySubjectID(tempSubject.ID).ToList<Cours>().Count();
                listOfThemeDisplayer.Add(tempThemeDisplayer);
            }
            ViewBag.listThemes = listOfThemeDisplayer;

            foreach (Level tempLevel in listOfLevel)
            {
                NiveauDisplayer tempNiveauDisplayer = new NiveauDisplayer();
                tempNiveauDisplayer.niveauID = tempLevel.ID;
                tempNiveauDisplayer.niveauName = tempLevel.Name;
                listOfNiveauDisplayer.Add(tempNiveauDisplayer);
            }

            ViewBag.listNiveaux = listOfNiveauDisplayer;
            ViewBag.icoSrc = "#";//URL de l'icone du theme
            return View();
        }




        public ActionResult Private()
        {

            if (Session["userID"] != null)
            {
                // Cette fonction n'est pas encore implémentée, il suffira de decommenter lorsqu'elle le sera
                //Ci dessous APPEL RENO
                List<Cours> listOfSubject = coursRepository.GetCoursByUserID((int)Session["userID"]).ToList<Cours>();

                List<CoursEspacePersoDisplayer> listOfCoursDisplayer = new List<CoursEspacePersoDisplayer>();

                // Remplissage des objets CoursEspacePersoDisplayer
                foreach (Cours tempCours in listOfSubject)
                {
                    // On crée aussi un objet Subject pour récuperer le nom + l'icone
                    Subject tempSubject = subjectRepository.GetById(tempCours.idSubject);

                    CoursEspacePersoDisplayer tempCoursDisplayer = new CoursEspacePersoDisplayer();
                    tempCoursDisplayer.id = tempCours.ID;
                    tempCoursDisplayer.nom = tempCours.titleCours;
                    tempCoursDisplayer.urlIcon = tempSubject.IconPath;
                    tempCoursDisplayer.theme = tempSubject.Name;
                    tempCoursDisplayer.niveau = levelRepository.GetLevelName(tempCours.idLevel);
                    tempCoursDisplayer.droits = tempCours.visibility.ToString();
                    tempCoursDisplayer.votesPour = tempCours.vote_positif;
                    tempCoursDisplayer.votesContre = tempCours.vote_negatif;

                    listOfCoursDisplayer.Add(tempCoursDisplayer);
                }
                ViewBag.listPerso = listOfCoursDisplayer;
                return View();
            }
            else
            {
                return HttpNotFound();
             }
        }

        [HttpPost]
        public ActionResult CreateCours(CoursSerializer cours)
        //public ActionResult CreateCours(int niveauID, int themeId, int visibiliteID, string titre, string contenu)
        {
            if (Session["userID"] != null)
            {
                Cours savedCours = new Cours(cours.titre, cours.contenu, cours.themeId, cours.visibiliteID, DateTime.Now, (int)Session["userID"], cours.niveauID);
                //Cours savedCours = new Cours(cours.titre, cours.contenu, cours.themeId, cours.visibiliteID, DateTime.Now, 1, cours.niveauID, DateTime.Now);
                bool creationSucceed = coursRepository.Save(savedCours);
                System.Diagnostics.Debug.WriteLine("bool : " + creationSucceed);
                if (creationSucceed)
                {
                    return Json("Creation Succeed", JsonRequestBehavior.DenyGet);
                }
                return Json("Creation failed", JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json("Creation Succeed", JsonRequestBehavior.DenyGet);

               return Json("YOU ARE NOT LOGGED BITCH");
            }
        }

        public ActionResult Display(int coursID)
        {
            // Récupération du Cours sur la BDD
            Cours tempCours = coursRepository.GetById(coursID);

            // Remplissage du CoursDisplayer
            CoursDisplayer tempCoursDisplayer = new CoursDisplayer();
            tempCoursDisplayer.coursID = tempCours.ID;
            tempCoursDisplayer.themeID = tempCours.idSubject;
            tempCoursDisplayer.niveauID = tempCours.idLevel;
            tempCoursDisplayer.niveauName = levelRepository.GetLevelName(tempCours.idLevel);
            tempCoursDisplayer.titre = tempCours.titleCours;
            tempCoursDisplayer.contenu = tempCours.coreCours;
            tempCoursDisplayer.nbVotesPour = tempCours.vote_positif;
            tempCoursDisplayer.nbVotesContre = tempCours.vote_negatif;
            tempCoursDisplayer.dateDerniereModif = tempCours.ModificationDate;

            ViewBag.displayedCours = tempCoursDisplayer;
            return View();
        }

        public ActionResult DocChange(int doc)
        {
            if(Session["userID"]!=null)
            {
            // On récupère dans la BDD, la liste de tous les Subjects
            List<Subject> listOfSubject = subjectRepository.GetAll().ToList<Subject>();
            // On récupère dans la BDD, la liste de tous les Levels
            List<Level> listOfLevel = levelRepository.GetAll().ToList<Level>();

            // On crée une liste des ThemeDisplayer, qui contiendra la liste des ThemeDisplayer
            // retournée
            List<ThemeDisplayer> listOfThemeDisplayer = new List<ThemeDisplayer>();

            // On crée une liste des NiveauDisplayer, qui contiendra la liste des NiveauDisplayer
            // retournée
            List<NiveauDisplayer> listOfNiveauDisplayer = new List<NiveauDisplayer>();

            // Remplissage de la liste des ThemeDisplayer
            foreach (Subject tempSubject in listOfSubject)
            {
                ThemeDisplayer tempThemeDisplayer = new ThemeDisplayer();
                tempThemeDisplayer.themeID = tempSubject.ID;
                tempThemeDisplayer.nom = tempSubject.Name;
                tempThemeDisplayer.iconUrl = tempSubject.IconPath;
                tempThemeDisplayer.nombreDeCours = coursRepository.GetCoursBySubjectID(tempSubject.ID).ToList<Cours>().Count();
                listOfThemeDisplayer.Add(tempThemeDisplayer);
            }
            ViewBag.listThemes = listOfThemeDisplayer;

            foreach (Level tempLevel in listOfLevel)
            {
                NiveauDisplayer tempNiveauDisplayer = new NiveauDisplayer();
                tempNiveauDisplayer.niveauID = tempLevel.ID;
                tempNiveauDisplayer.niveauName = tempLevel.Name;
                listOfNiveauDisplayer.Add(tempNiveauDisplayer);
            }

            ViewBag.listNiveaux = listOfNiveauDisplayer;
            ViewBag.icoSrc = "#";//URL de l'icone du theme
            // Récupération du Cours sur la BDD
            Cours tempCours = coursRepository.GetById(doc);

            // Remplissage du CoursDisplayer
            CoursDisplayer tempCoursDisplayer = new CoursDisplayer();
            tempCoursDisplayer.coursID = tempCours.ID;
            tempCoursDisplayer.themeID = tempCours.idSubject;
            tempCoursDisplayer.niveauID = tempCours.idLevel;
            tempCoursDisplayer.niveauName = levelRepository.GetLevelName(tempCours.idLevel);
            tempCoursDisplayer.titre = tempCours.titleCours;
            tempCoursDisplayer.contenu = tempCours.coreCours;
            tempCoursDisplayer.nbVotesPour = tempCours.vote_positif;
            tempCoursDisplayer.nbVotesContre = tempCours.vote_negatif;
            tempCoursDisplayer.dateDerniereModif = tempCours.ModificationDate;

            ViewBag.displayedCours = tempCoursDisplayer;
                if (tempCours.Idcreator == (int)Session["userID"])
                {
                    ViewBag.documentID = doc;
                    return View();
                }
                else
                {
                    return HttpNotFound();
                }
            
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult updateCours(CoursUpdateSerializer cours)
        {
            Cours monCours = null;
            monCours = coursRepository.GetById(cours.coursID);
            if ((Session["userID"] != null)&&(monCours.Idcreator==(int)Session["userID"])&&(monCours!=null))
            {
                monCours.idLevel = cours.niveauID;
                monCours.idSubject = cours.themeId;
                monCours.titleCours = cours.titre;
                monCours.visibility = cours.visibiliteID;
                monCours.coreCours = cours.contenu;
                monCours.ModificationDate = DateTime.Now;
                coursRepository.Update(monCours);
                return Json(new { success = true, message = "Cours mis à jour" });
            }
            return Json(new { success = false, message = "Cours supprimé" });
                
        }

        [HttpPost]
        public ActionResult getAllCoursFromTheme(int themeID)
        {

            List<Cours> listCours = coursRepository.GetCoursBySubjectID(themeID).ToList<Cours>();

                // Tri par DATES
                listCours.Sort((x, y) => y.CreationDate.CompareTo(x.CreationDate));

                List<CoursAjax> listCoursAjax = new List<CoursAjax>();

                foreach (Cours tempCours in listCours)
                {
                    CoursAjax tempCoursAjax = new CoursAjax();
                    tempCoursAjax.titre = tempCours.titleCours;
                    tempCoursAjax.levelId = tempCours.idLevel + "";
                    tempCoursAjax.themeID = tempCours.idSubject + "";
                    tempCoursAjax.idCours = tempCours.ID + "";
                    tempCoursAjax.votesPour = tempCours.vote_positif + "";
                    tempCoursAjax.votesContre = tempCours.vote_negatif + "";

                    listCoursAjax.Add(tempCoursAjax);
                }

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                System.Diagnostics.Debug.WriteLine("JSON " + javaScriptSerializer.Serialize(listCoursAjax));
                var output = new
                {
                    listCours = listCoursAjax
                };
                return Json(javaScriptSerializer.Serialize(output), JsonRequestBehavior.AllowGet);
                    }

        public ActionResult getAllCoursOfMySpace()
        {
             if (Session["userID"] != null)
            {
                List<Cours> listCours = coursRepository.GetCoursByUserID((int)Session["userID"]).ToList<Cours>();

            // Tri par DATES
            listCours.Sort((x, y) => y.CreationDate.CompareTo(x.CreationDate));

            List<CoursAjax> listCoursAjax = new List<CoursAjax>();

            foreach (Cours tempCours in listCours)
            {
                CoursAjax tempCoursAjax = new CoursAjax();
                tempCoursAjax.titre = tempCours.titleCours;
                tempCoursAjax.levelId = tempCours.idLevel + "";
                tempCoursAjax.themeID = tempCours.idSubject + "";
                tempCoursAjax.idCours = tempCours.ID + "";
                tempCoursAjax.votesPour = tempCours.vote_positif + "";
                tempCoursAjax.votesContre = tempCours.vote_negatif + "";

                listCoursAjax.Add(tempCoursAjax);
            }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            System.Diagnostics.Debug.WriteLine("JSON " + javaScriptSerializer.Serialize(listCoursAjax));

            return Json(javaScriptSerializer.Serialize(listCoursAjax), JsonRequestBehavior.AllowGet);
           }
           else
             
                 
            {
                return HttpNotFound();

           }
            
        }

        [HttpPost]
        public ActionResult BrowseByTitlePattern(string titlePartial)
        {
            List<Cours> listOfCours = coursRepository.GetCoursByTitlePattern(titlePartial).ToList();

            List<CoursEspacePersoDisplayer> listOfCoursDisplayer = new List<CoursEspacePersoDisplayer>();

            // Remplissage des objets CoursEspacePersoDisplayer
            foreach (Cours tempCours in listOfCours)
            {
                // On récupère les composants des objets Subject et Level dont on a besoin
                Subject tempSubject = subjectRepository.GetById(tempCours.idSubject);
                string levelName = levelRepository.GetLevelName(tempCours.idLevel);

                CoursEspacePersoDisplayer tempCoursDisplayer = new CoursEspacePersoDisplayer();
                tempCoursDisplayer.id = tempCours.ID;
                tempCoursDisplayer.urlIcon = tempSubject.IconPath;
                tempCoursDisplayer.theme = tempSubject.Name;
                tempCoursDisplayer.nom = tempCours.titleCours;
                tempCoursDisplayer.niveau = levelName;
                tempCoursDisplayer.droits = tempCours.visibility.ToString();
                tempCoursDisplayer.votesPour = tempCours.vote_positif;
                tempCoursDisplayer.votesContre = tempCours.vote_negatif;

                listOfCoursDisplayer.Add(tempCoursDisplayer);
            }

            ViewBag.listCoursByTitlePattern = listOfCoursDisplayer;

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var output = new
            {
                listCours = listOfCoursDisplayer
            };
            JsonResult jsr = Json(javaScriptSerializer.Serialize(output), JsonRequestBehavior.AllowGet);
            return jsr;

        }
        public ActionResult Find()
        {
            return View();
        }

        public ActionResult Index(){
            return View();
        }
        /// <summary>
        /// Suppression d'un cours
        /// </summary>
        /// <param name="coursID">ID du cours</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult deleteCours(int coursID)
        {
            if (Session["userID"] != null)
            {
                if (coursRepository.GetById(coursID).Idcreator == (int)Session["userID"])
                {
                    coursRepository.Delete(coursRepository.GetById(coursID));
                    return Json(new { success = true, message = "Cours supprimé" });
                }
                
            }
            
             return Json(new { success=false, message="Erreur"});
        }
    }
}
