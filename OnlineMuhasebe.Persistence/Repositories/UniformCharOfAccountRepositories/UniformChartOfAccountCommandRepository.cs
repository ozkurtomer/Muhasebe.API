﻿using OnlineMuhasebe.Domain.CompanyEntities;
using OnlineMuhasebe.Domain.Repositories.UniformChartOfAccountRepositories;

namespace OnlineMuhasebe.Persistence.Repositories.UniformCharOfAccountRepositories;

public class UniformChartOfAccountCommandRepository : CommandRepository<UniformChartOfAccount>, IUniformChartOfAccountCommandRepository
{
}
