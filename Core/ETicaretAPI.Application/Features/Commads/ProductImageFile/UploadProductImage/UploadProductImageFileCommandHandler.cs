using MediatR;

namespace ETicaretAPI.Application.Features.Commads.ProductImageFile.UploadProductImage;

public class UploadProductImageFileCommandHandler : IRequestHandler<UploadProductImageFileCommandRequest,UploadProductImageFileCommandResponse>
{
    public Task<UploadProductImageFileCommandResponse> Handle(UploadProductImageFileCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}