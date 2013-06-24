using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetAnnuel5A.Models
{
    public class Cours
    {
        public string Titre { get; set; }
        public string Contenu { get; set; }
        public int ThemeID { get; set; }
        public int SousThemeID { get; set; }
        public int Visibilite { get; set; }
    }
}