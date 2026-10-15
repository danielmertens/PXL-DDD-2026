using HarmonyTunes.Catalogue.Album.Application;
using HarmonyTunes.Catalogue.Album.Application.Interfaces;
using HarmonyTunes.Ports;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAlbumService, AlbumService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/albums/create", async (CreateAlbumDto dto) =>
{
    // Create an album

    return Guid.NewGuid();
});

app.MapPost("/api/albums/change-description/{albumReference:guid}", async (Guid albumReference, ChangeAlbumDescriptionDto dto) =>
{
    // Change the description of an existing album
});

app.Run();
