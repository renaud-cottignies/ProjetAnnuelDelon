using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Common
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        bool MailExist(string _mail);
        string GetPasswordByMail(string _mail);
        User GetByEMail(string _mail);
    }
}
