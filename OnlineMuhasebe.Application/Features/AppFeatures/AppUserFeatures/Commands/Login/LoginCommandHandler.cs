using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Application.Abstractions;
using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.AppUserFeatures.Commands.Login;

public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IJwtProvider JwtProvider;
    private readonly UserManager<AppUser> UserManager;
    public LoginCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
    {
        JwtProvider = jwtProvider;
        UserManager = userManager;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser user = await UserManager.Users.Where(x => x.Email == request.EmailOrUserName || x.UserName == request.EmailOrUserName).FirstOrDefaultAsync();
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı!");

        var checkUser = await UserManager.CheckPasswordAsync(user, request.Password);
        if (!checkUser)
            throw new Exception("Şifreniz hatalı!");

        List<string> roles = new();

        LoginCommandResponse response = new(
                                     user.Email,
                                     user.NameLastName,
                                     user.Id,
                                     await JwtProvider.CreateTokenAsync(user, roles));

        return response;
    }
}
