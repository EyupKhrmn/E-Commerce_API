using ETicaretAPI.API.Controllers.Base;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Common;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers;

public class ProductController : BaseController
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;


    public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    [HttpGet]
    public async Task Get()
    {
        await _productWriteRepository.AddRangeAsync(new()
        {
            new (){Id = Guid.NewGuid(),Name = "Ürün 1",CreatedDate = DateTime.Now},
            new (){Id = Guid.NewGuid(),Name = "Ürün 1",CreatedDate = DateTime.Now},
            new (){Id = Guid.NewGuid(),Name = "Ürün 1",CreatedDate = DateTime.Now},
            new (){Id = Guid.NewGuid(),Name = "Ürün 1",CreatedDate = DateTime.Now},
            new (){Id = Guid.NewGuid(),Name = "Ürün 1",CreatedDate = DateTime.Now}
        });
        await _productWriteRepository.SaveAsync();
    }
}