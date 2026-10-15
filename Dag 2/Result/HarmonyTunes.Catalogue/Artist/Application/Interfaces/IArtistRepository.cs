using HarmonyTunes.Catalogue.Artist.Domain;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Application;

namespace HarmonyTunes.Catalogue.Artist.Application.Interfaces;

public interface IArtistRepository : IRepository<ArtistAggregate, ArtistState, ArtistReference>
{
}