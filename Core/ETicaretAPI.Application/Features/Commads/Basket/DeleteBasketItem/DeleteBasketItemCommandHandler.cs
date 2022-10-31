using ETicaretAPI.Application.Abstraction.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Basket.DeleteBasketItem;

public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommandRequest,DeleteBasketItemCommandResponse>
{
    private readonly IBasketService _basketService;

    public DeleteBasketItemCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<DeleteBasketItemCommandResponse> Handle(DeleteBasketItemCommandRequest request, CancellationToken cancellationToken)
    {
        await _basketService.RemoveBasketItemAsync(request.BasketItemId);
        
        return new();
    }
}