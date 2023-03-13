using Moq;
using Shouldly;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using OnlineMuhasebe.Persistence.Services.AppServices;

namespace Muhasebe.API.UnitTest.Features.AppFeatures.MainRoleFeatures.Commands;

public sealed class UpdateMainRoleCommandUnitTest
{
    private readonly Mock<IMainRoleService> MainRoleService;

    public UpdateMainRoleCommandUnitTest()
    {
        MainRoleService = new();
    }

    [Fact]
    public async Task MainRoleShouldNotBeNull()
    {
        _ = MainRoleService.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new MainRole());
    }

    [Fact]
    public async Task MainRoleCommandResponseShouldNotBeNull()
    {
        var command = new UpdateMainRoleCommand(Id: "20ee3589-9aee-4155-8772-27d5285ecc8a", Title: "Admin");

        _ = MainRoleService.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new MainRole());

        var handler = new UpdateMainRoleCommandHandler(MainRoleService.Object);

        UpdateMainRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
