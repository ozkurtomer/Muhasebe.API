using Moq;
using Shouldly;
using OnlineMuhasebe.Domain.CompanyEntities;
using OnlineMuhasebe.Application.Services.CompanyServices;
using OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

namespace Muhasebe.API.UnitTest.Features.CompanyFeatures.Commands;

public sealed class CreateUniformChartOfAccountCommandUnitTest
{
    private readonly Mock<IUniformChartOfAccountService> UniformChartOfAccountService;
    public CreateUniformChartOfAccountCommandUnitTest()
    {
        UniformChartOfAccountService = new Mock<IUniformChartOfAccountService>();
    }

    [Fact]
    public async Task UniformChartOfAccountShouldBeNull()
    {
        UniformChartOfAccount uniformChartOfAccount = await UniformChartOfAccountService.Object.GetByCodeAsync("100.01.001");
        uniformChartOfAccount.ShouldBeNull();
    }

    [Fact]
    public async Task CreateUniformChartOfAccountCommandShouldNotBeNull()
    {
        var command = new CreateUniformChartOfAccountCommand("4f1f359d-e216-4c64-aadf-91166140b248", "100.01.001", "", "B");

        var handler = new CreateUniformChartOfAccountCommandHandler(UniformChartOfAccountService.Object);

        CreateUniformChartOfAccountCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }

}