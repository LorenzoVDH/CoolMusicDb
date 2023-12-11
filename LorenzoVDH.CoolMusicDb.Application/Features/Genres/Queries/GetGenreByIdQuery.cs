using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Queries;

public class GetGenreByIdQuery : IRequest<Genre?>
{
    public int GenreId { get; }

    public GetGenreByIdQuery(int genreId)
    {
        GenreId = genreId;
    }
}
