using HarmonyTunes.Catalogue.Album.Application.Interfaces;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Album.Projection.Interfaces;
using HarmonyTunes.Catalogue.Album.Projection.Models;
using HarmonyTunes.Catalogue.Artist.Application.Interfaces;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Application.Interfaces;

namespace HarmonyTunes.Catalogue.Album.Projection;

public class AlbumProjectionService : IAlbumProjectionsService
{
    private readonly IAlbumQueryService _albumQueryService;
    private readonly ISongQueryService _songQueryService;
    private readonly IArtistRepository _artistRepository;
    private readonly IAlbumProjectionsRepository _projectionsRepository;

    public AlbumProjectionService(IAlbumQueryService albumQueryService,
        ISongQueryService songQueryService,
        IArtistRepository artistRepository,
        IAlbumProjectionsRepository projectionsRepository)
    {
        _albumQueryService = albumQueryService;
        _songQueryService = songQueryService;
        _artistRepository = artistRepository;
        _projectionsRepository = projectionsRepository;
    }

    public async Task OnAlbumUpdated(AlbumReference albumReference)
    {
        await Project(albumReference);
    }

    public async Task OnSongCreated(AlbumReference albumReference)
    {
        await Project(albumReference);
    }

    private async Task Project(AlbumReference albumReference)
    {
        var album = await _albumQueryService.GetById(albumReference.Key);

        if (album == null) return;
        if ((AlbumStatus)album.Status != AlbumStatus.Published) return;

        var songs = await _songQueryService.GetSongsByAlbum(albumReference.Key);
        var artistName = "Unknown";
        if (album.ArtistId != null)
        {
            var artist = await _artistRepository.Fetch(new ArtistReference(album.ArtistId.Value));
            artistName = artist.CurrentState.Identity.Stage.FirstName.Value;
        }

        var projection = new AlbumOverviewProjection
        {
            Id = albumReference.Key,
            AlbumName = album.Name,
            ArtistName = artistName,
            NumberOfSongs = songs.Count()
        };

        _projectionsRepository.AddOrUpdateProjection(projection);
        await _projectionsRepository.Commit();
    }
}
