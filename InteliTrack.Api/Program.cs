using InteliTrack.Application.DependencyInjection;
using InteliTrack.Infrastructure.DependencyInjection;
using InteliTrack.API.Endpoints;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


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


app.UseHttpsRedirection();


app.MapGet("/", () =>
{
    return "InteliTrack API running";
});

app.MapTransferEndpoints();
app.MapStockEndpoints();

app.Run();