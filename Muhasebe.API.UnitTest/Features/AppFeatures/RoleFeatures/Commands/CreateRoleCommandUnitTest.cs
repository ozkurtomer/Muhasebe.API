using Moq;
using Shouldly;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

namespace Muhasebe.API.UnitTest.Features.AppFeatures.RoleFeatures.Commands;

public sealed class CreateRoleCommandUnitTest
{
    private readonly Mock<IRoleService> RoleService;

    public CreateRoleCommandUnitTest()
    {
        RoleService = new();
    }

    [Fact]
    public async Task AppRoleShouldBeNull()
    {
        AppRole role = await RoleService.Object.GetByCodeRoleAsync("UniformCharOfAccount.Create");
        role.ShouldBeNull();
    }

    [Fact]
    public async Task CreateRoleCommandShouldNotBeNull()
    {
        var command = new CreateRoleCommand("UniformCharOfAccount.Create", "Hesap Planı Kayıt Ekleme");

        var handler = new CreateRoleCommandHandler(RoleService.Object);

        CreateRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
