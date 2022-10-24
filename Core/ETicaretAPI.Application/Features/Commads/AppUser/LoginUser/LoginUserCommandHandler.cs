using System.Security.Authentication;
using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.Abstraction.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Exeptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commads.AppUser.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest,LoginUserCommandResponse>
{
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
    private readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
    private readonly ITokenHandler _tokenHandler;
    private readonly IUserService _userService;

    public LoginUserCommandHandler(
        UserManager<Domain.Entities.Identity.AppUser> userManager, 
        SignInManager<Domain.Entities.Identity.AppUser> signInManager,
        ITokenHandler tokenHandler, IUserService userService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
        _userService = userService;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
        if (user == null) 
            user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);


        if (user == null)
            throw new NotFoundUserException();


       SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
       if (result.Succeeded)
       {
          Token token = _tokenHandler.CreateAccessToken(10);
          _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 15);
          return new LoginUserSuccessCommandResponse
          {
              Token = token
          };
       }

       // return new LoginUserErrorCommandResponse()
       // {
       //     Message = "Kullanıcı Adı veya Şifre hatalıdır !"
       // };

       throw new AuthenticationErrorException();
    }
}