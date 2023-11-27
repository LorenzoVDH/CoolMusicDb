using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Queries;

public class GetSubGenresByParentQuery : IRequest<List<Genre>>
{
    public int GenreId { get; }

    public GetSubGenresByParentQuery(int genreId)
    {
        GenreId = genreId;
    }
}
