using HarmonyTunes.Ports.Catalogue.Adapters.Database.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Artist;

public class ArtistConfiguration : IEntityTypeConfiguration<AggregateEntity>
{
    public void Configure(EntityTypeBuilder<AggregateEntity> builder)
    {
        builder.HasKey(a => a.AggregateId);
        builder.Property(a => a.RowVersion)
            .IsRowVersion();
    }
}
