﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Domaine.Common;
using System.Threading.Tasks;

namespace ProjetAnnuel5A.Controllers
{
    interface IShareModelController
    {
        IUserRepository user_repo  {get;set;}
        ActionResult Add(List<string> name);
        ActionResult Delete(List<string> name);
        ActionResult Modification(List<string> name);
    }
}