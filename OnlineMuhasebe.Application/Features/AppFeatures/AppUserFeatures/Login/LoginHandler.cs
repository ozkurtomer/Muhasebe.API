using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Application.Abstractions;
using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.AppUserFeatures.Login;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IJwtProvider JwtProvider;
    private readonly UserManager<AppUser> UserManager;
    public LoginHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
    {
        JwtProvider = jwtProvider;
        UserManager = userManager;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        AppUser user = await UserManager.Users.Where(x => x.Email == request.EmailOrUserName || x.UserName == request.EmailOrUserName).FirstOrDefaultAsync();
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı!");

        var checkUser = await UserManager.CheckPasswordAsync(user, request.Password);
        if (!checkUser)
            throw new Exception("Şifreniz hatalı!");

        List<string> roles = new();

        LoginResponse response = new()
        {
            Email = user.Email,
            NameLastName = user.NameLastName,
            UserId = user.Id,
            Token = await JwtProvider.CreateTokenAsync(user, roles)
        };

        return response;
    }
}
