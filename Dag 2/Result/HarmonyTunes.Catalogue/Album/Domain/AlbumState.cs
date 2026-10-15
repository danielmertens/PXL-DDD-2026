using HarmonyTunes.Catalogue.Album.Domain.Events;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain;

public class AlbumState : AggregateState
{
    public AlbumName Name { get; private set; } = null!;
    public AlbumDescription? Description { get; private set; }
    public Url? BackgroundImageUrl { get; private set; }
    public Year? PublicationYear { get; private set; }
    public Counter Likes { get; private set; } = new Counter(0);
    public ArtistReference? Artist { get; private set; }

    public AlbumStatus Status { get; private set; } = AlbumStatus.Unknown;

    public void When(AlbumCreated evt)
    {
        Name = evt.AlbumName;
        Status = AlbumStatus.Unpublished;
    }

    public void When(DescriptionChanged evt)
    {
        Description = evt.Description;
    }

    public void When(BackgroundImageChanged evt)
    {
        BackgroundImageUrl = evt.BackgroundImageUrl;
    }

    public void When(PublicationYearChanged evt)
    {
        PublicationYear = evt.PublicationYear;
    }

    public void When(ArtistAssigned evt)
    {
        Artist = evt.Artist;
    }

    public void When(AlbumLiked evt)
    {
        Likes = Likes.Increment();
    }

    public void When(AlbumPublished evt)
    {
        Status = AlbumStatus.Published;
    }
}
