using CarBook.Application.Dtos;
using CarBook.Application.Features.AppUsers.Queries.GetCheckAppUser;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(GetCheckAppUserQueryResponse result)
        {
            if (!result.IsExist)
                return null;

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, result.AppUserID.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, result.Username));
            claims.Add(new Claim(ClaimTypes.Role, result.AppRoleName));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenExpiration = DateTime.Now.AddMinutes(JwtTokenDefaults.ExpirationMinutes);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenDefaults.Issuer,
                audience: JwtTokenDefaults.Audience,
                claims: claims,
                expires: tokenExpiration,
                signingCredentials: creds
                );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new TokenResponseDto
            (
                accessToken,
                tokenExpiration
            );
        }
    }
}
