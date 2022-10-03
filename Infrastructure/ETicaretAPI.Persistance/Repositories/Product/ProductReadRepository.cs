using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories.Product;

public class ProductReadRepository : ReadRepository<Domain.Entities.Product>, IProductReadRepository
{
    public ProductReadRepository(ETicaretApıDbContext context) : base(context)
    {
    }
}