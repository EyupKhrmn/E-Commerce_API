using ETicaretAPI.Application.Abstraction.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Basket.CreateBasketItem;

public class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommandRequest,CreateBasketItemCommandResponse>
{
    private readonly IBasketService _basketService;

    public CreateBasketItemCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<CreateBasketItemCommandResponse> Handle(CreateBasketItemCommandRequest request, CancellationToken cancellationToken)
    {
       await _basketService.AddItemToBasketAsync(new()
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity
        });

       return new();
    }
}