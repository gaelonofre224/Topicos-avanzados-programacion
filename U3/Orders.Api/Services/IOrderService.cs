using Orders.Api.models;
using Orders.Api.models.dtos;

namespace Orders.Api.Services
{
    public interface IOrderService
    {
        Task<IReadOnlyList<Order>> GetAllOrdersAsync(string? status = null, int? customerId = null, string? orderNumber = null);
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<(bool HasError, int? OrderId, string? ErrorMessage)> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<(bool HasError, string? ErrorMessage)> UpdateOrderAsync(int orderId, UpdateOrderDto updateOrderDto);
        Task<(bool HasError, string? ErrorMessage)> DeleteOrderAsync(int orderId);
    }
}
