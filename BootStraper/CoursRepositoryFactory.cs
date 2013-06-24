using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Common;
using Domaine.CoursService;

namespace BootStraper
{
    public class CoursRepositoryFactory
    {
        private static readonly CoursRepositoryFactory current = new CoursRepositoryFactory();
        public static CoursRepositoryFactory Current
        {
            get
            {
                return current;
            }
        }

        private Func<ICoursRepository> definition;
        public void SetRepository(Func<ICoursRepository> implementation)
        {
            definition = implementation;
        }
        public ICoursRepository GetCoursRepository()
        {
            return definition();
        }
    }
}
