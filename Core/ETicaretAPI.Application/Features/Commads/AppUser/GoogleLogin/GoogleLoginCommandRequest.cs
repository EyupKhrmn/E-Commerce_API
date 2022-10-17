using MediatR;

namespace ETicaretAPI.Application.Features.Commads.AppUser.GoogleLogin;

public class GoogleLoginCommandRequest : IRequest<GoogleLoginCommandResponse>
{
    public string Id { get; set; }
    public string IdToken { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public string Provider { get; set; }
    public string PhotoUrl { get; set; }
}