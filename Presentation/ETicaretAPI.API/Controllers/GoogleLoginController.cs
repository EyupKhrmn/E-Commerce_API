using System.Security.Claims;
using ETicaretAPI.API.Controllers.Base;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers;

public class GoogleLoginController : BaseController
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public GoogleLoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> LoginIsGoogle(string ReturnUrl = "/")
{
    ExternalLoginInfo loginInfo = await _signInManager.GetExternalLoginInfoAsync();
    if (loginInfo == null)
        return RedirectToAction("LoginIsGoogle");
    else
    {
        Microsoft.AspNetCore.Identity.SignInResult loginResult = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
        if (loginResult.Succeeded)
            return Redirect(ReturnUrl);
        {
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
    }
    return Redirect(ReturnUrl);
}
}