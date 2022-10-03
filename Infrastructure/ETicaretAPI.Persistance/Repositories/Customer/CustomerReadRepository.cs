using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories;

public class CustomerReadRepository : ReadRepository<Domain.Entities.Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(ETicaretApıDbContext context) : base(context)
    {
    }
}