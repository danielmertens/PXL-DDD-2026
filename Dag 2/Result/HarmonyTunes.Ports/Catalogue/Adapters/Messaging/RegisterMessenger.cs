
using HarmonyTunes.Catalogue.Shared.Application.Interfaces;
using HarmonyTunes.Ports.Catalogue.Adapters.Database;
using HarmonyTunes.Ports.Catalogue.Adapters.Messaging.Consumers;
using MassTransit;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Messaging;

public class RegisterMessenger
{
    public static void Register(IServiceCollection services)
    {
        var queue = "HarmonyTunes.Catalogue.In";
        services.AddMassTransit(configure =>
        {
            configure.AddEntityFrameworkOutbox<CatalogueContext>(outbox =>
            {
                outbox.UsePostgres();
                outbox.UseBusOutbox();
                outbox.QueryDelay = TimeSpan.FromSeconds(1);
            });

            configure.AddConsumers(typeof(AlbumUpdatedNotificationHandler).Assembly);

            configure.UsingRabbitMq((context, rabbit) =>
            {
                rabbit.Host("localhost", "/", host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });

                rabbit.ReceiveEndpoint(queue, endpoint =>
                {
                    endpoint.UseMessageRetry(retry => retry.Interval(3, TimeSpan.FromMilliseconds(200)));
                    endpoint.ConfigureConsumers(context);
                });
            });
        });

        services.AddScoped<IMessagePublisher, MessagePublisher>();
    }
}
