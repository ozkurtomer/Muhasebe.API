using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Domain.UnitOfWorks;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Domain.Repositories.AppDbContextRepositories.MainRoleRepositories;

namespace OnlineMuhasebe.Persistence.Services.AppServices;

public sealed class MainRoleService : IMainRoleService
{
    private readonly IMainRoleCommandRepository MainRoleCommandRepository;
    private readonly IMainRoleQueryRepository MainRoleQueryRepository;
    private readonly IAppUnitOfWork AppUnitOfWork;

    public MainRoleService(IMainRoleCommandRepository mainRoleCommandRepository, IMainRoleQueryRepository mainRoleQueryRepository, IAppUnitOfWork appUnitOfWork)
    {
        MainRoleCommandRepository = mainRoleCommandRepository;
        MainRoleQueryRepository = mainRoleQueryRepository;
        AppUnitOfWork = appUnitOfWork;
    }

    public async Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken)
    {
        await MainRoleCommandRepository.AddAsync(mainRole, cancellationToken);
        await AppUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateRangeAsync(List<MainRole> mainRoles, CancellationToken cancellationToken)
    {
        await MainRoleCommandRepository.AddRangeAsync(mainRoles, cancellationToken);
        await AppUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<MainRole> GetAll()
    {
        return MainRoleQueryRepository.GetAll();
    }

    public async Task<MainRole> GetByTitleAndCompanyId(string title, string companyId, CancellationToken cancellationToken = default)
    {
        if (companyId == null) return await MainRoleQueryRepository.GetFirstByExpression(x => x.Title == title, cancellationToken);

        return await MainRoleQueryRepository.GetFirstByExpression(x => x.Title == title && x.CompanyId == companyId, cancellationToken, false);
    }

    public async Task DeleteByIdAsync(string id)
    {
        await MainRoleCommandRepository.RemoveById(id);
        await AppUnitOfWork.SaveChangesAsync(default);
    }

    public async Task<MainRole> GetByIdAsync(string id)
    {
        return await MainRoleQueryRepository.GetById(id);
    }

    public async Task UpdateAsync(MainRole mainRole, CancellationToken cancellationToken)
    {
        MainRoleCommandRepository.Update(mainRole);
        await AppUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
