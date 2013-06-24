using Domaine.CoursService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CourService
{
    public class EntityLevelRepository : ILevelRepository
    {
        private ApplicationDbContext db;
        public EntityLevelRepository()
        {
            db = new ApplicationDbContext();
        }

        public void DropBase()
        {
            db.Database.Delete();
        }

        public IEnumerable<Level> GetAll()
        {
            return db.Levels;
        }

        public bool Save(Level _Level)
        {
            db.Levels.Add(_Level);
            db.SaveChanges();
            return true;
        }

        public void Update(Level _Level)
        {
            db.SaveChanges();
        }

        public void Delete(Level _Level)
        {
            db.Levels.Remove(_Level);
            db.SaveChanges();
        }

        public Level GetById(int id)
        {
            return db.Levels.Find(id);
        }

        public string GetLevelName(int levelID)
        {
            var query = db.Levels
                .Where(l => l.ID == levelID)
                .Select(l => new { l.Name });
            foreach (var level in query)
            {
                return level.Name;
            }
            return null;
        }

        public int GetLevelIdByName(string name)
        {
            var query = db.Levels
                .Where(s => s.Name == name)
                .Select(s => new { s.ID });
            foreach (var level in query)
            {
                return level.ID;
            }
            return -1;
        }
    }
}