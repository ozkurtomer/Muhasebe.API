using Moq;
using Shouldly;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;

namespace Muhasebe.API.UnitTest.Features.AppFeatures.MainRoleFeatures.Commands;

public sealed class CreateMainRoleCommandUnitTest
{
    private readonly Mock<IMainRoleService> MainRoleService;

    public CreateMainRoleCommandUnitTest()
    {
        MainRoleService = new();
    }

    [Fact]
    public async Task MainRoleShouldBeNull()
    {
        MainRole mainRole = (await MainRoleService.Object.GetByTitleAndCompanyId("Admin", "49ff42cf-4ec4-45a3-91e5-044680e40105"))!;
        mainRole.ShouldBeNull();
    }

    [Fact]
    public async Task MainRoleCommandResponseShouldNotBeNull()
    {
        var command = new CreateMainRoleCommand(Title: "Admin", CompanyId: "49ff42cf-4ec4-45a3-91e5-044680e40105");

        var handler = new CreateMainRoleCommandHandler(MainRoleService.Object);

        CreateMainRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
