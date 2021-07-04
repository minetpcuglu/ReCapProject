using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, Context>, IUserDal
    {
        //kullanıcının rollerini cekmek için claim bilgilerini çekiyoruz Join ediyoruz
        public List<OperationClaims> GetClaims(User user)
        {
            using (var context = new Context())
            {
                var result = from operationClaims in context.TblOperationClaims
                             join userOperationClaim in context.TblUserOperationClaims
                                 on operationClaims.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaims { Id = operationClaims.Id, Name = operationClaims.Name };
                return result.ToList();

            }
        }
    }
}
