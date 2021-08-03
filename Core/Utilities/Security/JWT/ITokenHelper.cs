using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper //token ureticek mekanızma
    {
        //kullanıcı bilgisi ve rol bilgilerini  yeklileri verildi
        AccessToken CreateToken(User user ,List<OperationClaims> operationClaims);   
    }
}
