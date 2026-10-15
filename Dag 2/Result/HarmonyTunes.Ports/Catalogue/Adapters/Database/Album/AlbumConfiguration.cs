using HarmonyTunes.Catalogue.Album.Domain;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Album;

public class AlbumConfiguration : IEntityTypeConfiguration<AlbumState>
{
    public void Configure(EntityTypeBuilder<AlbumState> builder)
    {
        builder.Property<Guid>(AlbumRepository.DbKeyColumn).ValueGeneratedNever();
        builder.HasKey(AlbumRepository.DbKeyColumn);
        builder.Property<int>(AlbumRepository.VersionColumn).IsConcurrencyToken();

        builder.Property(p => p.Name)
            .HasConversion(new AlbumNameConversion());

        // EF Core never passes null to a converter, so a converter for the non-nullable type is safe here.
        builder.Property(p => p.Description)
            .HasConversion(new AlbumDescriptionConversion()!);

        builder.Property(p => p.BackgroundImageUrl)
            .HasConversion(new UrlConversion()!);

        builder.Property(p => p.PublicationYear)
            .HasConversion(new YearConversion()!);

        builder.Property(p => p.Likes)
            .HasConversion(new CounterConversion());

        builder.Property(p => p.Status)
            .HasConversion(new EnumConverter());

        builder.Property(p => p.Artist)
            .HasConversion(new ArtistReferenceConversion()!);
    }
}

internal class ArtistReferenceConversion : ValueConverter<ArtistReference, Guid>
{
    public ArtistReferenceConversion(ConverterMappingHints? mappingHints = null)
        : base((reference) => reference.Key, (key) => new ArtistReference(key), mappingHints)
    {
    }
}

internal class EnumConverter : ValueConverter<AlbumStatus, int>
{
    public EnumConverter(ConverterMappingHints? mappingHints = null)
        : base((status) => (int)status, (statusValue) => (AlbumStatus)statusValue, mappingHints)
    {
    }
}

internal class AlbumNameConversion : ValueConverter<AlbumName, string>
{
    public AlbumNameConversion(ConverterMappingHints? mappingHints = null)
        : base((name) => name.Value, (text) => new AlbumName(text), mappingHints)
    {
    }
}

internal class AlbumDescriptionConversion : ValueConverter<AlbumDescription, string>
{
    public AlbumDescriptionConversion(ConverterMappingHints? mappingHints = null)
        : base((desc) => desc.Value, (text) => new AlbumDescription(text), mappingHints)
    {
    }
}

internal class UrlConversion : ValueConverter<Url, string>
{
    public UrlConversion(ConverterMappingHints? mappingHints = null)
        : base((url) => url.Value, (text) => new Url(text), mappingHints)
    {
    }
}

internal class YearConversion : ValueConverter<Year, int>
{
    public YearConversion(ConverterMappingHints? mappingHints = null)
        : base((year) => year.Value, (number) => new Year(number), mappingHints)
    {
    }
}

internal class CounterConversion : ValueConverter<Counter, long>
{
    public CounterConversion(ConverterMappingHints? mappingHints = null)
        : base((counter) => counter.Value, (number) => new Counter(number), mappingHints)
    {
    }
}
