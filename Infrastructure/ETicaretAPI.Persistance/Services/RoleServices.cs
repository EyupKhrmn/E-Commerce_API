using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Persistance.Services;

public class RoleServices : IRoleService
{
    private readonly RoleManager<AppUserRole> _roleManager;

    public RoleServices(RoleManager<AppUserRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public object GetAllRoles(int page,int size)
    {
      return _roleManager.Roles.Skip(page*size).Take(size).Select(r => new {r.Id,r.Name});
    }

    public async Task<(string id, string name)> GetAllRolesById(string id)
    {
       string role = await _roleManager.GetRoleIdAsync(new() { Id = id });
       return (id, role);
    }

    public async Task<bool> CreateRole(string name)
    {
      IdentityResult result = await  _roleManager.CreateAsync(new() { Id = Guid.NewGuid().ToString(), Name = name });
      return result.Succeeded;
    }

    public async Task<bool> DeleteRole(string id)
    {
        AppUserRole appUserRole = await _roleManager.FindByIdAsync(id);
        IdentityResult result = await _roleManager.DeleteAsync(appUserRole);
       return result.Succeeded;
    }

    public async Task<bool> UpdateRole(string id,string name)
    {
        AppUserRole appUserRole = await _roleManager.FindByIdAsync(id);
        appUserRole.Name = name;
        IdentityResult result = await _roleManager.UpdateAsync(appUserRole);
        return result.Succeeded;
    }
}