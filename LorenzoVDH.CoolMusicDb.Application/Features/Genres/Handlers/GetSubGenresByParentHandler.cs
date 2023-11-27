using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Queries;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Handlers;

public class GetSubGenresByParentHandler : IRequestHandler<GetSubGenresByParentQuery, List<Genre>>
{
    private readonly IGenreRepository _genreRepository;

    public GetSubGenresByParentHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public Task<List<Genre>> Handle(GetSubGenresByParentQuery request, CancellationToken cancellationToken)
    {
        return _genreRepository.GetSubGenresByParentId(request.GenreId);
    }
}
