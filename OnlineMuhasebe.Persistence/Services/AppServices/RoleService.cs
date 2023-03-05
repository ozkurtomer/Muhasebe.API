using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

namespace OnlineMuhasebe.Persistence.Services.AppServices;

public sealed class RoleService : IRoleService
{
    private readonly RoleManager<AppRole> RoleManager;
    private readonly IMapper Mapper;

    public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
    {
        RoleManager = roleManager;
        Mapper = mapper;
    }

    public async Task AddAsync(CreateRoleCommand request)
    {
        var role = Mapper.Map<AppRole>(request);
        role.Id = Guid.NewGuid().ToString();
        await RoleManager.CreateAsync(role);
    }

    public async Task AddRangeAsync(IEnumerable<AppRole> roleList)
    {
        foreach (var role in roleList)
        {
            await RoleManager.CreateAsync(role);
        }
    }

    public async Task UpdateAsync(AppRole role)
    {
        await RoleManager.UpdateAsync(role);
    }

    public async Task DeleteAsync(DeleteRoleCommand request)
    {
        var role = await RoleManager.FindByIdAsync(request.Id);
        await RoleManager.DeleteAsync(role);
    }

    public async Task<IList<AppRole>> GetAllRolesAsync()
    {
        var roles = await RoleManager.Roles.ToListAsync();
        return roles;
    }

    public async Task<AppRole> GetByCodeRoleAsync(string code)
    {
        var role = await RoleManager.Roles.FirstOrDefaultAsync(x=>x.Code == code);
        return role;
    }

    public async Task<AppRole> GetByIdRoleAsync(string id)
    {
        var role = await RoleManager.FindByIdAsync(id);
        return role;
    }
}
