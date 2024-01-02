using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Commands;

public class CreateArtistCommand : IRequest<Artist>
{
    public Artist Artist { get; }
    public CreateArtistCommand(Artist artist)
    {
        Artist = artist;
    }
}
