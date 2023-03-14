using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Application.Services.AppServices;

public interface IAppUserCompanyService
{
    Task CreateAsync(AppUserCompany appUserCompany, CancellationToken cancellationToken);
    Task RemoveByIdAsync(string id);
    Task<AppUserCompany> GetByIdAsync(string id);
    Task<AppUserCompany> GetByUserIdAndCompanyId(string userId, string companyId, CancellationToken cancellationToken);
    Task<IList<AppUserCompany>> GetListByUserId(string userId);
}
