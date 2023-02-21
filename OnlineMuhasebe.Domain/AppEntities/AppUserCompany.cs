using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMuhasebe.Domain.AppEntities;

public class AppUserCompany : Entity
{
    [ForeignKey("AppUser")]
    public string AppUserId { get; set; }

    public AppUser AppUser { get; set; }

    [ForeignKey("Company")]
    public string CompanyId { get; set; }

    public Company Company { get; set; }
}
