using HarmonyTunes.Catalogue.Album.Projection.Interfaces;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Application.Notifications;
using MassTransit;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Messaging.Consumers;

public class SongCreatedNotificationHandler
    : IConsumer<SongCreatedNotification>
{
    private readonly IAlbumProjectionsService _albumProjectionsService;

    public SongCreatedNotificationHandler(IAlbumProjectionsService albumProjectionsService)
    {
        _albumProjectionsService = albumProjectionsService;
    }

    public async Task Consume(ConsumeContext<SongCreatedNotification> context)
    {
        await _albumProjectionsService.OnSongCreated(new AlbumReference(context.Message.AlbumReference));
    }
}
