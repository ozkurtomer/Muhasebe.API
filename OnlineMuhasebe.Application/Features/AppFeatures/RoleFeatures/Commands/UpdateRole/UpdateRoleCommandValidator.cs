using FluentValidation;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id bilgisi boş olamaz!");
        RuleFor(p => p.Id).NotNull().WithMessage("Id bilgisi boş olamaz!!");

        RuleFor(p => p.Code).NotEmpty().WithMessage("Rol kodu boş olamaz!");
        RuleFor(p => p.Code).NotNull().WithMessage("Rol kodu boş olamaz!");

        RuleFor(p => p.Name).NotEmpty().WithMessage("Rol adı boş olamaz!");
        RuleFor(p => p.Name).NotNull().WithMessage("Rol adı boş olamaz!");
    }
}
