using Orders.Api.models;
using Orders.Api.models.dtos;
using Orders.Api.Repositories;

namespace Orders.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IReadOnlyList<Order>> GetAllOrdersAsync(string? status = null, int? customerId = null, string? orderNumber = null)
        {
            DapperResponse response = await _orderRepository.GetAllAsync(status, customerId, orderNumber);

            if (!response.Success || response.Result is not IEnumerable<Order> orders)
            {
                return Array.Empty<Order>();
            }

            return orders.ToList();
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            DapperResponse response = await _orderRepository.GetByIdAsync(orderId);

            if (!response.Success)
            {
                return null;
            }

            return response.Result as Order;
        }

        public async Task<(bool HasError, int? OrderId, string? ErrorMessage)> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            DapperResponse response = await _orderRepository.CreateAsync(createOrderDto);

            if (!response.Success)
            {
                return (true, null, response.InnerException);
            }

            return (false, (int?)response.Result, null);
        }

        public async Task<(bool HasError, string? ErrorMessage)> UpdateOrderAsync(int orderId, UpdateOrderDto updateOrderDto)
        {
            DapperResponse response = await _orderRepository.UpdateAsync(orderId, updateOrderDto);

            if (!response.Success)
            {
                return (true, response.InnerException);
            }

            return (false, null);
        }

        public async Task<(bool HasError, string? ErrorMessage)> DeleteOrderAsync(int orderId)
        {
            DapperResponse response = await _orderRepository.DeleteAsync(orderId);

            if (!response.Success)
            {
                return (true, response.InnerException);
            }

            return (false, null);
        }
    }
}
