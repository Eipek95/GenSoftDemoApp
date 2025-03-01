using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.Business.Configurations;
using GemSoftDemoApp.Dto.LoginDtos;
using GemSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GemSoftDemoApp.Business.Concrete
{
    public class JwtService : IJwtService
    {
        private readonly JwtTokenOptions _tokenOptions;
        private readonly UserManager<AppUser> _userManager;

        public JwtService(IOptions<JwtTokenOptions> tokenOptions, UserManager<AppUser> userManager)
        {
            _tokenOptions = tokenOptions.Value;
            _userManager = userManager;
        }

        public async Task<LoginResponseDto> CreateTokenAsync(AppUser user)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.Key));

            var userRoles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Name,user.UserName),


        };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_tokenOptions.ExpireInMinutes),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

            var handler = new JwtSecurityTokenHandler();
            var responseDto = new LoginResponseDto();
            responseDto.Token = handler.WriteToken(jwtSecurityToken);
            responseDto.ExpireDate = DateTime.UtcNow.AddMinutes(_tokenOptions.ExpireInMinutes);

            return responseDto;

        }
    }
}
