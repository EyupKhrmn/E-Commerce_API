namespace ETicaretAPI.Application.Features.Queries.Basket.GetAllBasketItem;

public class GetAllBasketItemQueryResponse
{
    public string BasketItemID { get; set; }
    public string ProductName { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
}