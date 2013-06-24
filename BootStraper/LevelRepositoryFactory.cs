using Domaine.CoursService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootStraper
{
    public class LevelRepositoryFactory
    {
        private static readonly LevelRepositoryFactory current = new LevelRepositoryFactory();
        public static LevelRepositoryFactory Current
        {
            get
            {
                return current;
            }
        }

        private Func<ILevelRepository> definition;
        public void SetRepository(Func<ILevelRepository> implementation)
        {
            definition = implementation;
        }
        public ILevelRepository GetLevelRepository()
        {
            return definition();
        }
    }
}