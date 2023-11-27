using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;

public class UpdateAlbumCommand : IRequest<Album>
{
    public Album Album { get; }
    public UpdateAlbumCommand(Album album)
    {
        Album = album;
    }
}
