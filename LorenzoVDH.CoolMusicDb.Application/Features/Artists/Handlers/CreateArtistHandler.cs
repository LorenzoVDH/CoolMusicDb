using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Handlers;

public class CreateArtistHandler : IRequestHandler<CreateArtistCommand, Artist>
{
    private readonly IArtistRepository _artistRepository;

    public CreateArtistHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<Artist> Handle(CreateArtistCommand command, CancellationToken cancellationToken)
    {
        return await _artistRepository.CreateArtistAsync(command.Artist);
    }
}
