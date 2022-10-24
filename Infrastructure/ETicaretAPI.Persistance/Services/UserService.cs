using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.DTOs.User;
using ETicaretAPI.Application.Exeptions;
using ETicaretAPI.Application.Features.Commads.AppUser.CreateUser;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Persistance.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO model)
    {
        IdentityResult result = await _userManager.CreateAsync(new()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = model.NameSurname,
            Email = model.Email,
            NameSurname = model.NameSurname
        }, model.Password);


        CreateUserResponseDTO response = new() { IsSucceeded = result.Succeeded };
        if (result.Succeeded)
            response.Message = "Kullanıcı başarıyla oluşturulmuştur !";
        else
            foreach (var error in result.Errors)
                response.Message += $"{error.Code} - {error.Description}<br>";

        return response;
    }

    public async Task UpdateRefreshToken(string refreshtoken, AppUser user,DateTime AccessTokenDate,int addonaccesstoken )
    { 
        if (user != null)
        {
            user.RefreshToken = refreshtoken;
            user.RefresTokemEndDate = AccessTokenDate.AddSeconds(addonaccesstoken);
            await _userManager.UpdateAsync(user);
        }

        throw new NotFoundUserException();
    }
}