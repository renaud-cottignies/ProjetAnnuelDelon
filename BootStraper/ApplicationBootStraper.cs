using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Infrastructure.CourService;
using Infrastructure.UserService;
using Infrastructure;

namespace BootStraper
{
    public class ApplicationBootStraper
    {
        public void StartUp()
        {
            //initialisation de la base de donnée en liant avec les entityRepository 
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
            
            CoursRepositoryFactory.Current
                .SetRepository(() => new EntityCoursRepository()); //On set le singleton CoursRepositoryFactory avec notre EntityRepo

            UserRepositoryFactory.Current
            .SetRepository(() => new EntityUserRepository());

            UserRelationRepositoryFactory.Current
                  .SetRepository(() => new EntityUserRelationRepository()); 
            SubjectRepositoryFactory.Current
                .SetRepository(() => new EntitySubjectRepository());

            LevelRepositoryFactory.Current
             .SetRepository(() => new EntityLevelRepository()); 
        }
    }
}
