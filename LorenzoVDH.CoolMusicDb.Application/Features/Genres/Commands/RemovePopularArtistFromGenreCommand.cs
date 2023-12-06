using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;

public class RemovePopularArtistFromGenreCommand : IRequest
{
    public int PopularArtistId { get; }
    public int GenreId { get; }

    public RemovePopularArtistFromGenreCommand(int popularArtistId, int genreId)
    {
        PopularArtistId = popularArtistId;
        GenreId = genreId;
    }
}
