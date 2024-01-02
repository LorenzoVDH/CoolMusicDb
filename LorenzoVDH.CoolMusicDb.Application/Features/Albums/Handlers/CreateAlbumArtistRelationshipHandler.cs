using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Handlers;

public class CreateAlbumArtistRelationshipHandler : IRequestHandler<CreateAlbumArtistRelationshipCommand>
{
    private readonly IAlbumRepository _albumRepository;

    public CreateAlbumArtistRelationshipHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task Handle(CreateAlbumArtistRelationshipCommand command, CancellationToken cancellationToken)
    {
        await _albumRepository.CreateAlbumArtistRelationshipAsync(command.AlbumId, command.ArtistId);
    }
}
