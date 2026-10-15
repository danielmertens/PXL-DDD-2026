namespace HarmonyTunes.Catalogue.Shared.Application.Interfaces;

public interface IMessagePublisher
{
    Task Publish<T>(T notification)
        where T : INotification;
}
