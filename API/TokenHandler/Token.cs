using Microsoft.IdentityModel.Tokens;
using Repository.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.TokenHandler
{
    public static class Token
    {
        public static string GenerateToken(AppUser user)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("artporosartporos"));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));



            JwtSecurityToken token =new JwtSecurityToken(claims:claims,signingCredentials:credentials,expires:DateTime.Now.AddMinutes(120));

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
    }
}
