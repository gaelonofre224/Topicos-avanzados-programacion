namespace Orders.Api.models.dtos
{
public sealed class StudentInfo
{
    public const string SectionName = "Student";
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
}