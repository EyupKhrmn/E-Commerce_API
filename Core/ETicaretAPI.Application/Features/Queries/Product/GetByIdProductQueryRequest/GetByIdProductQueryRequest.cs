using System.Globalization;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Product.GetByIdProductQueryRequest;

public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
{
    public string Id { get; set; }
}