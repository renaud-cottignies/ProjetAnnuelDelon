using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Common;

namespace BootStraper
{
    public class UserRepositoryFactory
    {
        private static readonly UserRepositoryFactory current = new UserRepositoryFactory();
        public static UserRepositoryFactory Current
        {
            get
            {
                return current;
            }
        }

        private Func<IUserRepository> definition;
        public void SetRepository(Func<IUserRepository> implementation)
        {
            definition = implementation;
        }
        public IUserRepository GetUserRepository()
        {
            return definition();
        }
    }
}
