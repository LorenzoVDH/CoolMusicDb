using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Handlers;

public class DeleteAlbumHandler : IRequestHandler<DeleteAlbumCommand>
{
    private readonly IAlbumRepository _albumRepository;
    public DeleteAlbumHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }
    public async Task Handle(DeleteAlbumCommand command, CancellationToken cancellationToken)
    {
        await _albumRepository.DeleteAlbumAsync(command.AlbumId);
    }
}
