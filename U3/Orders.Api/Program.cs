using Microsoft.AspNetCore.Mvc;
using Orders.Api;
using Orders.Api.Helpers;
using Orders.Api.models.dtos;
using Orders.Api.Models;
using Orders.Api.Repositories;
using Orders.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<StudentInfo>(
    builder.Configuration.GetSection(StudentInfo.SectionName));

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IDapperService, DapperService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
            new BadRequestObjectResult(new ApiErrorResponse(
                StatusCodes.Status400BadRequest,
                "The request contains invalid data.1",
                ValidationErrors.FromModelState(context.ModelState)));
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.IncludeFields = true;
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Orders.Api");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
