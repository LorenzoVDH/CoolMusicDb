using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Handlers;

public class GetTotalAlbumCountHandler : IRequestHandler<GetTotalAlbumCountQuery, int>
{
    private readonly IAlbumRepository _albumRepository;
    public GetTotalAlbumCountHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }
    public async Task<int> Handle(GetTotalAlbumCountQuery query, CancellationToken cancellationToken)
    {
        return await _albumRepository.GetTotalAlbumCountAsync();
    }
}
