using HarmonyTunes.Catalogue.Album.Application;
using HarmonyTunes.Catalogue.Album.Application.Interfaces;
using HarmonyTunes.Catalogue.Album.Projection;
using HarmonyTunes.Catalogue.Album.Projection.Interfaces;
using HarmonyTunes.Catalogue.Artist.Application;
using HarmonyTunes.Catalogue.Artist.Application.Interfaces;
using HarmonyTunes.Catalogue.Song.Application;
using HarmonyTunes.Catalogue.Song.Application.Interfaces;
using HarmonyTunes.Ports.Catalogue.Adapters.Database;
using HarmonyTunes.Ports.Catalogue.Adapters.Database.Album;
using HarmonyTunes.Ports.Catalogue.Adapters.Database.Artist;
using HarmonyTunes.Ports.Catalogue.Adapters.Database.Song;
using HarmonyTunes.Ports.Catalogue.Adapters.Messaging;
using HarmonyTunes.Ports.Catalogue.Adapters.WebApi;

namespace HarmonyTunes.Ports.Catalogue;

public static class RegisterCatalogue
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IAlbumService, AlbumService>();
        services.AddScoped<IAlbumRepository, AlbumRepository>();
        services.AddScoped<IAlbumQueryService, AlbumQueryService>();
        services.AddScoped<IAlbumProjectionsService, AlbumProjectionService>();
        services.AddScoped<IAlbumProjectionsRepository, AlbumProjectionsRepository>();

        services.AddScoped<ISongService, SongService>();
        services.AddScoped<ISongRepository, SongRepository>();
        services.AddScoped<ISongQueryService, SongQueryService>();

        services.AddScoped<IArtistService, ArtistService>();
        services.AddScoped<IArtistRepository, ArtistRepository>();

        services.AddDbContext<CatalogueContext>();

        RegisterMessenger.Register(services);
    }

    public static void RegisterControllers(WebApplication app)
    {
        AlbumController.RegisterControllers(app);
        SongController.RegisterControllers(app);
        ArtistController.RegisterControllers(app);
    }
}
