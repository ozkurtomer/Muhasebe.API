using FluentValidation;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.DeleteByIdMainRole;

public sealed class DeleteByIdMainRoleCommandValidator : AbstractValidator<DeleteByIdMainRoleCommand>
{
	public DeleteByIdMainRoleCommandValidator()
	{
		RuleFor(x=>x.Id).NotEmpty().WithMessage("Silmek istediğiniz ana rol boş olamaz!");
	}
}
