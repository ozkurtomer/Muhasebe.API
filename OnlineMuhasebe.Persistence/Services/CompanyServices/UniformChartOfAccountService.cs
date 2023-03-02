using AutoMapper;
using OnlineMuhasebe.Domain;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.CompanyEntities;
using OnlineMuhasebe.Domain.Repositories.UniformChartOfAccountRepositories;
using OnlineMuhasebe.Application.Services.CompanyServices;
using OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

namespace OnlineMuhasebe.Persistence.Services.CompanyServices;

public sealed class UniformChartOfAccountService : IUniformChartOfAccountService
{
    private readonly IUniformChartOfAccountCommandRepository UniformChartOfAccountCommandRepository;
    private readonly IContextService ContextService;
    private CompanyDbContext Context;
    private readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public UniformChartOfAccountService(IUniformChartOfAccountCommandRepository uniformChartOfAccountCommandRepository, IContextService contextService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        UniformChartOfAccountCommandRepository = uniformChartOfAccountCommandRepository;
        ContextService = contextService;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
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
}
