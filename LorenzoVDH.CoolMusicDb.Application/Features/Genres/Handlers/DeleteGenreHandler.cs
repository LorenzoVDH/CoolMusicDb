using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class DeleteGenreHandler : IRequestHandler<DeleteGenreCommand>
{
    private readonly IGenreRepository _genreRepository;
    public DeleteGenreHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task Handle(DeleteGenreCommand command, CancellationToken cancellationToken)
    {
        await _genreRepository.DeleteGenreAsync(command.GenreId);
    }
}
