using FluentValidation;

namespace OnlineMuhasebe.Application.Features.AppFeatures.AppUserFeatures.Commands.Login;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.EmailOrUserName).NotEmpty().WithMessage("Mail veya Kullanıcı Adı zorunludur!");
        RuleFor(x => x.EmailOrUserName).NotNull().WithMessage("Mail veya Kullanıcı Adı zorunludur!");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez!");
        RuleFor(p => p.Password).NotNull().WithMessage("Şifre alanı boş geçilemez!");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez!");
        RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır!");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz en az 1 adet büyük harf içermelidir!");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir!");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayı içermelidir!");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir!");
    }
}
