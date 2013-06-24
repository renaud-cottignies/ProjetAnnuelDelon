using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.CoursService;
using Infrastructure.CourService;
using Domaine.Common;
using BootStraper;

namespace InsertBase
{
    public class InsertDB
    {
        public InsertDB()
        {
            var bootstrap = new ApplicationBootStraper();
            bootstrap.StartUp();
            ISubjectRepository Subject_repo = SubjectRepositoryFactory.Current.GetSubjectRepository();
            Subject_repo.Save(new Subject("Droit", "/img/Cours/icons/90x90/droit.png"));
            Subject_repo.Save(new Subject("Informatique", "/img/Cours/icons/90x90/informatique.png"));
            Subject_repo.Save(new Subject("Médecine", "/img/Cours/icons/90x90/medecine.png"));
            Subject_repo.Save(new Subject("Psychologie/Sociologie", "/img/Cours/icons/90x90/psychologie.png"));
            Subject_repo.Save(new Subject("Français", "/img/Cours/icons/90x90/francais.png"));
            Subject_repo.Save(new Subject("Langues", "/img/Cours/icons/90x90/langues.png"));
            Subject_repo.Save(new Subject("Philosophie", "/img/Cours/icons/90x90/philosophie.png"));
            Subject_repo.Save(new Subject("SVT", "/img/Cours/icons/90x90/svt.png"));
            Subject_repo.Save(new Subject("Histoire/Géographie", "/img/Cours/icons/90x90/histoiregeographie.png"));
            Subject_repo.Save(new Subject("Mathématiques", "/img/Cours/icons/90x90/maths.png"));
            Subject_repo.Save(new Subject("Physique/Chimie", "/img/Cours/icons/90x90/phyChimie.png"));
            Subject_repo.Save(new Subject("Management", "/img/Cours/icons/90x90/management.png"));
            Subject_repo.Save(new Subject("Economie", "/img/Cours/icons/90x90/economie.png"));
            Subject_repo.Save(new Subject("Autres", "/img/Cours/icons/90x90/autres.png"));

            ILevelRepository Level_repo = LevelRepositoryFactory.Current.GetLevelRepository();
            Level_repo.Save(new Level("Primaire", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("6ième", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("5ième", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("4ième", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("3ième", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("BEP", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("Seconde", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("Première", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("Terminale", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("Prépa", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("Bac+1", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("Bac+2", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("Bac+3", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("Bac+4", "c:/mamamam/titititi"));
            Level_repo.Save(new Level("Bac+5", "c:/mamamam/titititi"));

            IUserRepository user_repo = UserRepositoryFactory.Current.GetUserRepository();
            user_repo.Save(new User("Cottignies", "Renaud", "toto@gmail.com", "password", DateTime.Now, "salte", true, "164 avenue du général lecerlc", "Palaiseau", "91120", "géo coordonate", DateTime.Now, 666, false, 0));
            user_repo.Save(new User("Delon", "Christophe", "tata@gmail.com", "password2", DateTime.Now, "salte", false, "162 avenue du général lecerlc", "Bouafle", "78410", "géo coordonate", DateTime.Now, 643, false, 1));
            user_repo.Save(new User("Combette", "Tristan", "titi@gmail.com", "password3", DateTime.Now, "salte", true, "166 avenue du général lecerlc", "Tarteret", "91100", "géo coordonate", DateTime.Now, 654, true, 0));

            IUserRelationRepository userRela_repo = UserRelationRepositoryFactory.Current.GetUserRelationRepository();
            userRela_repo.Save(new UserRelation(1, 2, 0));
            userRela_repo.Save(new UserRelation(2, 1, 2));

            ICoursRepository Cours_repo = CoursRepositoryFactory.Current.GetCoursRepository();
            
            Cours_repo.Save(new Cours("Title1", "Core Cours1", Subject_repo.GetSubjectIdByName("SVT"), -1, DateTime.Now, 1, Level_repo.GetLevelIdByName("Seconde")));
            Cours_repo.Save(new Cours("Title2", "Core Cours2", Subject_repo.GetSubjectIdByName("Management"), 0, DateTime.Now, 2, Level_repo.GetLevelIdByName("4ième")));
            Cours_repo.Save(new Cours("Title3", "Core Cours3", Subject_repo.GetSubjectIdByName("Langues"), 1, DateTime.Now, 2, Level_repo.GetLevelIdByName("Prépa")));
            Cours_repo.Save(new Cours("Title4", "Core Cours4", Subject_repo.GetSubjectIdByName("Philosophie"), 0, DateTime.Now, 3, Level_repo.GetLevelIdByName("Bac+4")));
            Cours_repo.Save(new Cours("Title5", "Core Cours5", Subject_repo.GetSubjectIdByName("Philosophie"), 0, DateTime.Now, 1, Level_repo.GetLevelIdByName("Seconde")));
        }

    }
}