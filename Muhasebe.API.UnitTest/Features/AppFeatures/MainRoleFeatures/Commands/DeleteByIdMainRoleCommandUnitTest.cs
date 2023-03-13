using Moq;
using Shouldly;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.DeleteByIdMainRole;

namespace Muhasebe.API.UnitTest.Features.AppFeatures.MainRoleFeatures.Commands;

public sealed class DeleteByIdMainRoleCommandUnitTest
{
    private readonly Mock<IMainRoleService> MainRoleService;

    public DeleteByIdMainRoleCommandUnitTest()
    {
        MainRoleService = new();
    }

    [Fact]
    public async Task MainRoleCommandResponseShouldNotBeNull()
    {
        var command = new DeleteByIdMainRoleCommand("49ff42cf-4ec4-45a3-91e5-044680e40105");

        var handler = new DeleteByIdMainRoleCommandHandler(MainRoleService.Object);

        DeleteByIdMainRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
