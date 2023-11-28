using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Queries;

public class GetAlbumByIdQuery : IRequest<Album>
{
    public int AlbumId { get; }
    public GetAlbumByIdQuery(int albumId)
    {
        AlbumId = albumId;
    }
}
