using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllMainRole;

public sealed class GetAllMainRoleQueryHandler : IQueryHandler<GetAllMainRoleQuery, GetAllMainRoleQueryResponse>
{
    private readonly IMainRoleService MainRoleService;

    public GetAllMainRoleQueryHandler(IMainRoleService mainRoleService)
    {
        MainRoleService = mainRoleService;
    }

    public async Task<GetAllMainRoleQueryResponse> Handle(GetAllMainRoleQuery request, CancellationToken cancellationToken)
    {
        var result = await MainRoleService.GetAll().ToListAsync();
        return new(result);
    }
}
