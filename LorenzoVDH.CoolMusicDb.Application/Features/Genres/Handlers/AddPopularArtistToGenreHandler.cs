using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class AddPopularArtistToGenreHandler : IRequestHandler<AddPopularArtistToGenreCommand>
{
    private readonly IGenreRepository _genreRepository;

    public AddPopularArtistToGenreHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task Handle(AddPopularArtistToGenreCommand command, CancellationToken cancellationToken)
    {
        await _genreRepository.AddPopularArtistToGenre(command.PopularArtistId, command.GenreId);
    }
}
