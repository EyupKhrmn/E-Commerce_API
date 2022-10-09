using System.Net;
using ETicaretAPI.API.Controllers.Base;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
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
    public async Task<IActionResult> Get()
    {
        return Ok(_productReadRepository.GetAll(false));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _productReadRepository.GetByIdAsync(id, false));
    }

    [HttpPost]
    public async Task<IActionResult> Post(VM_Create_Product model)
    {
        _productWriteRepository.AddAsync(new()
        {
            Name = model.Name,
            Price = model.Price,
            Stock = model.Stock
        });
        await _productWriteRepository.SaveAsync();
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> Put(VM_Update_Product model)
    {
       Product product = await _productReadRepository.GetByIdAsync(model.Id);
       product.Name = model.Name;
       product.Price = model.Price;
       product.Stock = model.Stock;
       _productWriteRepository.SaveAsync();
        return Ok();
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var value = await _productWriteRepository.RemoveAsync(id);
        await _productWriteRepository.SaveAsync();
        return Ok(value);
    }
}