using Consumidor;
using Consumidor.Evento;
using Core.Interface.Services;
using Core.Interface;
using Core.Services;
using MassTransit;
using Infraestrutura.Repositories;
using Infraestrutura.Context;
using IoC;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;

        var conexao = configuration.GetSection("MassTransitAzure")["Conexao"] ?? string.Empty;
        var fila = configuration.GetSection("MassTransitAzure")["NomeFila"] ?? string.Empty;

        services.AddHostedService<Worker>();
        services.AddSingleton<HttpClient>();

        services.AddMassTransit(x =>
        {
            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host(conexao);

                cfg.ReceiveEndpoint(fila, e =>
                {
                    e.ConfigureConsumer<ProvaConsumidor>(context);
                });

                cfg.ConfigureEndpoints(context);

            });

            x.AddConsumer<ProvaConsumidor>();
        });
    })
    .Build();

host.Run();
