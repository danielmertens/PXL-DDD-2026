using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;

namespace HarmonyTunes.Catalogue.Album.Application.Interfaces;

public interface IAlbumService
{
    Task<AlbumReference> CreateAlbum(AlbumName albumName);
    Task PublishAlbum(AlbumReference albumReference);
    Task ChangeDescription(AlbumReference albumReference, AlbumDescription description);
    Task ChangeBackgroundImage(AlbumReference albumReference, Url backgroundImageUrl);
    Task ChangePublicationYear(AlbumReference albumReference, Year publicationYear);
    Task AssignArtist(AlbumReference albumReference, ArtistReference artist);
    Task LikeAlbum(AlbumReference albumReference);
}