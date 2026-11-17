namespace Orders.Api.models
{
    public class DapperResponse
    {
        public bool Success { get; set; }
        public dynamic? Result { get; set; }
        public string? InnerException { get; set; }
    }
}
