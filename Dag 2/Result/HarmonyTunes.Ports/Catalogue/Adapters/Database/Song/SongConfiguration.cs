using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Domain;
using HarmonyTunes.Catalogue.Song.Domain.ValueObjects;
using HarmonyTunes.Ports.Catalogue.Adapters.Database.Album;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Song;

public class SongConfiguration : IEntityTypeConfiguration<SongState>
{
    public void Configure(EntityTypeBuilder<SongState> builder)
    {
        builder.Property<Guid>(SongRepository.DbKeyColumn).ValueGeneratedNever();
        builder.HasKey(SongRepository.DbKeyColumn);
        builder.Property<int>(SongRepository.VersionColumn).IsConcurrencyToken();

        builder.Property(p => p.Name)
            .HasConversion(new SongNameConversion());

        // EF Core never passes null to a converter, so a converter for the non-nullable type is safe here.
        builder.Property(p => p.Description)
            .HasConversion(new SongDescriptionConversion()!);

        builder.Property(p => p.SongData)
            .HasConversion(new UrlConversion()!);

        builder.Property(p => p.AlbumId)
            .HasConversion(new AlbumReferenceConversion());
    }
}

internal class AlbumReferenceConversion : ValueConverter<AlbumReference, Guid>
{
    public AlbumReferenceConversion(ConverterMappingHints? mappingHints = null)
        : base((reference) => reference.Key, (key) => new AlbumReference(key), mappingHints)
    {
    }
}

internal class SongNameConversion : ValueConverter<SongName, string>
{
    public SongNameConversion(ConverterMappingHints? mappingHints = null)
        : base((name) => name.Value, (text) => new SongName(text), mappingHints)
    {
    }
}

internal class SongDescriptionConversion : ValueConverter<SongDescription, string>
{
    public SongDescriptionConversion(ConverterMappingHints? mappingHints = null)
        : base((desc) => desc.Value, (text) => new SongDescription(text), mappingHints)
    {
    }
}
