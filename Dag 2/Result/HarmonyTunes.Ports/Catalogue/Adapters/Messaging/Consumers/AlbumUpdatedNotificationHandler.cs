using HarmonyTunes.Catalogue.Album.Application.Notifications;
using HarmonyTunes.Catalogue.Album.Projection.Interfaces;
using HarmonyTunes.Catalogue.Shared.Domain;
using MassTransit;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Messaging.Consumers;

public class AlbumUpdatedNotificationHandler
    : IConsumer<AlbumUpdatedNotification>
{
    private readonly IAlbumProjectionsService _albumProjectionsService;

    public AlbumUpdatedNotificationHandler(IAlbumProjectionsService albumProjectionsService)
    {
        _albumProjectionsService = albumProjectionsService;
    }

    public async Task Consume(ConsumeContext<AlbumUpdatedNotification> context)
    {
        await _albumProjectionsService.OnAlbumUpdated(new AlbumReference(context.Message.AlbumReference));
    }
}
