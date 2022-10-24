using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using ILogger = Google.Apis.Logging.ILogger;

namespace ETicaretAPI.Application.Features.Commads.Product.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest,UpdateProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IProductReadRepository _productReadRepository;
    private readonly ILogger<UpdateProductCommandHandler> _logger;

    public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, ILogger<UpdateProductCommandHandler> logger)
    {
        _productWriteRepository = productWriteRepository;
        _productReadRepository = productReadRepository;
        _logger = logger;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var model =await _productReadRepository.GetByIdAsync(request.Id);
        model.Name = request.Name;
        model.Price = request.Price;
        model.Stock = request.Stock;
        _productWriteRepository.Update(model);
        _productWriteRepository.SaveAsync();
        _logger.LogInformation("Product Updated...");
        return new UpdateProductCommandResponse
        {
            Name = model.Name,
            Price = model.Price,
            Stock = model.Stock
        };
        
    }
}