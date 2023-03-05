﻿using OnlineMuhasebe.Domain.CompanyEntities;
using OnlineMuhasebe.Domain.Repositories.GenericRepositories.CompanyDbContextRepositories;

namespace OnlineMuhasebe.Domain.Repositories.UniformChartOfAccountRepositories;

public interface IUniformChartOfAccountCommandRepository : ICompanyCommandRepository<UniformChartOfAccount>
{
}
