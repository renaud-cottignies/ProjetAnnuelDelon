﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.CoursService
{
    public interface ICoursRepository : IRepositoryBase<Cours>
    {
        IEnumerable<Cours> GetCoursBySubjectID(int SubjectID);
        IEnumerable<Cours> GetCoursByUserID(int UserID);
        IEnumerable<Cours> GetCoursBySubjectIDandLevelID(int subjectID, int levelID);
        IEnumerable<Cours> GetCoursBySubjectIDandLevelIDorderByDateLastModifASC(int subjectID, int levelID);
        IEnumerable<Cours> GetCoursBySubjectIDandLevelIDorderByDateLastModifDESC(int subjectID, int levelID);
        IEnumerable<Cours> GetCoursByTitlePattern(string titlePartial);
    }
}