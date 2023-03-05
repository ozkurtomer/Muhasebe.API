using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMuhasebe.Domain.AppEntities;

public sealed class MainRoleUser : Entity
{
    public string UserId { get; set; }
    public string MainRoleId { get; set; }

    [ForeignKey("User")]
    public AppUser AppUser { get; set; }

    [ForeignKey("MainRole")]
    public MainRole MainRole { get; set; }
}
