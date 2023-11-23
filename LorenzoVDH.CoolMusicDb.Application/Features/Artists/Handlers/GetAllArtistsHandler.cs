using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Handlers
{
    public class GetAllArtistsHandler : IRequestHandler<GetAllArtistsQuery, List<Artist>>
    {
        private readonly IArtistRepository _artistRepository; 
        public GetAllArtistsHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<List<Artist>> Handle(GetAllArtistsQuery query, CancellationToken cancellationToken)
        {
            return await _artistRepository.GetAllArtistsAsync(); 
        }
    }
}
