using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Handlers;

public class CreateArtistHandler : IRequestHandler<CreateArtistCommand>
{
    private readonly IArtistRepository _artistRepository; 

    public CreateArtistHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository; 
    } 

    public async Task Handle(CreateArtistCommand command, CancellationToken cancellationToken)
    {
        await _artistRepository.CreateArtistAsync(command.Artist);
    }
}
