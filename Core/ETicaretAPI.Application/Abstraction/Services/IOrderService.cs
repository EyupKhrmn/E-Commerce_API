using ETicaretAPI.Application.DTOs.Order;

namespace ETicaretAPI.Application.Abstraction.Services;

public interface IOrderService
{
    Task CreateOrderAsync(CreateOrder order);
}