using Infraestrutura.Context;
using IoC;
using MassTransit;
using VestibularApi.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VestibularContext>(ServiceLifetime.Scoped);
NativeInjector.RegisterServices(builder.Services);
builder.Services.AddAutoMapper(typeof(AutoMapperSetup));

var configuration = builder.Configuration;
var conexao = configuration.GetSection("MassTransitAzure")["Conexao"] ?? string.Empty;
var fila = configuration.GetSection("MassTransit")["Fila"] ?? string.Empty;

builder.Services.AddMassTransit((x =>
{
    x.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.Host(conexao);
    });
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
