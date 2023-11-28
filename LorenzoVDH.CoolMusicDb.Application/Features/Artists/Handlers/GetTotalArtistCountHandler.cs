using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Handlers;

public class GetTotalArtistCountHandler : IRequestHandler<GetTotalArtistCountQuery, int>
{
    private readonly IArtistRepository _artistRepository;
    public GetTotalArtistCountHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }
    public async Task<int> Handle(GetTotalArtistCountQuery query, CancellationToken cancellationToken)
    {
        return await _artistRepository.GetTotalArtistCountAsync();
    }
}
