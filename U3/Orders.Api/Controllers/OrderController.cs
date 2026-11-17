using Microsoft.AspNetCore.Mvc;
using Orders.Api.models.dtos;
using Orders.Api.Services;

namespace Orders.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders(
            [FromQuery] string? status = null,
            [FromQuery] int? customerId = null,
            [FromQuery] string? orderNumber = null)
        {
            var orders = await _orderService.GetAllOrdersAsync(status, customerId, orderNumber);
            return StatusCode(200, new { orders });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order is null)
            {
                return StatusCode(404, new { Message = $"No se encontró la orden con ID {id}." });
            }

            return StatusCode(200, new { order });
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            var (hasError, orderId, errorMessage) = await _orderService.CreateOrderAsync(createOrderDto);
            return hasError
                ? StatusCode(400, new { Message = errorMessage ?? "Ocurrió un error inesperado al crear la orden." })
                : StatusCode(201, new { OrderId = orderId });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrder(int id, UpdateOrderDto updateOrderDto)
        {
            var (hasError, errorMessage) = await _orderService.UpdateOrderAsync(id, updateOrderDto);
            return hasError
                ? StatusCode(400, new { Message = errorMessage ?? "Ocurrió un error inesperado al actualizar la orden." })
                : StatusCode(200, new { Message = "Orden actualizada correctamente." });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var (hasError, errorMessage) = await _orderService.DeleteOrderAsync(id);
            return hasError
                ? StatusCode(400, new { Message = errorMessage ?? "Ocurrió un error inesperado al eliminar la orden." })
                : StatusCode(200, new { Message = "Orden eliminada correctamente." });
        }
    }
}
