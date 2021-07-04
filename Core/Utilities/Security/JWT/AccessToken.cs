using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiraiton { get; set; } //token ne zamana kadar gecerli oldugu 
    }
}
