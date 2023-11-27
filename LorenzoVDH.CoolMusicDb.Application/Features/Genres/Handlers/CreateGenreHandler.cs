using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class CreateGenreHandler : IRequestHandler<CreateGenreCommand>
{
    private readonly IGenreRepository _genreRepository;

    public CreateGenreHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task Handle(CreateGenreCommand command, CancellationToken cancellationToken)
    {
        await _genreRepository.CreateGenreAsync(command.Genre);
    }
}
