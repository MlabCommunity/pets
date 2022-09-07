using System.Text.Json.Serialization;
using Lapka.Pet.Api.Grpc;
using Lapka.Pet.Application;
using Lapka.Pet.Infrastructure;
using Lapka.Pet.Infrastructure.gRPC;
using Lapka.Pet.Infrastructure.Jwt;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true)
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddSwaggerGen();
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddGrpc();
builder.Services.AddGrpcServices(builder.Configuration);

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

app.MapGrpcService<ShelterGrpcController>();


//if (app.Environment.IsDevelopment())


app.UseSwagger(c =>
{
    c.PreSerializeFilters.Add((swaggerDoc, httpRequest) =>
    {
        if (!httpRequest.Headers.ContainsKey("X-Forwarded-Host"))
            return;

        var basePath = "pet";
        var serverUrl = $"{httpRequest.Scheme}://{httpRequest.Headers["X-Forwarded-Host"]}/{basePath}";
        swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = serverUrl } };
    });
});
app.UseSwaggerUI();

app.UseMiddleware();

app.UseAuthentication();

app.UseAuthorization();

app.MapGet("/", ctx => ctx.Response.WriteAsync($"Lapka.Pet API {DateTime.Now}"));
app.MapControllers();

app.Run();
