﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.CoursService
{
    public interface ISubjectRepository : IRepositoryBase<Subject>
    {
        string GetSubjectName(int subjectID); 
        int GetSubjectIdByName(string name);
    }
}