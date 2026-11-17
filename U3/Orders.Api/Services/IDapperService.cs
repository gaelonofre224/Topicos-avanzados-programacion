using Dapper;
using Orders.Api.models;

namespace Orders.Api.Services
{
    public interface IDapperService
    {
        Task<DapperResponse> ExecuteQueryAsync<T>(string query, StoredProcedureInf parameters, string connectionId, bool hasArray = false);
        Task<DapperResponse> ExecuteStoredProcedureAsync<T>(StoredProcedureInf qData, DynamicParameters parameters, bool hasArray = false);
    }
}
