using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using ProjetAnnuel5A.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Runtime.Serialization.Json;
using BootStraper;
using Domaine.Common;
using System.Security.Cryptography;
using DataSerializer;

namespace ProjetAnnuel5A.Controllers
{



    public class AccountController : Controller
    {

        public IUserRepository userRepository;

        //
        // GET: /Account/

        public AccountController()
        {
            userRepository = UserRepositoryFactory.Current.GetUserRepository();
        }

        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult RegisterOne(UserSerializer user)
        {
            // Parsing de la date
            string[] tempDate = user.birthDate.Split('/');

            bool userExist = userRepository.MailExist(user.mail);
            // On test si le mail existe déjà dans la base
            if (userExist)
            {
                System.Diagnostics.Debug.WriteLine("User déjà existant");
                return View();

            }
            else
            {
                Domaine.Common.User savingUser = new User();
                savingUser.Name = user.name;
                savingUser.FirstName = user.firstName;
                savingUser.Mail = user.mail;
                savingUser.Salt = BCrypt.Net.BCrypt.GenerateSalt();
                savingUser.PassWord = BCrypt.Net.BCrypt.HashPassword(user.password, savingUser.Salt);
                savingUser.IncriptionDate = DateTime.Now;
                savingUser.Birthday = new DateTime(Convert.ToInt32(tempDate[2]), Convert.ToInt32(tempDate[1]), Convert.ToInt32(tempDate[0]));
                if (user.gender.Equals("true"))
                {
                    savingUser.Gender = true;
                }
                else
                {
                    savingUser.Gender = false;
                }

                bool userCreationSucceed = userRepository.Save(savingUser);
                // On test la réussite de la création du User
                if (userCreationSucceed)
                {
                    System.Diagnostics.Debug.WriteLine("Création réussie !");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Echec de la création!");
                }
            }
           

            return View();
        }

        public ActionResult RegisterTwo(string address, string city, string postalcode, string coordinates)
        {
            // On récupère le user avec lequel il s'est log
            User tempUser = userRepository.GetById((int)Session["userID"]);

            tempUser.Address = address;
            tempUser.City = city;
            tempUser.PostalCode = postalcode;
            tempUser.GeographicCoordinates = coordinates;

            userRepository.Update(tempUser);

            return View();
        }

        [HttpPost]
        public ActionResult Login(String user, String password)
        {
            string mailSent = user;
            string passwordSent = password;

            bool userExist = userRepository.MailExist(mailSent);
            if (userExist)
            {
                User monUser = null;
                monUser = userRepository.GetByEMail(mailSent);
                if (monUser != null)
                {
                    if(monUser.PassWord.Equals(BCrypt.Net.BCrypt.HashPassword(password, monUser.Salt)))
                    {
                        Session["userId"] = monUser.ID;
                        return RedirectToAction("Connect","Cours");
                    }
                }
            }
            else
            {
               
               // System.Diagnostics.Debug.WriteLine("Cet utilisateur n'existe pas");
            }

            return View();
        }

        public ActionResult Connect()
        {
            return View();
        }

        public ActionResult Disconnect()
        {
            Session["userID"] = null;
            return View();
        }
    }
}