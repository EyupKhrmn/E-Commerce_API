using System.Net;
using ETicaretAPI.API.Controllers.Base;
using ETicaretAPI.Application.Features.Commads.Product.CreateProduct;
using ETicaretAPI.Application.Features.Commads.Product.DeleteProduct;
using ETicaretAPI.Application.Features.Commads.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProductQueryRequest;
using ETicaretAPI.Application.Features.Queries.Product.GetByIdProductQueryRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/Products")]
public class ProductController : BaseController
{
    private readonly IMediator _mediator;
    
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    
    [HttpGet("GetAllProduct")]
    public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
    {
      GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
      return Ok(response.GetAllProducts);
    }
    
    
    [HttpGet("Id")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdProductQueryRequest getByIdProductQueryRequest)
    {
        GetByIdProductQueryResponse value = await _mediator.Send(getByIdProductQueryRequest);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
    {
        CreateProductCommandResponse createProductCommandResponse = await _mediator.Send(createProductCommandRequest);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateProductCommandRequest updateProductCommandRequest)
    {
      UpdateProductCommandResponse result = await _mediator.Send(updateProductCommandRequest);
      return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteProductCommandRequest deleteProductCommandRequest)
    {
       await _mediator.Send(deleteProductCommandRequest);
       return Ok("Ürün Silindi!!");
    }
    
}