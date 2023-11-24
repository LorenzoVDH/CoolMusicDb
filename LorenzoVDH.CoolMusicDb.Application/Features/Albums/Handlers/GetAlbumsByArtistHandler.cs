using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Handlers;

public class GetAlbumsByArtistHandler : IRequestHandler<GetAlbumsByArtistQuery, List<Album>>
{
    private readonly IAlbumRepository _albumRepository;

    public GetAlbumsByArtistHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<List<Album>> Handle(GetAlbumsByArtistQuery query, CancellationToken cancellationToken)
    {
        return await _albumRepository.GetAlbumsByArtistIdAsync(query.ArtistId);
    }
}
