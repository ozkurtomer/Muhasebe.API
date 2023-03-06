using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Application.Services.AppServices;

public interface IMainRoleService
{
    Task<MainRole> GetByTitleAndCompanyId(string title, string companyId, CancellationToken cancellationToken);
    Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken);
    Task CreateRangeAsync(List<MainRole> mainRoles, CancellationToken cancellationToken);
}
