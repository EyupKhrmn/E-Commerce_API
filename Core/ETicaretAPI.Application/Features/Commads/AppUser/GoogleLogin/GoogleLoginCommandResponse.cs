using System.Reflection.Metadata.Ecma335;
using ETicaretAPI.Application.DTOs;

namespace ETicaretAPI.Application.Features.Commads.AppUser.GoogleLogin;

public class GoogleLoginCommandResponse
{
    public Token Token { get; set; }
}