using InteliTrack.Application.DependencyInjection;
using InteliTrack.Infrastructure.DependencyInjection;
using InteliTrack.API.Endpoints;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using InteliTrack.API.Middleware;
using InteliTrack.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddInfrastructure(
    builder.Configuration
);

builder.Services.AddApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseGlobalExceptionMiddleware();

app.MapProductEndpoints();
app.MapCategoryEndpoints();
app.MapSupplierEndpoints();
app.MapStoreEndpoints();
app.MapSectionEndpoints();
app.MapShelfEndpoints();
app.MapEmployeeEndpoints();
app.MapTransferEndpoints();
app.MapStockEndpoints();

app.MapGet("/", () =>
{
    return "InteliTrack API running";
});

app.Run();