using ETicaretAPI.Application.Abstraction.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Basket.GetAllBasketItem;

public class GetAllBasketItemQueryHandler : IRequestHandler<GetAllBasketItemQueryRequest,List<GetAllBasketItemQueryResponse>>
{
    private readonly IBasketService _basketService;

    public GetAllBasketItemQueryHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<List<GetAllBasketItemQueryResponse>> Handle(GetAllBasketItemQueryRequest request, CancellationToken cancellationToken)
    {
        var basketıtems = await _basketService.GetBasketItemAsync();
        return basketıtems.Select(ba => new GetAllBasketItemQueryResponse
        {
            BasketItemID = ba.Id.ToString(),
            ProductName = ba.Product.Name,
            Price = ba.Product.Price,
            Quantity = ba.Quantity
        }).ToList();
    }
}