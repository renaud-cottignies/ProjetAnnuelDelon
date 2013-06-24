using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Common;

namespace Infrastructure.UserService
{
    public class EntityUserRelationRepository : IUserRelationRepository
    {
        private ApplicationDbContext db;
        public EntityUserRelationRepository()
        {
            db = new ApplicationDbContext();
        }

        public void DropBase()
        {
            db.Database.Delete();
        }

        public IEnumerable<UserRelation> GetAll()
        {
            return db.UsersRelations;
        }

        public bool Save(UserRelation _UserRelation)
        {
            db.UsersRelations.Add(_UserRelation);
            db.SaveChanges();
            return true;
        }

        public void Update(UserRelation _UserRelation)
        {
            db.SaveChanges();
        }

        public void Delete(UserRelation _cours)
        {
            db.UsersRelations.Remove(_cours);
            db.SaveChanges();
        }

        public UserRelation GetById(int id)
        {
            return db.UsersRelations.Find(id);
        }

        public bool realtionExist(int userA, int userB)
        {
            var query = db.UsersRelations
                .Where(UserRelation => (UserRelation.userA == userA && UserRelation.userB == userB) || (UserRelation.userA == userA && UserRelation.userB == userA))
                .Select(u => new { u.ID, u.relationStat, u.userA, u.userB });
            foreach (var userRelation in query)
            {
                if ((userRelation.userA == userA && userRelation.userB == userB) || (userRelation.userA == userA && userRelation.userB == userB))
                    return true;
            }
            return false;
        }
        public bool changeRealationStatut(int IdRelation, int newStatut)
        {
            //var query = db.UsersRelations
            //    .Where(UserRelation => (UserRelation.ID == IdRelation))
            //    .Select(u => new { u.ID, u.relationStat });
            //foreach (var userRelation in query)
            //{
            //    userRelation.relationStat = newStatut;
            //    return true;
            //}
            return false;
        }
    }
}