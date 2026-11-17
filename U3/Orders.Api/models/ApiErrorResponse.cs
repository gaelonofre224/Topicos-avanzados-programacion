using Microsoft.AspNetCore.Mvc.ModelBinding;
using Orders.Api.Models;

namespace Orders.Api.Models
{
    public sealed record ApiErrorResponse(
    int StatusCode,
    string Message,
    IReadOnlyList<FieldError> Errors);

public sealed record FieldError(string Field, IReadOnlyList<string> Messages);
}
