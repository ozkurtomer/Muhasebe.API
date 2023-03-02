namespace OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDb;

public sealed record MigrateCompanyDbCommandResponse(
    string Message = "Şirketlerin db tablosu migrate işlemi tamamlandı!");
