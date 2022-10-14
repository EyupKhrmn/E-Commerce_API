

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProductQueryRequest;

public class GetAllProductQueryResponse
{
    public IQueryable<Domain.Entities.Product> GetAllProducts { get; set; }
}