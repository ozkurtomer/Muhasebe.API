using AutoMapper;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

namespace OnlineMuhasebe.Persistence.MappingsProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCompanyRequest, Company>().ReverseMap();
    }
}
