using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Application.Services.AppServices;

public interface IMainRoleService
{
    Task<MainRole> GetByTitleAndCompanyId(string title, string companyId, CancellationToken cancellationToken = default);
    Task<MainRole> GetByIdAsync(string id);
    Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken);
    Task CreateRangeAsync(List<MainRole> mainRoles, CancellationToken cancellationToken);
    Task DeleteByIdAsync(string id);
    Task UpdateAsync(MainRole mainRole, CancellationToken cancellationToken);

    IQueryable<MainRole> GetAll();
}
