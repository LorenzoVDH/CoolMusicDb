using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;

public class CreateAlbumArtistRelationshipCommand : IRequest
{
    public int AlbumId { get; }
    public int ArtistId { get; }
    public CreateAlbumArtistRelationshipCommand(int albumId, int artistId)
    {
        AlbumId = albumId;
        ArtistId = artistId;
    }
}
