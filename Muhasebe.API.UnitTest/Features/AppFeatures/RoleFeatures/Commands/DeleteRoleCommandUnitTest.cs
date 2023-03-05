using Moq;
using Shouldly;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

namespace Muhasebe.API.UnitTest.Features.AppFeatures.RoleFeatures.Commands;

public sealed class DeleteRoleCommandUnitTest
{
    private readonly Mock<IRoleService> RoleService;

    public DeleteRoleCommandUnitTest()
    {
        RoleService = new();
    }

    [Fact]
    public async Task AppRoleShouldNotBeNull()
    {
        _ = RoleService.Setup(x => x.GetByIdRoleAsync(It.IsAny<string>())).ReturnsAsync(new AppRole());
    }

    [Fact]
    public async Task DeleteRoleCommandShouldNotBeNull()
    {
        var command = new DeleteRoleCommand("49ff42cf-4ec4-45a3-91e5-044680e40105");

        _ = RoleService.Setup(x => x.GetByIdRoleAsync(It.IsAny<string>())).ReturnsAsync(new AppRole());

        var handler = new DeleteRoleCommandHandler(RoleService.Object);

        DeleteRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
