using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;

public class SetParentChildRelationshipsForGenreCommand : IRequest
{
    public int GenreId { get; }
    public List<int> ChildGenreIds { get; }

    public SetParentChildRelationshipsForGenreCommand(int genreId, List<int> childGenreIds)
    {
        GenreId = genreId;
        ChildGenreIds = childGenreIds;
    }
}
