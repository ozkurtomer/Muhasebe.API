using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using OnlineMuhasebe.Application.Abstractions;
using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.Infrasturcture.Authentications;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions JwtOptions;
    private readonly UserManager<AppUser> UserManager;

    public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<AppUser> userManager)
    {
        UserManager = userManager;
        JwtOptions = jwtOptions.Value;
    }

    public async Task<string> CreateTokenAsync(AppUser user, List<string> roles)
    {
        var claims = new Claim[]{
            new Claim(JwtRegisteredClaimNames.Sub, user.NameLastName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Authentication, user.Id),
            new Claim(ClaimTypes.Role, String.Join(",",roles)),
        };

        DateTime expires = DateTime.Now.AddDays(1); ;

        JwtSecurityToken jwtSecurityToken = new(issuer: JwtOptions.Issuer,
                                                audience: JwtOptions.Audience,
                                                claims: claims,
                                                notBefore: DateTime.Now,
                                                expires: expires,
                                                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256));
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = expires.AddDays(1);
        await UserManager.UpdateAsync(user);

        return refreshToken;
    }
}
