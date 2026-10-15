using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalogue");

            migrationBuilder.CreateTable(
                name: "AlbumOverviewProjection",
                schema: "Catalogue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlbumName = table.Column<string>(type: "text", nullable: false),
                    ArtistName = table.Column<string>(type: "text", nullable: false),
                    NumberOfSongs = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumOverviewProjection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                schema: "Catalogue",
                columns: table => new
                {
                    AlbumId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BackgroundImageUrl = table.Column<string>(type: "text", nullable: true),
                    PublicationYear = table.Column<int>(type: "integer", nullable: true),
                    Likes = table.Column<long>(type: "bigint", nullable: false),
                    Artist = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "ArtistAggregate",
                schema: "Catalogue",
                columns: table => new
                {
                    AggregateId = table.Column<string>(type: "text", nullable: false),
                    CurrentVersion = table.Column<int>(type: "integer", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistAggregate", x => x.AggregateId);
                });

            migrationBuilder.CreateTable(
                name: "ArtistEventStore",
                schema: "Catalogue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AggregateId = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MessageType = table.Column<string>(type: "text", nullable: false),
                    EventData = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistEventStore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                schema: "Catalogue",
                columns: table => new
                {
                    SongId = table.Column<Guid>(type: "uuid", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SongData = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumOverviewProjection",
                schema: "Catalogue");

            migrationBuilder.DropTable(
                name: "Albums",
                schema: "Catalogue");

            migrationBuilder.DropTable(
                name: "ArtistAggregate",
                schema: "Catalogue");

            migrationBuilder.DropTable(
                name: "ArtistEventStore",
                schema: "Catalogue");

            migrationBuilder.DropTable(
                name: "Songs",
                schema: "Catalogue");
        }
    }
}
