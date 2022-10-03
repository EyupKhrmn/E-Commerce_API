using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories.Order;

public class OrderWriteRepository : WriteRepository<Domain.Entities.Order>, IOrderWriteRepository
{
    public OrderWriteRepository(ETicaretApıDbContext context) : base(context)
    {
    }
}