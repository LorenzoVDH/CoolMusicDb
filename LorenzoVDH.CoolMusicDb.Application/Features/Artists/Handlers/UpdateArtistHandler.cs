using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Handlers;

public class UpdateArtistHandler : IRequestHandler<UpdateArtistCommand, Artist>
{
    private readonly IArtistRepository _artistRepository;
    public UpdateArtistHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }
    public async Task<Artist> Handle(UpdateArtistCommand command, CancellationToken cancellationToken)
    {
        await _artistRepository.UpdateArtistAsync(command.Artist);
        return await _artistRepository.GetArtistByIdAsync(command.Artist.Id);
    }
}
