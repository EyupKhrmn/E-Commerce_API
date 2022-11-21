using ETicaretAPI.Application.ViewModel.BasketViewModel;
using ETicaretAPI.Domain.Entities;


namespace ETicaretAPI.Application.Abstraction.Services;

public interface IBasketService
{
    public Task<List<BasketItem>> GetBasketItemAsync();
    public Task AddItemToBasketAsync(CreateBasketViewModel basketItem);
    public Task UpdateQuantityAsync(BasketItemViewModel basketItem);
    public Task RemoveBasketItemAsync(string basketItemId);
    public Basket? GetUserActiveBasket { get; }
}