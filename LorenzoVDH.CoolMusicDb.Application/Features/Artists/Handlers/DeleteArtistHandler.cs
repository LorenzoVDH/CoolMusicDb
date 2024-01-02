using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Handlers;

public class DeleteArtistHandler : IRequestHandler<DeleteArtistCommand>
{
    private readonly IArtistRepository _artistRepository;

    public DeleteArtistHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }
    public async Task Handle(DeleteArtistCommand command, CancellationToken cancellationToken)
    {
        await _artistRepository.DeleteArtistByIdAsync(command.ArtistId);
    }
}
