using FluentValidation;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;

public sealed class CreateMainRoleCommandValidator : AbstractValidator<CreateMainRoleCommand>
{
	public CreateMainRoleCommandValidator()
	{
		RuleFor(x => x.CompanyId).NotEmpty().NotNull().WithMessage("Şirket bilgisi boş olamaz!");
		RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Role başlığı boş olamaz!");
	}
}
