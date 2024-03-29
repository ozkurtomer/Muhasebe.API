﻿using OnlineMuhasebe.Domain.CompanyEntities;
using OnlineMuhasebe.Domain.Repositories.CompanyDbContextRepositories.UniformChartOfAccountRepositories;
using OnlineMuhasebe.Persistence.Repositories.GenericRepositories.CompanyDbContextRepositories;

namespace OnlineMuhasebe.Persistence.Repositories.CompanyDbContextRepositories.UniformCharOfAccountRepositories;

public class UniformChartOfAccountQueryRepository : CompanyDbQueryRepository<UniformChartOfAccount>, IUniformChartOfAccountQueryRepository
{
}
