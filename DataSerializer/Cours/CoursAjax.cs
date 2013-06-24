using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSerializer.Cours
{
    public class CoursAjax
    {
        public string titre { get; set; }
        public string levelId { get; set; }
        public string themeID { get; set; }
        public string idCours { get; set; }
        public string votesPour { get; set; }
        public string votesContre { get; set; }


        public CoursAjax()
        {

        }
    }
}