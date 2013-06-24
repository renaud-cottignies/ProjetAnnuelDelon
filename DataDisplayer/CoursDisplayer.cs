using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDisplayer
{
    public class CoursDisplayer
    {
        public int coursID { get; set; }
        public int themeID { get; set; }
        public string themeName { get; set; }
        public int niveauID { get; set; }
        public string niveauName { get; set; }
        public string titre { get; set; }
        public string contenu { get; set; }
        public int nbVotesPour { get; set; }
        public int nbVotesContre { get; set; }
        public DateTime dateDerniereModif { get; set; }

        public CoursDisplayer(){}
    }
}
