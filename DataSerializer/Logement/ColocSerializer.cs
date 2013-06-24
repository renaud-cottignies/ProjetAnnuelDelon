using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSerializer
{
    [Serializable]
    public class ColocSerializer
    {
        public int actuelHommes { get ; set ; }
        public int actuelFemmes { get; set; }
        public string sexeRecherche { get; set; }
        public string professionRecherche { get; set; }
        public string fumeurRecherche { get; set; }
        public string animauxRecherche { get; set; }
        public int ageMinRecherche { get; set; }
        public int ageMaxRecherche { get; set; }
        public string cuisineJSONContent { get; set; }
        public string autresEquipementsJSONContent { get; set; }
        public string autresInfosJSONContent { get; set; }
        public string localisationAdresse { get; set; }
        public string localisationVille { get; set; }
        public int licalisationCodePostal { get; set; }
        public string localisationCoord {get; set; }
        public string description { get; set; }

        public string handicap { get; set; }
        public int loyer { get; set; }
    }
}
