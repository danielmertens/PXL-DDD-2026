using HarmonyTunes.Catalogue.Album.Domain.Events;
using HarmonyTunes.Catalogue.Album.Domain.Exceptions;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain;

public class AlbumAggregate : AggregateRoot<AlbumState, AlbumReference>
{
    public AlbumAggregate(AlbumReference id) : base(id)
    {
    }

    public AlbumAggregate(AlbumState currentState, AlbumReference id, int version) : base(currentState, id, version)
    {
    }

    public void Create(AlbumName albumName)
    {
        if (CurrentState.Status != AlbumStatus.Unknown)
            throw new AlbumAlreadyCreated();

        RaiseEvent(new AlbumCreated
        {
            AlbumName = albumName
        });
    }

    public void ChangeDescription(AlbumDescription description)
    {
        EnsureCreated();

        RaiseEvent(new DescriptionChanged
        {
            Description = description
        });
    }

    public void ChangeBackgroundImage(Url backgroundImageUrl)
    {
        EnsureCreated();

        RaiseEvent(new BackgroundImageChanged
        {
            BackgroundImageUrl = backgroundImageUrl
        });
    }

    public void ChangePublicationYear(Year publicationYear)
    {
        EnsureCreated();

        RaiseEvent(new PublicationYearChanged
        {
            PublicationYear = publicationYear
        });
    }

    public void AssignArtist(ArtistReference artist)
    {
        EnsureCreated();

        RaiseEvent(new ArtistAssigned
        {
            Artist = artist
        });
    }

    public void Like()
    {
        EnsureCreated();

        RaiseEvent(new AlbumLiked
        {
            TimeStamp = new TimeStamp(DateTime.Now)
        });
    }

    public void Publish()
    {
        EnsureCreated();

        RaiseEvent(new AlbumPublished());
    }

    private void EnsureCreated()
    {
        if (CurrentState.Status == AlbumStatus.Unknown)
            throw new AlbumNotCreated();
    }
}
