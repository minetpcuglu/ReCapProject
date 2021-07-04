using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //kullanıcı bilgisi ve rol bilgilerini verildi
        AccessToken CreateToken(User user ,List<OperationClaims> operationClaims);   
    }
}
