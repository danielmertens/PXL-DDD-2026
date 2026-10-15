using HarmonyTunes.Catalogue.Album.Domain;
using HarmonyTunes.Catalogue.Album.Projection.Models;
using HarmonyTunes.Catalogue.Song.Domain;
using HarmonyTunes.Ports.Catalogue.Adapters.Database.Album;
using HarmonyTunes.Ports.Catalogue.Adapters.Database.Artist;
using HarmonyTunes.Ports.Catalogue.Adapters.Database.Shared;
using HarmonyTunes.Ports.Catalogue.Adapters.Database.Song;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database;

public class CatalogueContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<AlbumState> Albums { get; set; }
    public DbSet<SongState> Songs { get; set; }

    public DbSet<AggregateEntity> ArtistAggregate { get; set; }
    public DbSet<EventEntity> ArtistEventStore { get; set; }

    public DbSet<AlbumOverviewProjection> AlbumOverviewProjection { get; set; }

    public CatalogueContext(DbContextOptions options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Catalogue");
        modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        modelBuilder.ApplyConfiguration(new SongConfiguration());
        modelBuilder.ApplyConfiguration(new ArtistConfiguration());

        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("default"));
        base.OnConfiguring(optionsBuilder);
    }
}
