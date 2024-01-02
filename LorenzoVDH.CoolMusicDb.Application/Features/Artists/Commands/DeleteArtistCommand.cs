using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Commands;

public class DeleteArtistCommand : IRequest
{
    public int ArtistId { get; }
    public DeleteArtistCommand(int artistId)
    {
        ArtistId = artistId;
    }
}
