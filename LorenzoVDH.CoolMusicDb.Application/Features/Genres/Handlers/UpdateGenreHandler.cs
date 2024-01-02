using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class UpdateGenreHandler : IRequestHandler<UpdateGenreCommand, Genre>
{
    private readonly IGenreRepository _genreRepository;
    public UpdateGenreHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<Genre> Handle(UpdateGenreCommand command, CancellationToken cancellationToken)
    {
        await _genreRepository.UpdateGenreAsync(command.Genre);
        return command.Genre;
    }
}
