using AutoMapper;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Domain.CompanyEntities;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

namespace OnlineMuhasebe.Persistence.MappingsProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCompanyCommand, Company>().ReverseMap();
        CreateMap<CreateUniformChartOfAccount, UniformChartOfAccount>().ReverseMap();
        CreateMap<CreateRoleCommand, AppRole>().ReverseMap();
        CreateMap<UpdateRoleCommand, AppRole>().ReverseMap();
    }
}
