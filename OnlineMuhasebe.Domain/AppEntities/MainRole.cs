using OnlineMuhasebe.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMuhasebe.Domain.AppEntities;

public sealed class MainRole : Entity
{
    public string Title { get; set; }
    public string CompanyId { get; set; }
    public bool IsRoleCreatedByAdmin { get; set; }

    [ForeignKey("CompanyId")]
    public Company? Company { get; set; }
}
