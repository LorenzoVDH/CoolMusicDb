using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class GetAllGenresWithoutHierarchyHandler : IRequestHandler<GetAllGenresWithoutHierarchyQuery, List<Genre>>
{
    private readonly IGenreRepository _genreRepository;

    public GetAllGenresWithoutHierarchyHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<List<Genre>> Handle(GetAllGenresWithoutHierarchyQuery query, CancellationToken cancellationToken)
    {
        return await _genreRepository.GetAllGenresWithoutHierarchyAsync();
    }
}
