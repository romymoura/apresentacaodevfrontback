using Apresentacao.Api.Managers.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace Apresentacao.Api.Managers
{
    public static class JwtManager
    {
        public static string GenerateToken(string username, JwtSettings settings)
        {
            var symmetricKey = Encoding.UTF8.GetBytes(settings.IssuerKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = settings.TokenAudience,
                Issuer = settings.Issuer,
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, username),
                            new Claim(ClaimTypes.Role, "User")
                        }),

                Expires = now.AddSeconds(Convert.ToInt32(settings.TokenExp)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            ////Aqui posso adicionar or roles.
            //var roles = new List<string>() { "User" };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
            ClaimsPrincipal principal = GetPrincipal(token, settings);
            Thread.CurrentPrincipal = new GenericPrincipal(tokenDescriptor.Subject, new string[] { "User" });

            return token;
        }

        public static ClaimsPrincipal GetPrincipal(string token, JwtSettings settings)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;
                var symmetricKey = Encoding.UTF8.GetBytes(settings.IssuerKey);
                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }

            catch (Exception)
            {
                return null;
            }
        }
    }
}
