using Moq;
using Shouldly;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

namespace Muhasebe.API.UnitTest.Features.AppFeatures.CompanyFeatures.Commands;

public sealed class CreateCompanyCommandUnitTest
{
    private readonly Mock<ICompanyService> CompanyService;

    public CreateCompanyCommandUnitTest()
    {
        CompanyService = new();
    }

    [Fact]
    public async Task CompanyShouldBeNull()
    {
        Company company = (await CompanyService.Object.GetCompanyByName("Özkurt Ltd. Şti."))!;
        company.ShouldBeNull();
    }

    [Fact]
    public async Task CreateCompanyCommandResponseShouldNotBeNull()
    {
        var command = new CreateCompanyCommand("Özkurt Ltd. Şti.", "localhost", "OzkurtMuhasebeDb", "", "");

        var handler = new CreateCompanyCommandHandler(CompanyService.Object);

        CreateCompanyCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
