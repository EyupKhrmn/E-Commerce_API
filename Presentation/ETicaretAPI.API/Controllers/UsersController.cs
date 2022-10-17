using System.Security.Claims;
using ETicaretAPI.API.Controllers.Base;
using ETicaretAPI.Application.Features.Commads.AppUser.CreateUser;
using ETicaretAPI.Application.Features.Commads.AppUser.GoogleLogin;
using ETicaretAPI.Application.Features.Commads.AppUser.LoginUser;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers;

public class UsersController : BaseController
{
    private readonly IMediator _mediator;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public UsersController(IMediator mediator, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _mediator = mediator;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
    {
        CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
        return Ok(response);
    }


    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
    {
        LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
        return Ok(response);
    }

    [HttpPost("SignInWithhGoogle")]
    public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest? googleLoginCommandRequest, string returnUrl)
    {
        string redirectUrl =Url.Action("ExternalResponse", "Users", new { ReturnUrl = returnUrl });
      
        AuthenticationProperties properties =
            _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
        
        return new ChallengeResult("Google", properties);
        


        // GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
        // return Ok(response);
    }
    
    
    //googlee login entegraasyonuna bak yap!!!!!!!!!
    
    
    [HttpPost("ExternalResponse")]
    public async Task<IActionResult> ExternalResponse(string ReturnUrl = "/")
    {
        ExternalLoginInfo loginInfo = await _signInManager.GetExternalLoginInfoAsync();
        if (loginInfo == null)
            return RedirectToAction("Login");
        else
        {
            Microsoft.AspNetCore.Identity.SignInResult loginResult = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
            if (loginResult.Succeeded)
                return Redirect(ReturnUrl);
            AppUser user = new AppUser
                {
                    Email = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value
                };
                
                IdentityResult createResult = await _userManager.CreateAsync(user);
                
                if (createResult.Succeeded)
                {
                    IdentityResult addLoginResult = await _userManager.AddLoginAsync(user, loginInfo);
                  
                    if (addLoginResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, true);
                        return Redirect(ReturnUrl);
                    }
                }
        }
        return Redirect(ReturnUrl);
    }
}