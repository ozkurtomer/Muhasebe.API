using FluentValidation;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Commands.DeleteByIdRoleMainRole;

public sealed class DeleteByIdRoleMainRoleCommandValidator : AbstractValidator<DeleteByIdRoleMainRoleCommand>
{
	public DeleteByIdRoleMainRoleCommandValidator()
	{
		RuleFor(x=>x.id).NotEmpty().WithMessage("Silmek istediğiniz rol bağlantısı boş olmamalıdır!");
	}
}
