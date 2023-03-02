﻿using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDb;

namespace OnlineMuhasebe.Application.Services.AppServices;

public interface ICompanyService
{
    Task<Company?> GetCompanyByName(string companyName);
    Task MigrateCompanyDbs(MigrateCompanyDbCommand migrateCompanyDbRequest);
    Task CreateCompany(CreateCompanyCommand createCompanyRequest);
}
