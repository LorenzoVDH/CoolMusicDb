using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Handlers;

public class CreateAlbumHandler : IRequestHandler<CreateAlbumCommand>
{
    private readonly IAlbumRepository _albumRepository;

    public CreateAlbumHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task Handle(CreateAlbumCommand command, CancellationToken cancellationToken)
    {
        await _albumRepository.CreateAlbumAsync(command.Album);
    }
}
