using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    //var olan nesneye(class'a) yeni metotlar eklenmesine Extensions denir genişletebilirzde diyebiliriz.
    //metotdunda class'nda statıc olması gerekli 
   public static class ClaimExtensions 
    {

        public static void AddEmail(this ICollection<Claim> claims, string email)  //AddEmail metodu *"this"* gördüğümüz için  ICollection içine eklenecek demek Extensions demek
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));  //her bir rolu liste cevir ve her bir rolu sistemde claimlere ekle 
        }
    }
}
