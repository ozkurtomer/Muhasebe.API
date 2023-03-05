using AutoMapper;
using OnlineMuhasebe.Domain;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.CompanyEntities;
using OnlineMuhasebe.Application.Services.CompanyServices;
using OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;
using OnlineMuhasebe.Domain.Repositories.CompanyDbContextRepositories.UniformChartOfAccountRepositories;
using OnlineMuhasebe.Domain.UnitOfWorks;

namespace OnlineMuhasebe.Persistence.Services.CompanyServices;

public sealed class UniformChartOfAccountService : IUniformChartOfAccountService
{
    private readonly IUniformChartOfAccountCommandRepository UniformChartOfAccountCommandRepository;
    private readonly IUniformChartOfAccountQueryRepository UniformChartOfAccountQueryRepository;
    private readonly IContextService ContextService;
    private CompanyDbContext Context;
    private readonly ICompanyDbUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public UniformChartOfAccountService(IUniformChartOfAccountCommandRepository uniformChartOfAccountCommandRepository, IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper, IUniformChartOfAccountQueryRepository uniformChartOfAccountQueryRepository)
    {
        UniformChartOfAccountCommandRepository = uniformChartOfAccountCommandRepository;
        ContextService = contextService;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        UniformChartOfAccountQueryRepository = uniformChartOfAccountQueryRepository;
    }

    public async Task CreateUniformChartOfAccountAsync(CreateUniformChartOfAccountCommand request, CancellationToken token)
    {
        Context = (CompanyDbContext)ContextService.CreateDbContextInstance(request.CompanyId);
        UniformChartOfAccountCommandRepository.SetDbContextInstance(Context);
        UnitOfWork.SetDbContextInstance(Context);

        UniformChartOfAccount uniformChartOfAccount = Mapper.Map<UniformChartOfAccount>(request);
        uniformChartOfAccount.Id = Guid.NewGuid().ToString();
        await UniformChartOfAccountCommandRepository.AddAsync(uniformChartOfAccount, token);

        await UnitOfWork.SaveChangesAsync(token);
    }

    public async Task<UniformChartOfAccount> GetByCodeAsync(string code)
    {
        return await UniformChartOfAccountQueryRepository.GetFirstByExpression(x => x.Code == code);
    }
}
