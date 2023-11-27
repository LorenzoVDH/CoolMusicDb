using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class CreateGenreParentChildRelationshipHandler : IRequestHandler<CreateGenreParentChildRelationshipCommand>
{
    private readonly IGenreRepository _genreRepository;
    public CreateGenreParentChildRelationshipHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task Handle(CreateGenreParentChildRelationshipCommand command, CancellationToken cancellationToken)
    {
        await _genreRepository.CreateGenreParentChildRelationship(command.ParentGenreId, command.ChildGenreId);
    }
}
