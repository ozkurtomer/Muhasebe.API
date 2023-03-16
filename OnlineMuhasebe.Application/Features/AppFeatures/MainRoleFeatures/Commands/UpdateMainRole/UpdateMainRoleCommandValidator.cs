using FluentValidation;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;

public sealed class UpdateMainRoleCommandValidator : AbstractValidator<UpdateMainRoleCommand>
{
	public UpdateMainRoleCommandValidator()
	{
		RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Güncellemek istediğiniz ana rol boş olamaz!");
		RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Güncellemek istediğiniz ana rol başlığı boş olamaz!");
	}
}
