using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Google.Apis.Logging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProductQueryRequest;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest,GetAllProductQueryResponse>
{

    private readonly IProductReadRepository _productReadRepository;
    private readonly ILogger<GetAllProductQueryHandler> _logger;

    public GetAllProductQueryHandler(IProductReadRepository productReadRepository, ILogger<GetAllProductQueryHandler> logger)
    {
        _productReadRepository = productReadRepository;
        _logger = logger;
    }
    
    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetAllProduct");
        IQueryable<Domain.Entities.Product> getAll = _productReadRepository.GetAll();
        return new GetAllProductQueryResponse
        {
            GetAllProducts = getAll
        };

    }
}