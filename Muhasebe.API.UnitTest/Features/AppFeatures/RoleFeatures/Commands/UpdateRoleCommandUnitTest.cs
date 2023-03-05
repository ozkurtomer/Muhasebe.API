using Moq;
using Shouldly;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

namespace Muhasebe.API.UnitTest.Features.AppFeatures.RoleFeatures.Commands;

public sealed class UpdateRoleCommandUnitTest
{
    private readonly Mock<IRoleService> RoleService;

    public UpdateRoleCommandUnitTest()
    {
        RoleService = new();
    }

    [Fact]
    public async Task AppRoleShouldNotBeNull()
    {
        _ = RoleService.Setup(x => x.GetByIdRoleAsync(It.IsAny<string>())).ReturnsAsync(new AppRole());
    }

    [Fact]
    public async Task AppRoleCodeShouldNotUnique()
    {
        AppRole role = await RoleService.Object.GetByCodeRoleAsync("UniformChartOfAccount.Create");
        role.ShouldBeNull();
    }

    [Fact]
    public async Task UpdateRoleCommandShouldNotBeNull()
    {
        var command = new UpdateRoleCommand("49ff42cf-4ec4-45a3-91e5-044680e40105", "UniformCharOfAccount.Create", "Hesap Planı Kayıt Ekleme");

        _ = RoleService.Setup(x => x.GetByIdRoleAsync(It.IsAny<string>())).ReturnsAsync(new AppRole());

        var handler = new UpdateRoleCommandHandler(RoleService.Object);

        UpdateRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
