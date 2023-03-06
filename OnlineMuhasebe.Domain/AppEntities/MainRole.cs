using OnlineMuhasebe.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMuhasebe.Domain.AppEntities;

public sealed class MainRole : Entity
{
    public MainRole(string id, string title, string companyId = null, bool isRoleCreatedByAdmin = false) : base(id)
    {
        Title = title;
        CompanyId = companyId;
        IsRoleCreatedByAdmin = isRoleCreatedByAdmin;
    }

    public string Title { get; set; }
    public string CompanyId { get; set; }
    public bool IsRoleCreatedByAdmin { get; set; }

    [ForeignKey("CompanyId")]
    public Company? Company { get; set; }
}
