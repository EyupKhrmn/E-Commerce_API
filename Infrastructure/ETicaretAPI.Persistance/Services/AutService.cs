using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.Abstraction.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Exeptions;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ETicaretAPI.Persistance.Services;

public class AutService : IAutService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenHandler _tokenHandler;
    private readonly IUserService _userService;

    public AutService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUserService userService)
    {
        _userManager = userManager;
        _tokenHandler = tokenHandler;
        _userService = userService;
    }

    public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
    {
        AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        if (user != null && user?.RefresTokemEndDate > DateTime.UtcNow)
        {
            Token token = _tokenHandler.CreateAccessToken(15);
            _userService.UpdateRefreshToken(token.RefreshToken,user,token.Expiration,15);
            return token;
        }
        else
        {
            throw new NotFoundUserException();
        }
        
    }
}