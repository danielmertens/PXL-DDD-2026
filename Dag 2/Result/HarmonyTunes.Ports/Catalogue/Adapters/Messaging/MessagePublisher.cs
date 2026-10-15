using HarmonyTunes.Catalogue.Shared.Application.Interfaces;
using MassTransit;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Messaging;

public class MessagePublisher : IMessagePublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MessagePublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Publish<T>(T notification)
        where T : INotification
    {
        await _publishEndpoint.Publish(notification, notification.GetType());
    }
}
