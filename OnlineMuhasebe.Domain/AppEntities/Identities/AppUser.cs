using Microsoft.AspNetCore.Identity;

namespace OnlineMuhasebe.Domain.AppEntities.Identities;

public sealed class AppUser : IdentityUser<string>
{
    public string NameLastName { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpires { get; set; }
}
