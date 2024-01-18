using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Queries;

public class GetArtistsByNameQuery : IRequest<List<Artist>>
{
    public string SearchTerm { get; }

    public GetArtistsByNameQuery(string searchTerm)
    {
        SearchTerm = searchTerm;
    }
}
