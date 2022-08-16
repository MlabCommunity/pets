using System.Text.Json.Serialization;
using Lapka.Pet.Api.Grpc;
using Lapka.Pet.Application;
using Lapka.Pet.Infrastructure;
using Lapka.Pet.Infrastructure.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters
        .Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddSwaggerGen();
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddGrpc();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

app.MapGrpcService<ShelterGrpcController>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();