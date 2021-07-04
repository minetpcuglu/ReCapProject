using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public class TokenOptions
    {
        public string Audience { get; set; }  //token kullanıcı kitlesi
        public string Issuer { get; set; }   //onaylayan
        public int AccessTokenExpiration { get; set; }   
        public string SecurityKey { get; set; }  
    }
}
