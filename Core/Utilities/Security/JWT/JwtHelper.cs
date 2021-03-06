using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //? Api deki appsettings.json daki değerleri okumaya yarar
        private TokenOptions _tokenOptions;          // okunan degerleri token optionsa atanacak 
        private DateTime _accessTokenExpiration;     //? AccessToken ne zaman gecersizleşicek 


        public JwtHelper(IConfiguration configuration)  //token option bilgilerini congifurasyon yapısıyla okucaz
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();   // token bilgilerini al ve token option içerisine at
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

        }

        public AccessToken CreateToken(User user, List<OperationClaims> operationClaims) //kullanıcı için user ve claimlere göre bir token üretilcek
        {
            //var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            //var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);      //? token ne zaman bitecek 10 dakika sonra appsettings 
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);           // (güvenlik anahtarı) Anahtar değeri  appsettings.json okumaya yarar
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);    //? hangi anahtar hangi algoritma kullanılcak (signenCreadentialsHelperda var)
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);  //hepsini birleştrildi ve metot yazılmalı
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiraiton = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, // JWT oluşturmak dogrulamak ve geliştirmek için kullanırız
            SigningCredentials signingCredentials, List<OperationClaims> operationClaims)
        {
            var jwt = new JwtSecurityToken(  //token oluşturma  //ve apisettings teki bilgileri kullanır
                issuer: tokenOptions.Issuer,  
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,   //suandan önce ise token gecerli değil 
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaims> operationClaims)  //claimleri set etmek için operasyon 
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");  //$ + "" kod yazılır 
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
