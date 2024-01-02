using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;

public class DeleteAlbumCommand : IRequest
{
    public int AlbumId { get; }
    public DeleteAlbumCommand(int albumId)
    {
        AlbumId = albumId;
    }
}
