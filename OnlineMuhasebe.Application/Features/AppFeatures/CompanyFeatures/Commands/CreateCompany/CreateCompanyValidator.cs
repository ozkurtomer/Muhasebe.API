using FluentValidation;

namespace OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyValidator()
    {
        RuleFor(p => p.CompanyDatabaseName).NotEmpty().WithMessage("Database bilgisi yazılmalıdır!");
        RuleFor(p => p.CompanyDatabaseName).NotNull().WithMessage("Database bilgisi yazılmalıdır!");

        RuleFor(p => p.CompanyServerName).NotEmpty().WithMessage("Server bilgisi yazılmalıdır!");
        RuleFor(p => p.CompanyServerName).NotNull().WithMessage("Server bilgisi yazılmalıdır!");

        RuleFor(p => p.CompanyName).NotEmpty().WithMessage("Şirket adı yazılmalıdır!");
        RuleFor(p => p.CompanyName).NotNull().WithMessage("Şirket adı yazılmalıdır!");
    }
}
