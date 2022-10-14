using ETicaretAPI.Application.Repositories;
using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Product.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest,UpdateProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IProductReadRepository _productReadRepository;

    public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
    {
        _productWriteRepository = productWriteRepository;
        _productReadRepository = productReadRepository;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var model =await _productReadRepository.GetByIdAsync(request.Id);
        model.Name = request.Name;
        model.Price = request.Price;
        model.Stock = request.Stock;
        _productWriteRepository.Update(model);
        _productWriteRepository.SaveAsync();
        return new UpdateProductCommandResponse
        {
            Name = model.Name,
            Price = model.Price,
            Stock = model.Stock
        };
        
    }
}