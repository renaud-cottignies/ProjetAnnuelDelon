using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.CoursService;

namespace BootStraper
{
    public class SubjectRepositoryFactory
    {
        private static readonly SubjectRepositoryFactory current = new SubjectRepositoryFactory();
        public static SubjectRepositoryFactory Current
        {
            get
            {
                return current;
            }
        }

        private Func<ISubjectRepository> definition;
        public void SetRepository(Func<ISubjectRepository> implementation)
        {
            definition = implementation;
        }
        public ISubjectRepository GetSubjectRepository()
        {
            return definition();
        }
    }
}