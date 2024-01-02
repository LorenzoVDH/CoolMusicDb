using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Queries;

public class GetArtistByIdQuery : IRequest<Artist?>
{
    public int ArtistId { get; set; }

    public GetArtistByIdQuery(int artistId)
    {
        ArtistId = artistId;
    }
}
