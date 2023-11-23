using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Queries
{
    public class GetAllArtistsQuery : IRequest<List<Artist>>
    {
    }
}
