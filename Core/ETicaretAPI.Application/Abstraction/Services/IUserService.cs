using ETicaretAPI.Application.DTOs.User;
using ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Abstraction.Services;

public interface IUserService
{
    Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO model);
    Task UpdateRefreshToken(string refreshtoken, AppUser user,DateTime accesstokenDateTime,int addonaccesstoken);
    
    
}