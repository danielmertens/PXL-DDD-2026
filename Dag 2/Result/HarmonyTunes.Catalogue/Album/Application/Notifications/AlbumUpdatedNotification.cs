using HarmonyTunes.Catalogue.Shared.Application.Interfaces;

namespace HarmonyTunes.Catalogue.Album.Application.Notifications;

public class AlbumUpdatedNotification : INotification
{
    public Guid AlbumReference { get; set; }
}
