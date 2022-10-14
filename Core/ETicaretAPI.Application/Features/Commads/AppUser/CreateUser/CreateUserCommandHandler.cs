using ETicaretAPI.Application.Exeptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commads.AppUser.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
{
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

    public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
       IdentityResult result = await _userManager.CreateAsync(new()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = request.NameSurname,
            Email = request.Email,
            NameSurname = request.NameSurname
        }, request.Password);


       CreateUserCommandResponse response = new() { IsSucceeded = result.Succeeded };
       if (result.Succeeded)
            response.Message = "Kullanıcı başarıyla oluşturulmuştur !";
       else
           foreach (var error in result.Errors)
               response.Message += $"{error.Code} - {error.Description}<br>";

       return response;
    }
}