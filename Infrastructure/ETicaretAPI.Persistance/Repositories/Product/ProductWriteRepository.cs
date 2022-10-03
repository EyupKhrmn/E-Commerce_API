using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories;

public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
{
    public ProductWriteRepository(ETicaretApıDbContext context) : base(context)
    {
    }
}