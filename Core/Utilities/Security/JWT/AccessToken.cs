using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public class AccessToken  // JWT erişim anahtarı
    {
        public string Token { get; set; } //anlamsız seylerden olusan anahtardır
        public DateTime Expiraiton { get; set; } //token ne zamana kadar gecerli oldugu 
    }
}
