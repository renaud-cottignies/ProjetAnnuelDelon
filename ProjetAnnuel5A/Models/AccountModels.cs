using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ProjetAnnuel5A.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Adresse e-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Votre mot de passe")]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Le {0} doit contenir au moins {2} charactèrs.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot De Passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Mot De Passe de Confirmation ")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne sont pas identique.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [EmailAddress]
        [Compare("Email", ErrorMessage = "Les Email ne sont pas identique. ")]
        public string ConfirmEmail { get; set; }
    }
}