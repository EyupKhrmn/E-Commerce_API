using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProductQueryRequest;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest,GetAllProductQueryResponse>
{

    private readonly IProductReadRepository _productReadRepository;

    public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }
    
    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Product> getAll =  _productReadRepository.GetAll();
        return new GetAllProductQueryResponse
        {
            GetAllProducts = getAll
        };

    }
}