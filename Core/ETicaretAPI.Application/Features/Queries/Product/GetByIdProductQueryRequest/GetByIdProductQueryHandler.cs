using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Product.GetByIdProductQueryRequest;

public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest,GetByIdProductQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository;

    public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
    {
       
       var result = await _productReadRepository.GetByIdAsync(request.Id,false);
       return new GetByIdProductQueryResponse
       {
           Name = result.Name,
           Price = result.Price,
           Stock = result.Stock
       };
    }
}