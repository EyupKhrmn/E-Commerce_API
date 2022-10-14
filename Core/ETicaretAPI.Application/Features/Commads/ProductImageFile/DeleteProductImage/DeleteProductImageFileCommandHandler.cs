using MediatR;

namespace ETicaretAPI.Application.Features.Commads.ProductImageFile.DeleteProductImage;

public class DeleteProductImageFileCommandHandler : IRequestHandler<DeleteProductImageFileCommandRequest,DeleteProductImageFileCommandResponse>
{
    public Task<DeleteProductImageFileCommandResponse> Handle(DeleteProductImageFileCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}