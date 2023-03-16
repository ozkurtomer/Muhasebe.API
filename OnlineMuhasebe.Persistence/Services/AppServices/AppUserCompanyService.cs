using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Domain.UnitOfWorks;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Domain.Repositories.AppDbContext.AppUserCompanyRepositories;

namespace OnlineMuhasebe.Persistence.Services.AppServices;

public sealed class AppUserCompanyService : IAppUserCompanyService
{
    private readonly IAppUnitOfWork AppUnitOfWork;
    private readonly IAppUserCompanyQueryRepository QueryRepository;
    private readonly IAppUserCompanyCommandRepository CommandRepository;

    public AppUserCompanyService(IAppUserCompanyCommandRepository commandRepository, IAppUnitOfWork unitOfWork, IAppUserCompanyQueryRepository queryRepository)
    {
        CommandRepository = commandRepository;
        AppUnitOfWork = unitOfWork;
        QueryRepository = queryRepository;
    }

    public async Task CreateAsync(AppUserCompany appUserCompany, CancellationToken cancellationToken)
    {
        await CommandRepository.AddAsync(appUserCompany, cancellationToken);
        await AppUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<AppUserCompany> GetByIdAsync(string id)
    {
        return await QueryRepository.GetById(id);
    }

    public async Task<AppUserCompany> GetByUserIdAndCompanyId(string userId, string companyId, CancellationToken cancellationToken)
    {
        return await QueryRepository.GetFirstByExpression(x => x.AppUserId == userId && x.CompanyId == companyId, cancellationToken);
    }

    public async Task<IList<AppUserCompany>> GetListByUserId(string userId)
    {
        return await QueryRepository.GetWhere(p => p.AppUserId == userId).Include("Company").ToListAsync();
    }

    public async Task RemoveByIdAsync(string id)
    {
        await CommandRepository.RemoveById(id);
        await AppUnitOfWork.SaveChangesAsync(default);
    }
}
