using ETicaretAPI.Application.DTOs;

namespace ETicaretAPI.Application.Features.Commads.RefreshToken;

public class RefreshTokenLoginCommandResponse
{
    public Token Token { get; set; }
}