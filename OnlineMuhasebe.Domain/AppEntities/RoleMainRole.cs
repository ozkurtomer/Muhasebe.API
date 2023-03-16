using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMuhasebe.Domain.AppEntities;

public sealed class RoleMainRole : Entity
{
    public RoleMainRole()
    {

    }

    public RoleMainRole(string id, string roleId, string mainRoleId) : base(id)
    {
        RoleId = roleId;
        MainRoleId = mainRoleId;
    }
    public string RoleId { get; set; }
    public string MainRoleId { get; set; }

    [ForeignKey("AppRoleId")]
    public AppRole AppRole { get; set; }

    [ForeignKey("MainRoleId")]
    public MainRole MainRole { get; set; }

}
