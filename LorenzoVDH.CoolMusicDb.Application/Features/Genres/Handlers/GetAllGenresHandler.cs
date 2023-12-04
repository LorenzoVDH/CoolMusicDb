using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class GetAllGenresHandler : IRequestHandler<GetAllGenresQuery, List<Genre>>
{
    private readonly IGenreRepository _genreRepository;

    public GetAllGenresHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task<List<Genre>> Handle(GetAllGenresQuery query, CancellationToken cancellationToken)
    {
        return await _genreRepository.GetGenresAsync();
    }
}
