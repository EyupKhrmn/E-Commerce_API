using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories.BasketItem;

public class BasketItemWriteRepository : WriteRepository<Domain.Entities.BasketItem> , IBasketItemWriteRepository
{
    public BasketItemWriteRepository(ETicaretApıDbContext context) : base(context)
    {
    }
}