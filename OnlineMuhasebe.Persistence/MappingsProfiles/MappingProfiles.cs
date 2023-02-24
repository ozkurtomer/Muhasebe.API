using AutoMapper;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;
using OnlineMuhasebe.Domain.CompanyEntities;

namespace OnlineMuhasebe.Persistence.MappingsProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCompanyRequest, Company>().ReverseMap();
        CreateMap<CreateUniformChartOfAccountRequest, UniformChartOfAccount>().ReverseMap();
    }
}
