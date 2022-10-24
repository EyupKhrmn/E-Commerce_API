using ETicaretAPI.Application.Abstraction.Token;
using ETicaretAPI.Application.DTOs;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace ETicaretAPI.Application.Features.Commads.AppUser.GoogleLogin;

public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
{
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
    private readonly ITokenHandler _tokenHandler;

    public GoogleLoginCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, ITokenHandler tokenHandler)
    {
        _userManager = userManager;
        _tokenHandler = tokenHandler;
    }

    public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request,
        CancellationToken cancellationToken)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string> {"804671043093-v9vep3ot6h3te1su4knq3ac4bca3n5hi.apps.googleusercontent.com"}
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken,settings);

       var info = new UserLoginInfo(request.Provider,payload.Subject, request.Provider);

       Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);


       bool result = user != null;
       if (user == null)
       {
           user = await _userManager.FindByEmailAsync(payload.Email);
           if (user == null)
           {
               user = new()
               {
                   Id = Guid.NewGuid().ToString(),
                   Email = payload.Email,
                   UserName = payload.Email,
                   NameSurname = payload.Name
               };
               var identityresult = await _userManager.CreateAsync(user);
               result = identityresult.Succeeded;
           }
       }

       if (result)
           await _userManager.AddLoginAsync(user, info);
       else
           throw new Exception("Invalid external outhentication");

       Token token = _tokenHandler.CreateAccessToken(15);

       return new()
       {
           Token = token
       };

    }
}