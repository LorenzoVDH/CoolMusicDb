using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Handlers;

public class GetArtistByIdHandler : IRequestHandler<GetArtistByIdQuery, Artist?>
{
    private readonly IArtistRepository _artistRepository;
    public GetArtistByIdHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<Artist?> Handle(GetArtistByIdQuery query, CancellationToken cancellationToken)
    {
        return await _artistRepository.GetArtistByIdAsync(query.ArtistId);
    }
}
