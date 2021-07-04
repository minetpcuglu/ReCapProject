using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, Context>, IUserDal
    {
        //kullanıcının rollerini cekmek için claim bilgilerini çekiyoruz Join ediyoruz
        //public List<OperationClaims> GetClaims(User user)
        //{
            //using (var context = new Context())
            //{
            //    var result = from operationClaims in context.Tbl
            //                 join userOperationClaim in context.TblUserOperationClaims
            //                     on operationClaims.Id equals userOperationClaim.OperationClaimId
            //                 where userOperationClaim.UserId == user.Id
            //                 select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            //    return result.ToList();

            //}
        //}
    }
}
