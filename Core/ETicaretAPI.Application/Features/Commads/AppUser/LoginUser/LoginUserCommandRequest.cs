using MediatR;

namespace ETicaretAPI.Application.Features.Commads.AppUser.LoginUser;

public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
{
    public string UsernameOrEmail  { get; set; }
    public string Password { get; set; }
}