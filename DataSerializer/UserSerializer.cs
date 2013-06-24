using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSerializer
{
    [Serializable]
    public class UserSerializer
    {
        public string mail { get; set; }
        public string firstName { get; set; }
        public string birthDate { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
       // public string userType { get; set; }
    }
}