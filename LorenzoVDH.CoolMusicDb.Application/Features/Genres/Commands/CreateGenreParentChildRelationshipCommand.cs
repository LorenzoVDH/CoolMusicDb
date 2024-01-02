using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;

public class CreateGenreParentChildRelationshipCommand : IRequest
{
    public int ParentGenreId { get; }
    public int ChildGenreId { get; }

    public CreateGenreParentChildRelationshipCommand(int parentGenreId, int childGenreId)
    {
        ParentGenreId = parentGenreId;
        ChildGenreId = childGenreId;
    }
}
