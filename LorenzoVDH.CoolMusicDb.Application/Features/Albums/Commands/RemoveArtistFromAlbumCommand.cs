using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;

public class RemoveArtistFromAlbumCommand : IRequest
{
    public int ArtistId { get; set; }
    public int AlbumId { get; set; }

    public RemoveArtistFromAlbumCommand(int artistId, int albumId)
    {
        ArtistId = artistId;
        AlbumId = albumId;
    }
}
