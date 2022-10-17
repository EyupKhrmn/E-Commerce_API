using ETicaretAPI.Application.DTOs.User;

namespace ETicaretAPI.Application.Abstraction.Services;

public interface IUserService
{
    Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO model);
}