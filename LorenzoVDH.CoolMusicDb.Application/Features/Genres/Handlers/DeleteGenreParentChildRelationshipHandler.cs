using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class DeleteGenreParentChildRelationshipHandler : IRequestHandler<DeleteGenreParentChildRelationshipCommand>
{
    private readonly IGenreRepository _genreRepository;
    public DeleteGenreParentChildRelationshipHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task Handle(DeleteGenreParentChildRelationshipCommand command, CancellationToken cancellationToken)
    {
        await _genreRepository.DeleteGenreParentChildRelationshipAsync(command.ParentId, command.ChildId);
    }
}
