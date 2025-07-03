
using Microsoft.IdentityModel.Tokens;
using ToDoList.Application.Security.Account.UseCases.Authenticate;
using ToDoList.Domain.Security.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ToDoList.WebApi.Extensions
{
    public static class JwtExtension
    {
        public static string Generate(ResponseData data)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.Secrets.JwtPrivateKey);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(data),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(ResponseData user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim("Id", user.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            foreach (var role in user.Roles)
                ci.AddClaim(new Claim(ClaimTypes.Role, role));

            return ci;
        }

        public static Guid GenerateRefreshToken()
        {
            return Guid.NewGuid();
        }
    }
}