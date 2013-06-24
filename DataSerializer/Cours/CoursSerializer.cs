using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSerializer
{
    [Serializable]
    public class CoursSerializer
    {
        public int niveauID { get; set; }
        public int themeId { get; set; }
        public int visibiliteID { get; set; }
        public string titre { get; set; }
        public string contenu { get; set; }

        public CoursSerializer()
        {
        }
    }
}