using Moq;
using Shouldly;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Commands.DeleteByIdRoleMainRole;
using OnlineMuhasebe.Domain.AppEntities;

namespace Muhasebe.API.UnitTest.Features.AppFeatures.RoleMainRoleFeatures.Commands;

public sealed class DeleteByIdRoleMainRoleCommandUnitTest
{
    private readonly Mock<IRoleMainRoleService> RoleMainRoleService;

    public DeleteByIdRoleMainRoleCommandUnitTest()
    {
        RoleMainRoleService = new();
    }

    [Fact]
    public async Task RoleMainRoleShouldNotBeNull()
    {
        RoleMainRoleService.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new RoleMainRole());
    }

    [Fact]
    public async Task DeleteByIdRoleMainRoleCommandResponseShouldNotBeNull()
    {
        var command = new DeleteByIdRoleMainRoleCommand(id: "13473444-51e7-4ad1-aaee-a9e6fcc8c7af");

        var handler = new DeleteByIdRoleMainRoleCommandHandler(RoleMainRoleService.Object);

        RoleMainRoleService.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new RoleMainRole());

        var response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
