using ETicaretAPI.Application.Abstraction.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Basket.UpdateBasketItem;

public class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommandRequest,UpdateBasketItemCommandResponse>
{
    private readonly IBasketService _basketService;

    public UpdateBasketItemCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<UpdateBasketItemCommandResponse> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
    {
        await _basketService.UpdateQuantityAsync(new()
        {
            BasketItemId = request.BasketItemId,
            Quantity = request.Quantity
        });
        return new();
    }
}