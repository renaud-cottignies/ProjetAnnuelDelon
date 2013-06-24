﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.CoursService
{
    public interface ILevelRepository : IRepositoryBase<Level>
    {
        string GetLevelName(int levelID);
        int GetLevelIdByName(string name);
   }
}