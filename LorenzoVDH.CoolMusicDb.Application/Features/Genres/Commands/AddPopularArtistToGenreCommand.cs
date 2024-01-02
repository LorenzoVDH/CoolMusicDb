using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;

public class AddPopularArtistToGenreCommand : IRequest
{
    public int PopularArtistId { get; }
    public int GenreId { get; }

    public AddPopularArtistToGenreCommand(int popularArtistId, int genreId)
    {
        PopularArtistId = popularArtistId;
        GenreId = genreId;
    }
}
