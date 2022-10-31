using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.Repositories.Basket;
using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Application.ViewModel.BasketViewModel;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistance.Repositories.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistance.Services;

public class BasketServices : IBasketService
{
    private readonly HttpContextAccessor _httpContextAccessor;
    private readonly UserManager<AppUser> _userManager;
    private readonly OrderReadRepository _orderReadRepository;
    private readonly IBasketWriteREpository _basketWriteREpository;
    private readonly IBasketItemWriteRepository _basketItemWriteRepository;
    private readonly IBasketItemReadRepository _basketItemReadRepository;
    public readonly IBasketReadRepository _basketReadRepository;

    public BasketServices(HttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager,
        OrderReadRepository orderReadRepository, IBasketWriteREpository basketWriteREpository,
        IBasketItemWriteRepository basketItemWriteRepository, IBasketReadRepository basketReadRepository,
        IBasketItemReadRepository basketItemReadRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _orderReadRepository = orderReadRepository;
        _basketWriteREpository = basketWriteREpository;
        _basketItemWriteRepository = basketItemWriteRepository;
        _basketReadRepository = basketReadRepository;
        _basketItemReadRepository = basketItemReadRepository;
    }

    private async Task<Basket?> ContextUser()
    {
        var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
        if (!string.IsNullOrEmpty(username))
        {
            AppUser? user = await _userManager.Users
                .Include(_ => _.Baskets)
                .FirstOrDefaultAsync(u => u.UserName == username);
            var _basket = from basket in user.Baskets
                join order in _orderReadRepository.Table on basket.Id equals order.Id into basketorders
                from order in basketorders.DefaultIfEmpty()
                select new
                {
                    Basket = basket,
                    Order = order
                };
            Basket? targetbasket = null;
            if (_basket.Any(b => b.Order is null))
            {
                targetbasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
            }
            else
            {
                user.Baskets.Add(new());
            }

            await _basketWriteREpository.SaveAsync();
        }

        throw new Exception("Beklenmyen bir hata ile karşılaşıldı !");
    }

    public async Task<List<BasketItem>> GetBasketItemAsync()
    {
        Basket basket = await ContextUser();
        Basket? result = await _basketReadRepository.Table
            .Include(b => b.BasketItems)
            .ThenInclude(bi => bi.Product)
            .FirstOrDefaultAsync(b => b.Id == basket.Id);

        return result.BasketItems.ToList();
    }

    public async Task AddItemToBasketAsync(CreateBasketViewModel basketItem)
    {
        Basket? basket = await ContextUser();
        if (basket != null)
        {
            BasketItem _basketItem = await _basketItemReadRepository.GetSingleAsync(bi =>
                bi.BasketId == basket.Id && bi.ProductId == Guid.Parse(basketItem.ProductId));
            if (_basketItem != null)
            {
                _basketItem.Quantity++;
            }
            else
            {
                await _basketItemWriteRepository.AddAsync(new()
                {
                    BasketId = basket.Id,
                    ProductId = Guid.Parse(basketItem.ProductId),
                    Quantity = basketItem.Quantity
                });
            }
        }
    }

    public async Task UpdateQuantityAsync(BasketItemViewModel basketItem)
    {
        BasketItem? _basketItem = await _basketItemReadRepository.GetByIdAsync(basketItem.BasketItemId);
        if (_basketItem != null)
        {
            _basketItem.Quantity = basketItem.Quantity;
            await _basketItemWriteRepository.SaveAsync();
        }
    }

    public async Task RemoveBasketItemAsync(string basketItemId)
    {
        BasketItem? basketıtem =
            await _basketItemReadRepository.GetSingleAsync(bi => bi.Id == Guid.Parse(basketItemId));
        if (basketıtem != null)
        {
            _basketItemWriteRepository.Remove(basketıtem);
            await _basketItemWriteRepository.SaveAsync();
        }
    }
}