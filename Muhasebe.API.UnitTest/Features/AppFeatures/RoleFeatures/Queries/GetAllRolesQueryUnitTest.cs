using Moq;
using Shouldly;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using OnlineMuhasebe.Application.Services.AppServices;

namespace Muhasebe.API.UnitTest.Features.AppFeatures.RoleFeatures.Queries;

public sealed class GetAllRolesQueryUnitTest
{
    private readonly Mock<IRoleService> RoleService;

    public GetAllRolesQueryUnitTest()
    {
        RoleService = new();
    }

    [Fact]
    public async Task GetAllRoleQueryResponseNotBeNull()
    {
        _ = RoleService.Setup(x => x.GetAllRolesAsync()).ReturnsAsync(new List<AppRole>());
    }
}
