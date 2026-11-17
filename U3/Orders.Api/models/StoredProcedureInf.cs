namespace Orders.Api.models
{
    public class StoredProcedureInf
    {
        public string IdConnectionString { get; set; } = string.Empty;
        public string SchemaName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
