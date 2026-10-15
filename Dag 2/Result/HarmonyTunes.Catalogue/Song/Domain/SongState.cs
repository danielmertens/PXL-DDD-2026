using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Domain.Events;
using HarmonyTunes.Catalogue.Song.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Song.Domain;

public class SongState : AggregateState
{
    public AlbumReference AlbumId { get; private set; } = null!;
    public SongName Name { get; private set; } = null!;
    public SongDescription? Description { get; private set; }
    public Url? SongData { get; private set; }

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
