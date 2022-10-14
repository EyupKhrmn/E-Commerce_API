using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Product.DeleteProduct;

public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
{
    public string Id { get; set; }
}