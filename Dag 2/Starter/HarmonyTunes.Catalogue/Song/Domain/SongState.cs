using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Domain.Events;
using HarmonyTunes.Catalogue.Song.Domain.ValueObjects;
using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Song.Domain;

public class SongState : AggregateState
{
    public AlbumReference AlbumId { get; private set; } = null!;
    public SongName Name { get; private set; } = null!;
    public SongDescription? Description { get; private set; }
    public Url? SongData { get; private set; }

    public override void Mutate(IDomainEvent evt)
    {
        switch (evt)
        {
            case SongCreated songCreated:
                When(songCreated);
                break;
            case SongRenamed songRenamed:
                When(songRenamed);
                break;
            case DescriptionChanged descriptionChanged:
                When(descriptionChanged);
                break;
            case SongDataChanged songDataChanged:
                When(songDataChanged);
                break;
            case SongMovedToAlbum songMovedToAlbum:
                When(songMovedToAlbum);
                break;
        }
    }

    public void When(SongCreated evt)
    {
        AlbumId = evt.AlbumId;
        Name = evt.Name;
    }

    public void When(SongRenamed evt)
    {
        Name = evt.Name;
    }

    public void When(DescriptionChanged evt)
    {
        Description = evt.Description;
    }

    public void When(SongDataChanged evt)
    {
        SongData = evt.SongData;
    }

    public void When(SongMovedToAlbum evt)
    {
        AlbumId = evt.AlbumId;
    }
}
