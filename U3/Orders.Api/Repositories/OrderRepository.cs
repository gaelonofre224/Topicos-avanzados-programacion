using System.Data;
using Dapper;
using Orders.Api.models;
using Orders.Api.models.dtos;
using Orders.Api.Services;

namespace Orders.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDapperService _dapperService;
        private const string ConnectionId = "DefaultConnection";

        public OrderRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<DapperResponse> GetAllAsync(string? status = null, int? customerId = null, string? orderNumber = null)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_TransportOrders_GetAll"
            };

            var parameters = new DynamicParameters();
            parameters.Add("@Status", status);
            parameters.Add("@CustomerId", customerId);
            parameters.Add("@OrderNumber", orderNumber);

            return await _dapperService.ExecuteStoredProcedureAsync<Order>(
                procedure,
                parameters,
                hasArray: true);
        }

        public async Task<DapperResponse> GetByIdAsync(int orderId)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_TransportOrders_GetById"
            };

            var parameters = new DynamicParameters();
            parameters.Add("@OrderId", orderId);

            return await _dapperService.ExecuteStoredProcedureAsync<Order>(
                procedure,
                parameters,
                hasArray: false);
        }

        public async Task<DapperResponse> CreateAsync(CreateOrderDto createOrderDto)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_TransportOrders_Create"
            };

            var parameters = new DynamicParameters();
            parameters.Add("@OrderNumber", createOrderDto.OrderNumber);
            parameters.Add("@CustomerId", createOrderDto.CustomerId);
            parameters.Add("@VehicleId", createOrderDto.VehicleId);
            parameters.Add("@OriginCity", createOrderDto.OriginCity);
            parameters.Add("@DestinationCity", createOrderDto.DestinationCity);
            parameters.Add("@CargoDescription", createOrderDto.CargoDescription);
            parameters.Add("@WeightKg", createOrderDto.WeightKg);
            parameters.Add("@FreightAmount", createOrderDto.FreightAmount);
            parameters.Add("@CurrencyCode", createOrderDto.CurrencyCode);
            parameters.Add("@Status", createOrderDto.Status);
            parameters.Add("@PickupDate", createOrderDto.PickupDate.Date, DbType.Date);
            parameters.Add("@DeliveryDate", createOrderDto.DeliveryDate?.Date, DbType.Date);
            parameters.Add("@Notes", createOrderDto.Notes);
            parameters.Add("@OrderId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var response = await _dapperService.ExecuteStoredProcedureAsync<dynamic>(
                procedure,
                parameters,
                hasArray: false);

            if (response.Success)
            {
                response.Result = parameters.Get<int>("@OrderId");
            }

            return response;
        }

        public async Task<DapperResponse> UpdateAsync(int orderId, UpdateOrderDto updateOrderDto)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_TransportOrders_Update"
            };

            var parameters = new DynamicParameters();
            parameters.Add("@OrderId", orderId);
            parameters.Add("@OrderNumber", updateOrderDto.OrderNumber);
            parameters.Add("@CustomerId", updateOrderDto.CustomerId);
            parameters.Add("@VehicleId", updateOrderDto.VehicleId);
            parameters.Add("@OriginCity", updateOrderDto.OriginCity);
            parameters.Add("@DestinationCity", updateOrderDto.DestinationCity);
            parameters.Add("@CargoDescription", updateOrderDto.CargoDescription);
            parameters.Add("@WeightKg", updateOrderDto.WeightKg);
            parameters.Add("@FreightAmount", updateOrderDto.FreightAmount);
            parameters.Add("@CurrencyCode", updateOrderDto.CurrencyCode);
            parameters.Add("@Status", updateOrderDto.Status);
            parameters.Add("@PickupDate", updateOrderDto.PickupDate.Date, DbType.Date);
            parameters.Add("@DeliveryDate", updateOrderDto.DeliveryDate?.Date, DbType.Date);
            parameters.Add("@Notes", updateOrderDto.Notes);

            return await _dapperService.ExecuteStoredProcedureAsync<dynamic>(
                procedure,
                parameters,
                hasArray: false);
        }

        public async Task<DapperResponse> DeleteAsync(int orderId)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_TransportOrders_Delete"
            };

            var parameters = new DynamicParameters();
            parameters.Add("@OrderId", orderId);

            return await _dapperService.ExecuteStoredProcedureAsync<dynamic>(
                procedure,
                parameters,
                hasArray: false);
        }
    }
}
