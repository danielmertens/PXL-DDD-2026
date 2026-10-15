using HarmonyTunes.Catalogue.Album.Application.Interfaces;
using HarmonyTunes.Catalogue.Album.Application.Notifications;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Album.Projection.Interfaces;
using HarmonyTunes.Catalogue.Shared.Application.Interfaces;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Ports.Catalogue.Adapters.Database;
using HarmonyTunes.Ports.Catalogue.Models;

namespace HarmonyTunes.Ports.Catalogue.Adapters.WebApi;

public static class AlbumController
{
    public static void RegisterControllers(WebApplication app)
    {
        app.MapPost("/api/test/{albumReference:guid}", async (Guid albumReference, IMessagePublisher messagePublisher,
            CatalogueContext context) =>
        {
            await messagePublisher.Publish(new AlbumUpdatedNotification
            {
                AlbumReference = albumReference
            });

            await context.SaveChangesAsync();
        });

        app.MapPost("/api/albums/create", async (CreateAlbumDto dto, IAlbumService albumService) =>
        {
            var albumId = await albumService.CreateAlbum(new AlbumName(dto.Name));
            return new AlbumCreatedDto { AlbumReference = albumId.Key };
        });

        app.MapPost("/api/albums/change-description/{albumReference:guid}", async (Guid albumReference, ChangeAlbumDescriptionDto dto, IAlbumService albumService) =>
        {
            await albumService.ChangeDescription(
                new AlbumReference(albumReference),
                new AlbumDescription(dto.Description));
        });

        app.MapPost("/api/albums/change-background-image/{albumReference:guid}", async (Guid albumReference, ChangeAlbumBackgroundImageDto dto, IAlbumService albumService) =>
        {
            await albumService.ChangeBackgroundImage(
                new AlbumReference(albumReference),
                new Url(dto.BackgroundImageUrl));
        });

        app.MapPost("/api/albums/change-publication-year/{albumReference:guid}", async (Guid albumReference, ChangeAlbumPublicationYearDto dto, IAlbumService albumService) =>
        {
            await albumService.ChangePublicationYear(
                new AlbumReference(albumReference),
                new Year(dto.Year));
        });

        app.MapPost("/api/albums/assign-artist/{albumReference:guid}", async (Guid albumReference, AssignAlbumArtistDto dto, IAlbumService albumService) =>
        {
            await albumService.AssignArtist(
                new AlbumReference(albumReference),
                new ArtistReference(dto.ArtistReference));
        });

        app.MapPost("/api/albums/like/{albumReference:guid}", async (Guid albumReference, IAlbumService albumService) =>
        {
            await albumService.LikeAlbum(new AlbumReference(albumReference));
        });

        app.MapPost("/api/albums/publish/{albumReference:guid}", async (Guid albumReference, IAlbumService albumService) =>
        {
            await albumService.PublishAlbum(new AlbumReference(albumReference));
        });

        app.MapGet("/api/albums", async (IAlbumQueryService queryService) =>
        {
            return (await queryService.GetAll()).ToArray();
        });

        app.MapGet("/api/albums/overview", async (IAlbumProjectionsRepository projectionsRepository) =>
        {
            return (await projectionsRepository.GetAll()).ToArray();
        });

        app.MapGet("/api/albums/{albumReference:guid}", async (Guid albumReference, IAlbumQueryService queryService) =>
        {
            return await queryService.GetById(albumReference);
        });
    }
}
