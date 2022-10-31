using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories.BasketItem;

public class BasketItemReadRepository : ReadRepository<Domain.Entities.BasketItem>, IBasketItemReadRepository
{
    public BasketItemReadRepository(ETicaretApıDbContext context) : base(context)
    {
    }
}