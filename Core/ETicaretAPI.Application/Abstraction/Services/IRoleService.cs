namespace ETicaretAPI.Application.Abstraction.Services;

public interface IRoleService
{
    object GetAllRoles(int page,int size);
    Task<(string id, string name)> GetAllRolesById(string id);
    Task<bool> CreateRole(string name);
    Task<bool> DeleteRole(string id);
    Task<bool> UpdateRole(string id,string name);
}