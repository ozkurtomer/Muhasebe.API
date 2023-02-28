using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.Application.Abstractions;

public interface IJwtProvider
{
    Task<string> CreateTokenAsync(AppUser user, List<string> roles);
}
