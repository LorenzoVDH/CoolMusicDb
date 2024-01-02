using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;

public class DeleteGenreParentChildRelationshipCommand : IRequest
{
    public int ParentId { get; }
    public int ChildId { get; }

    public DeleteGenreParentChildRelationshipCommand(int parentId, int childId)
    {
        ParentId = parentId;
        ChildId = childId;
    }
}
