using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
   public class SecurityKeyHelper
    {
        //şifreleme olan sistemlerde her seyi byte array seklinde oluşturmamız lazım ki jwt sistemi anlasın 
        //appsettingte oluşturduklarımı stringleri jwt uygun hale  byte haline getiriyoruz
        public static SecurityKey CreateSecurityKey (string securityKey) 
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
