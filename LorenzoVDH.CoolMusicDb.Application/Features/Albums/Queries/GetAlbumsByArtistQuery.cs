using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Queries;

public class GetAlbumsByArtistQuery : IRequest<List<Album>>
{
    public int ArtistId { get; }

    public GetAlbumsByArtistQuery(int artistId)
    {
        ArtistId = artistId;
    }
}
