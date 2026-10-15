using HarmonyTunes.Catalogue.Shared.Application.Interfaces;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Application.Interfaces;
using HarmonyTunes.Catalogue.Song.Application.Notifications;
using HarmonyTunes.Catalogue.Song.Domain;
using HarmonyTunes.Catalogue.Song.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Application;

namespace HarmonyTunes.Catalogue.Song.Application;

public class SongService
    : ApplicationService<SongAggregate, SongState, SongReference>,
    ISongService
{
    private readonly IMessagePublisher _messagePublisher;

    public SongService(ISongRepository repository,
        IMessagePublisher messagePublisher)
        : base(repository)
    {
        _messagePublisher = messagePublisher;
    }

    public async Task<SongReference> Create(AlbumReference albumReference,
        SongName name)
    {
        var id = await Add(async agg => {
            agg.Create(albumReference, name);

            await _messagePublisher.Publish(new SongCreatedNotification
            {
                SongReference = agg.Id.Key,
                AlbumReference = albumReference.Key
            });
        });

        return id;
    }
}
