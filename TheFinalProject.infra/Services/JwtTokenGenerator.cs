using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.Authentication;
using TheFinalProject.core.DTOs;
using TheFinalProject.core.IServices;

namespace TheFinalProject.infra.Services
{
    public class JwtTokenGenerator: IJwtTokenGenerator
    {
        private readonly JwtSettings jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(UserLoginDTO user)
        {
            var signingCredentials = new SigningCredentials(
                               new SymmetricSecurityKey(
                               Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                               SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub,user.UserId.ToString()),
                 new Claim(JwtRegisteredClaimNames.GivenName,user.firstName),
                 new Claim(JwtRegisteredClaimNames.FamilyName,user.lastName),
                 new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
                 new Claim(ClaimTypes.Role, user.RoleName)
            };

            var securityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpiryInMinutes),
                audience: jwtSettings.Audience,
                claims: claims,
                signingCredentials: signingCredentials);

            var stringToken = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return stringToken;
        }
    }
}
