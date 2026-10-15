using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Domain;
using HarmonyTunes.Domain.Core.Application;

namespace HarmonyTunes.Catalogue.Song.Application.Interfaces;

public interface ISongRepository :
    IRepository<SongAggregate, SongState, SongReference>
{
}
