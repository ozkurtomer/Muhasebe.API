using Moq;
using Shouldly;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Commands.CreateRoleMainRole;

namespace Muhasebe.API.UnitTest.Features.AppFeatures.RoleMainRoleFeatures.Commands;

public sealed class CreateRoleMainRoleCommandUnitTest
{
    private readonly Mock<IRoleMainRoleService> RoleMainRoleService;

    public CreateRoleMainRoleCommandUnitTest()
    {
        RoleMainRoleService = new();
    }

    [Fact]
    public async Task AppRoleShouldBeNull()
    {
        var role = await RoleMainRoleService.Object.GetByRoleIdMainRoleId(
            roleId: "ea119022-713b-42fb-af5e-cdccaf608d7d",
            mainRoleId: "3ed2bc7c-8885-4743-996e-7d12bbd1e663",
            cancellationToken: default);
        role.ShouldBeNull();
    }

    [Fact]
    public async Task CreateRoleMainRoleCommandShouldNotBeNull()
    {
        var command = new CreateRoleMainRoleCommand(
            RoleId: "ea119022-713b-42fb-af5e-cdccaf608d7d",
            MainRoleId: "3ed2bc7c-8885-4743-996e-7d12bbd1e663");

        var handler = new CreateRoleMainRoleCommandHandler(RoleMainRoleService.Object);

        CreateRoleMainRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
