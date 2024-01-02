using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Handlers;

public class RemoveArtistFromAlbumHandler : IRequestHandler<RemoveArtistFromAlbumCommand>
{
    private readonly IAlbumRepository _albumRepository;

    public RemoveArtistFromAlbumHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task Handle(RemoveArtistFromAlbumCommand command, CancellationToken cancellationToken)
    {
        await _albumRepository.RemoveArtistFromAlbumAsync(command.ArtistId, command.AlbumId);
    }
}
