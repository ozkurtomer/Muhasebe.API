using FluentValidation;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

public sealed class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id bilgisi boş olamaz!");
        RuleFor(p => p.Id).NotNull().WithMessage("Id bilgisi boş olamaz!!");
    }
}
