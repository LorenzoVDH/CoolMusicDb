using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class CreateGenreHandler : IRequestHandler<CreateGenreCommand, Genre>
{
    private readonly IGenreRepository _genreRepository;

    public CreateGenreHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<Genre> Handle(CreateGenreCommand command, CancellationToken cancellationToken)
    {
        return await _genreRepository.CreateGenreAsync(command.Genre);
    }
}
