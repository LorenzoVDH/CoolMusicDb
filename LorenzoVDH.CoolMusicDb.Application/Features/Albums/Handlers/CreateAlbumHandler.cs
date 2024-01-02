using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Handlers;

public class CreateAlbumHandler : IRequestHandler<CreateAlbumCommand, Album>
{
    private readonly IAlbumRepository _albumRepository;

    public CreateAlbumHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<Album> Handle(CreateAlbumCommand command, CancellationToken cancellationToken)
    {
        return await _albumRepository.CreateAlbumAsync(command.Album);
    }
}
