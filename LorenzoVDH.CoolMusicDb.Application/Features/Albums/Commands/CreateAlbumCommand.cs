using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;

public class CreateAlbumCommand : IRequest<Album>
{
    public Album Album { get; }
    public CreateAlbumCommand(Album album)
    {
        Album = album;
    }
}
