using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Basket.UpdateBasketItem;

public class UpdateBasketItemCommandRequest : IRequest<UpdateBasketItemCommandResponse>
{
    public string BasketItemId { get; set; }
    public int Quantity { get; set; }
}