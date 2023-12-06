using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class RemovePopularArtistFromGenreHandler : IRequestHandler<RemovePopularArtistFromGenreCommand>
{
    private IGenreRepository _genreRepository;

    public RemovePopularArtistFromGenreHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task Handle(RemovePopularArtistFromGenreCommand command, CancellationToken cancellationToken)
    {
        await _genreRepository.RemovePopularArtistFromGenre(command.PopularArtistId, command.GenreId);
    }
}
