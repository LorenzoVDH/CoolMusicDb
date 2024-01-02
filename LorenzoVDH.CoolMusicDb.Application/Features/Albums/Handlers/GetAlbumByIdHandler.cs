using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Handlers;

public class GetAlbumByIdHandler : IRequestHandler<GetAlbumByIdQuery, Album>
{
    private readonly IAlbumRepository _albumRepository;
    public GetAlbumByIdHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<Album> Handle(GetAlbumByIdQuery query, CancellationToken cancellationToken)
    {
        return await _albumRepository.GetAlbumByIdAsync(query.AlbumId);
    }
}
