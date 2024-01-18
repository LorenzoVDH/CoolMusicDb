using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Handlers;

public class GetArtistsByNameHandler : IRequestHandler<GetArtistsByNameQuery, List<Artist>>
{
    private readonly IArtistRepository _repository;

    public GetArtistsByNameHandler(IArtistRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Artist>> Handle(GetArtistsByNameQuery query, CancellationToken cancellationToken)
    {
        return await _repository.GetArtistsByNameAsync(query.SearchTerm);
    }
}
