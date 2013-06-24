using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.CoursService;

namespace Infrastructure.CourService
{
    public class EntityCoursRepository : ICoursRepository
    {
        private ApplicationDbContext db;
        public EntityCoursRepository()
        {
            db = new ApplicationDbContext();
        }

        public void DropBase()
        {
            db.Database.Delete();
        }

        public IEnumerable<Cours> GetAll()
        {
            return db.Courses;
        }

        public bool Save(Cours _cours)
        {
            db.Courses.Add(_cours);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Cours> GetCoursBySubjectID(int _idSubject)
        {
            List<Cours> coursList = new List<Cours>();
            var query = db.Courses
                .Where(cours => cours.idSubject == _idSubject)
                .Select(c => new { c.ID, c.Idcreator, c.idSubject, c.coreCours, c.titleCours, c.ModificationDate, c.visibility, c.CreationDate, c.idLevel, c.vote_positif, c.vote_negatif });
            foreach (var cours in query)
            {
                Cours c = new Cours(cours.ID, cours.titleCours, cours.coreCours, cours.idSubject, cours.visibility, cours.CreationDate, cours.Idcreator, cours.idLevel, cours.ModificationDate, cours.vote_positif, cours.vote_negatif);
                coursList.Add(c);
            }
            return coursList;
        }

        public IEnumerable<Cours> GetCoursByUserID(int _userID)
        {
            List<Cours> coursList = new List<Cours>();
            var query = db.Courses
                .Where(cours => cours.Idcreator == _userID)
                .Select(c => new { c.ID, c.Idcreator, c.idSubject, c.coreCours, c.titleCours, c.ModificationDate, c.visibility, c.CreationDate, c.idLevel, c.vote_positif, c.vote_negatif });
            foreach (var cours in query)
            {
                Cours c = new Cours(cours.ID, cours.titleCours.ToString(), cours.coreCours, cours.idSubject, cours.visibility, cours.CreationDate, cours.Idcreator, cours.idLevel, cours.ModificationDate, cours.vote_positif, cours.vote_negatif);
                coursList.Add(c);
            }
            return coursList;
        }

        public void Update(Cours _cours)
        {
            db.SaveChanges();
        }

        public void Delete(Cours _cours)
        {
            db.Courses.Remove(_cours);
            db.SaveChanges();
        }

        public Cours GetById(int id)
        {
            return db.Courses.Find(id);
        }

        public IEnumerable<Cours> GetCoursBySubjectIDandLevelID(int subjectID, int levelID)
        {
            List<Cours> coursList = new List<Cours>();
            var query = db.Courses
                .Where(cours => cours.idSubject == subjectID && cours.idLevel == levelID)
                .Select(c => new { c.ID, c.Idcreator, c.idSubject, c.coreCours, c.titleCours, c.ModificationDate, c.visibility, c.CreationDate, c.idLevel, c.vote_positif, c.vote_negatif });
            foreach (var cours in query)
            {
                Cours c = new Cours(cours.ID, cours.titleCours, cours.coreCours, cours.idSubject, cours.visibility, cours.CreationDate, cours.Idcreator, cours.idLevel, cours.ModificationDate, cours.vote_positif, cours.vote_negatif);
                coursList.Add(c);
            }
            return coursList;
        }

        public IEnumerable<Cours> GetCoursByTitlePattern(string titlePartial)
        {
            List<Cours> coursList = new List<Cours>();
            var query = db.Courses
                .Where(cours => cours.titleCours.Contains(titlePartial))
                .Select(c => new { c.ID, c.Idcreator, c.idSubject, c.coreCours, c.titleCours, c.ModificationDate, c.visibility, c.CreationDate, c.idLevel, c.vote_positif, c.vote_negatif });
            foreach (var cours in query)
            {
                Cours c = new Cours(cours.ID, cours.titleCours, cours.coreCours, cours.idSubject, cours.visibility, cours.CreationDate, cours.Idcreator, cours.idLevel, cours.ModificationDate, cours.vote_positif, cours.vote_negatif);
                coursList.Add(c);
            }
            return coursList;
        }

        public IEnumerable<Cours> GetCoursBySubjectIDandLevelIDorderByDateLastModifASC(int subjectID, int levelID)
        {
            List<Cours> coursList = new List<Cours>();
            var query = db.Courses
                .Where(cours => cours.idSubject == subjectID && cours.idLevel == levelID)
                .OrderBy(cours => cours.ModificationDate)
                .Select(c => new { c.ID, c.Idcreator, c.idSubject, c.coreCours, c.titleCours, c.ModificationDate, c.visibility, c.CreationDate, c.idLevel, c.vote_positif, c.vote_negatif });
            foreach (var cours in query)
            {
                Cours c = new Cours(cours.ID, cours.titleCours, cours.coreCours, cours.idSubject, cours.visibility, cours.CreationDate, cours.Idcreator, cours.idLevel, cours.ModificationDate, cours.vote_positif, cours.vote_negatif);
                coursList.Add(c);
            }
            return coursList;
        }

        public IEnumerable<Cours> GetCoursBySubjectIDandLevelIDorderByDateLastModifDESC(int subjectID, int levelID)
        {
            List<Cours> coursList = new List<Cours>();
            var query = db.Courses
                .Where(cours => cours.idSubject == subjectID && cours.idLevel == levelID)
                .OrderByDescending(cours => cours.ModificationDate)
                .Select(c => new { c.ID, c.Idcreator, c.idSubject, c.coreCours, c.titleCours, c.ModificationDate, c.visibility, c.CreationDate, c.idLevel, c.vote_positif, c.vote_negatif });
            foreach (var cours in query)
            {
                Cours c = new Cours(cours.ID, cours.titleCours, cours.coreCours, cours.idSubject, cours.visibility, cours.CreationDate, cours.Idcreator, cours.idLevel, cours.ModificationDate, cours.vote_positif, cours.vote_negatif);
                coursList.Add(c);
            }
            return coursList;
        }
    }
}