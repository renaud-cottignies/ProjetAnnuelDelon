using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.CoursService;

namespace Infrastructure.CourService
{
    public class EntitySubjectRepository : ISubjectRepository
    {
        private ApplicationDbContext db;
        public EntitySubjectRepository()
        {
            db = new ApplicationDbContext();
        }

        public void DropBase()
        {
            db.Database.Delete();
        }

        public IEnumerable<Subject> GetAll()
        {
            return db.Subjects;
        }

        public string GetSubjectName(int subjectID)
        {
            var query = db.Subjects
                .Where(s => s.ID == subjectID)
                .Select(s => new { s.Name });
            foreach (var subject in query)
            {
                return subject.Name;
            }
            return null;
        }

        public bool Save(Subject _Subject)
        {
            db.Subjects.Add(_Subject);
            db.SaveChanges();
            return true;
        }

        public void Update(Subject _Subject)
        {
            db.SaveChanges();
        }

        public void Delete(Subject _Subject)
        {
            db.Subjects.Remove(_Subject);
            db.SaveChanges();
        }

        public Subject GetById(int id)
        {
            return db.Subjects.Find(id);
        }

        public int GetSubjectIdByName(string name)
        {
            var query = db.Subjects
                .Where(s => s.Name == name)
                .Select(s => new { s.ID });
            foreach (var subject in query)
            {
                return subject.ID;
            }
            return -1;
        }
    }
}