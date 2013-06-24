using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Common;

namespace Infrastructure.UserService
{
    public class EntityUserRepository : IUserRepository
    {
        private ApplicationDbContext db;
        public EntityUserRepository()
        {
            db = new ApplicationDbContext();
        }

        public void DropBase()
        {
            db.Database.Delete();
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public bool Save(User _user)
        {
            db.Users.Add(_user);
            db.SaveChanges();
            return true;
        }

        public void Update(User _user)
        {
            db.SaveChanges();
        }

        public void Delete(User _cours)
        {
            db.Users.Remove(_cours);
            db.SaveChanges();
        }

        public User GetByEMail(string _eMail)
        {
            var query = db.Users
                .Where(user => user.Mail == _eMail)
                .Select(u => new { u.ID, u.Address, u.Birthday, u.City, u.Credits, u.FirstName, u.Gender, u.GeographicCoordinates, u.IncriptionDate, u.LockStatut, u.Mail, u.Name, u.PassWord, u.PostalCode, u.Salt, u.UserType });
            foreach (var user in query)
            {
                if (user.Mail == _eMail)
                    return new User(user.ID, user.Name, user.FirstName, user.Mail, user.PassWord, user.Birthday, user.Salt, user.Gender, user.Address, user.City, user.PostalCode, user.GeographicCoordinates, user.IncriptionDate, user.Credits, user.LockStatut, user.UserType);
            }
            return null;
        }

        public User GetById(int id)
        {
            return db.Users.Find(id);
        }

        public string GetPasswordByMail(string _eMail)
        {
            var query = db.Users
                .Where(user => user.Mail == _eMail)
                .Select(u => new { u.Mail, u.PassWord });
            foreach (var user in query)
            {
                if (user.Mail == _eMail)
                    return user.PassWord;
                else
                    return null;
            }
            return null;
        }

        public bool MailExist(string _eMail)
        {
            var query = db.Users
                .Where(user => user.Mail == _eMail)
                .Select(u => new { u.Mail });
            foreach (var user in query)
            {
                if (user.Mail == _eMail)
                    return true;
            }
            return false;
        }
    }
}