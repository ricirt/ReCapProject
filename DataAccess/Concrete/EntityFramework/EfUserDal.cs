using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context=new ReCapContext())
            {
                var result = from opClaim in context.OperationClaims
                             join UserOpClaim in context.UserOperationClaims
                             on opClaim.Id equals UserOpClaim.OperationClaimId
                             where UserOpClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = opClaim.Id,
                                 Name = opClaim.Name
                             };
                return result.ToList();
            }
        }
    }
}
