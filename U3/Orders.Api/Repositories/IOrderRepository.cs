using Orders.Api.models;
using Orders.Api.models.dtos;

namespace Orders.Api.Repositories
{
    public interface IOrderRepository
    {
        Task<DapperResponse> GetAllAsync(string? status = null, int? customerId = null, string? orderNumber = null);
        Task<DapperResponse> GetByIdAsync(int orderId);
        Task<DapperResponse> CreateAsync(CreateOrderDto createOrderDto);
        Task<DapperResponse> UpdateAsync(int orderId, UpdateOrderDto updateOrderDto);
        Task<DapperResponse> DeleteAsync(int orderId);
    }
}
