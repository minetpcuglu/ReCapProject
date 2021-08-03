using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
   public class HashingHelper
    {
        //verilen şifreyi hash ve salt oluşturur
        public static void CreatePasswordHash
            (string password , out byte[] passwordHash , out byte[] passwordSalt)
        {
            //.net kriptografi sınıfından yararlanarak sistemi oluşturcaz
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) //dispoasble pattern ile oluşturulcak //hangi algoritma kullanalım ? 
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password )); //bir stringin byte karsılıgını almak encoding yontemi
            }
        }


        //kullanıcın sisteme girerken girdigi parola veri kaynagı ile eşleşiyor mu ona bakıyoruz
        public static bool VerifyPasswordHash(string password,byte[] passwordHash ,byte[] passwordSalt) 
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) //dispoasble pattern ile oluşturulcak
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])  //hesaplanan deger benim hash eşleşiyor mu?
                    {
                        return false;
                    }
                }
            }

            return true;

        }
    }
}
