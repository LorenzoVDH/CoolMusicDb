using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class SetParentChildRelationshipsForGenreHandler : IRequestHandler<SetParentChildRelationshipsForGenreCommand>
{
    private readonly IGenreRepository _genreRepository;
    public SetParentChildRelationshipsForGenreHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task Handle(SetParentChildRelationshipsForGenreCommand command, CancellationToken cancellationToken)
    {
        await _genreRepository.SetParentChildRelationshipsForGenre(command.GenreId, command.ChildGenreIds);
    }
}
