using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class GetGenreByIdHandler : IRequestHandler<GetGenreByIdQuery, Genre?>
{
    private readonly IGenreRepository _genreRepository;

    public GetGenreByIdHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<Genre?> Handle(GetGenreByIdQuery query, CancellationToken cancellationToken)
    {
        return await _genreRepository.GetGenreByIdAsync(query.GenreId);
    }
}
