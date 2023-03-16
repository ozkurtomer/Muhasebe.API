using FluentValidation;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Commands.CreateRoleMainRole;

public sealed class CreateRoleMainRoleCommandValidator : AbstractValidator<CreateRoleMainRoleCommand>
{
    public CreateRoleMainRoleCommandValidator()
    {
        RuleFor(p => p.RoleId).NotEmpty().WithMessage("Rol seçilmelidir!");
        RuleFor(p => p.RoleId).NotNull().WithMessage("Rol seçilmelidir!");
        RuleFor(p => p.MainRoleId).NotNull().WithMessage("Ana Rol seçilmelidir!");
        RuleFor(p => p.MainRoleId).NotEmpty().WithMessage("Ana Rol seçilmelidir!");
    }
}
