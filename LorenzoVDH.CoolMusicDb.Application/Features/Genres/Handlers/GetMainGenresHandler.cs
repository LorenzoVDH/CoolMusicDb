using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class GetMainGenresHandler : IRequestHandler<GetMainGenresQuery, List<Genre>>
{
    private readonly IGenreRepository _genreRepository;

    public GetMainGenresHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task<List<Genre>> Handle(GetMainGenresQuery query, CancellationToken cancellationToken)
    {
        return await _genreRepository.GetMainGenresAsync();
    }
}
