using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Basket.DeleteBasketItem;

public class DeleteBasketItemCommandRequest : IRequest<DeleteBasketItemCommandResponse>
{
    public string BasketItemId { get; set; }
}