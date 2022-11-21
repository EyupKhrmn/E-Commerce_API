using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Repositories.Order;

namespace ETicaretAPI.Persistance.Services;

public class OrderService : IOrderService
{
    private readonly IOrderWriteRepository _orderWriteRepository;

    public OrderService(IOrderWriteRepository orderWriteRepository)
    {
        _orderWriteRepository = orderWriteRepository;
    }

    public async Task CreateOrderAsync(CreateOrder order)
    {
       await _orderWriteRepository.AddAsync(new()
        {
            Address = order.Address,
            Description = order.Description
        });

       await _orderWriteRepository.SaveAsync();
    }
}