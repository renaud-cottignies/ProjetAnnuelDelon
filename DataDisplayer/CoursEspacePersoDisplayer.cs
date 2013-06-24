using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDisplayer
{
    public class CoursEspacePersoDisplayer
    {
        public string nom { get; set; }
        public int id { get; set; }
        public string urlIcon { get; set; }
        public string theme { get; set; }
        public string niveau { get; set; }
        public string droits { get; set; }
        public int votesPour { get; set; }
        public int votesContre { get; set; }

        public CoursEspacePersoDisplayer() { }
    }
}
