using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Domain.Events;
using HarmonyTunes.Catalogue.Song.Domain.Exceptions;
using HarmonyTunes.Catalogue.Song.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Song.Domain;

public class SongAggregate : AggregateRoot<SongState, SongReference>
{
    public SongAggregate(SongReference id) : base(id)
    {
    }

    public SongAggregate(SongState currentState, SongReference id, int version) : base(currentState, id, version)
    {
    }

    public void Create(AlbumReference albumReference, SongName name)
    {
        RaiseEvent(new SongCreated
        {
            AlbumId = albumReference,
            Name = name
        });
    }

    public void Rename(SongName name)
    {
        EnsureCreated();

        RaiseEvent(new SongRenamed
        {
            Name = name
        });
    }

    public void ChangeDescription(SongDescription description)
    {
        EnsureCreated();

        RaiseEvent(new DescriptionChanged
        {
            Description = description
        });
    }

    public void ChangeSongData(Url songData)
    {
        EnsureCreated();

        RaiseEvent(new SongDataChanged
        {
            SongData = songData
        });
    }

    public void MoveToAlbum(AlbumReference albumReference)
    {
        EnsureCreated();

        RaiseEvent(new SongMovedToAlbum
        {
            AlbumId = albumReference
        });
    }

    private void EnsureCreated()
    {
        if (CurrentState.Name is null)
            throw new SongNotCreated();
    }
}
