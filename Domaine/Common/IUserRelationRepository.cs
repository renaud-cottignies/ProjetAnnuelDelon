using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Common
{
    public interface IUserRelationRepository : IRepositoryBase<UserRelation>
    {
        bool realtionExist(int userA, int userB);
        bool changeRealationStatut(int IdRelation, int newStatut);
    }
}