using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.DTOs;
using MediatR;

namespace ETicaretAPI.Application.Features.Commads.RefreshToken;

public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest,RefreshTokenLoginCommandResponse>
{
    private readonly IAutService _autService;

    public RefreshTokenLoginCommandHandler(IAutService autService)
    {
        _autService = autService;
    }

    public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
    {
        Token token = await _autService.RefreshTokenLoginAsync(request.RefreshToken);
        return new RefreshTokenLoginCommandResponse
        {
            Token = token
        };
    }
}