using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Commands;

public class UpdateArtistCommand : IRequest<Artist>
{
    public Artist Artist { get; }
    public UpdateArtistCommand(Artist artist)
    {
        Artist = artist;
    }
}
