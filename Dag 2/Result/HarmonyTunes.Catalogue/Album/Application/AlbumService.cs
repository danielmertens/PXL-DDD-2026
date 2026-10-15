using HarmonyTunes.Catalogue.Album.Application.Interfaces;
using HarmonyTunes.Catalogue.Album.Application.Notifications;
using HarmonyTunes.Catalogue.Album.Domain;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Application.Interfaces;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Application;

namespace HarmonyTunes.Catalogue.Album.Application;

public class AlbumService :
    ApplicationService<AlbumAggregate, AlbumState, AlbumReference>,
    IAlbumService
{
    private readonly IMessagePublisher _messagePublisher;

    public AlbumService(IAlbumRepository albumRepository,
        IMessagePublisher messagePublisher)
        : base(albumRepository)
    {
        _messagePublisher = messagePublisher;
    }

    public async Task<AlbumReference> CreateAlbum(AlbumName albumName)
    {
        var id = await Add(async agg => {
            agg.Create(albumName);

            await _messagePublisher.Publish(new AlbumUpdatedNotification
            {
                AlbumReference = agg.Id.Key
            }); 
        });

        return id;
    }

    public async Task PublishAlbum(AlbumReference albumReference)
    {
        await Update(albumReference, async agg => {
            agg.Publish();

            await _messagePublisher.Publish(new AlbumUpdatedNotification
            {
                AlbumReference = agg.Id.Key
            });
        });
    }

    public async Task ChangeDescription(AlbumReference albumReference, AlbumDescription description)
    {
        await Update(albumReference, async agg => {
            agg.ChangeDescription(description);

            await _messagePublisher.Publish(new AlbumUpdatedNotification
            {
                AlbumReference = agg.Id.Key
            });
        });
    }

    public async Task ChangeBackgroundImage(AlbumReference albumReference, Url backgroundImageUrl)
    {
        await Update(albumReference, async agg => {
            agg.ChangeBackgroundImage(backgroundImageUrl);

            await _messagePublisher.Publish(new AlbumUpdatedNotification
            {
                AlbumReference = agg.Id.Key
            });
        });
    }

    public async Task ChangePublicationYear(AlbumReference albumReference, Year publicationYear)
    {
        await Update(albumReference, async agg => {
            agg.ChangePublicationYear(publicationYear);

            await _messagePublisher.Publish(new AlbumUpdatedNotification
            {
                AlbumReference = agg.Id.Key
            });
        });
    }

    public async Task AssignArtist(AlbumReference albumReference, ArtistReference artist)
    {
        await Update(albumReference, async agg => {
            agg.AssignArtist(artist);

            await _messagePublisher.Publish(new AlbumUpdatedNotification
            {
                AlbumReference = agg.Id.Key
            });
        });
    }

    public async Task LikeAlbum(AlbumReference albumReference)
    {
        await Update(albumReference, async agg => {
            agg.Like();

            await _messagePublisher.Publish(new AlbumUpdatedNotification
            {
                AlbumReference = agg.Id.Key
            });
        });
    }
}
