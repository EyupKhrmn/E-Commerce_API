using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.DTOs.User;
using ETicaretAPI.Application.Exeptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commads.AppUser.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
{
    private readonly IUserService _userservice;

    public CreateUserCommandHandler(IUserService userservice)
    {
        _userservice = userservice;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
       CreateUserResponseDTO responseDto = await _userservice.CreateAsync(new()
       {
           Email = request.Email,
           NameSurname = request.NameSurname,
           Password = request.Password,
           PasswordConfirm = request.PasswordConfirm,
           UserName = request.UserName
       });

       return new()
       {
           Message = responseDto.Message,
           IsSucceeded = responseDto.IsSucceeded
       };

    }
}