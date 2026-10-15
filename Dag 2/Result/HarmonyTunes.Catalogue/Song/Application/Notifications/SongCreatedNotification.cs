using HarmonyTunes.Catalogue.Shared.Application.Interfaces;

namespace HarmonyTunes.Catalogue.Song.Application.Notifications;

public class SongCreatedNotification : INotification
{
    public Guid SongReference { get; set; }
    public Guid AlbumReference { get; set; }
}
