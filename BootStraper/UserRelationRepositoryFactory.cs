using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Common;

namespace BootStraper
{
    public class UserRelationRepositoryFactory
    {
        private static readonly UserRelationRepositoryFactory current = new UserRelationRepositoryFactory();
        public static UserRelationRepositoryFactory Current
        {
            get
            {
                return current;
            }
        }

        private Func<IUserRelationRepository> definition;
        public void SetRepository(Func<IUserRelationRepository> implementation)
        {
            definition = implementation;
        }
        public IUserRelationRepository GetUserRelationRepository()
        {
            return definition();
        }
    }
}