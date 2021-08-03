using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
   public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)      //JWT sistemi kullanmak için elimizde olanları veriyoruz (şifre)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.EcdsaSha512Signature); //hangi dogrulama kullanılcak ? hangi güvenlik algoritması ? kullansın 
        }
    }
}
