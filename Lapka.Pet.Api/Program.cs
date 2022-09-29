using System.Reflection;
using System.Text.Json.Serialization;
using Convey;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using FluentValidation;
using FluentValidation.AspNetCore;
using Lapka.Pet.Api.Grpc;
using Lapka.Pet.Api.Requests;
using Lapka.Pet.Application;
using Lapka.Pet.Application.IntegrationEvents;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Infrastructure;
using Lapka.Pet.Infrastructure.gRPC;
using Lapka.Pet.Infrastructure.Jwt;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true)
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .AddFluentValidation(opt =>
    {
        opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddSwaggerGen();
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddGrpc();
builder.Services.AddGrpcServices(builder.Configuration);

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

app.MapGrpcService<ShelterGrpcController>();

app.UseConvey();
app.UseRabbitMq()
    .SubscribeEvent<UserDeletedEvent>()
    .SubscribeEvent<UserUpdatedEvent>();

app.UseSwaggerDocs();

app.UseMiddleware();

app.UseAuthentication();

app.UseAuthorization();

app.MapGet("/", ctx => ctx.Response.WriteAsync($"Lapka.Pet API {DateTime.Now}"));

app.MapControllers();

app.Run();