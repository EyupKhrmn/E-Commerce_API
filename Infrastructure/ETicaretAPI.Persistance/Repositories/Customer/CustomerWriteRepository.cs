using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories.Customer;

public class CustomerWriteRepository : WriteRepository<Domain.Entities.Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(ETicaretApıDbContext context) : base(context)
    {
    }
}