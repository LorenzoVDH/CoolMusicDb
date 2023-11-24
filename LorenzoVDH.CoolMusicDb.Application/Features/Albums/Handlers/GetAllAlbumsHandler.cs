using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Handlers
{
    public class GetAllAlbumsHandler : IRequestHandler<GetAllAlbumsQuery, List<Album>>
    {
        private readonly IAlbumRepository _albumRepository;

        public GetAllAlbumsHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<List<Album>> Handle(GetAllAlbumsQuery query, CancellationToken cancellationToken)
        {
            return await _albumRepository.GetAllAlbumsAsync();
        }
    }
}