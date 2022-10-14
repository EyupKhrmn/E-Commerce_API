using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Product.CreateProduct;

public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }
}