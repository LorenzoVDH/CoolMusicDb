using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;

public class DeleteGenreCommand : IRequest
{
    public int GenreId { get; }
    public DeleteGenreCommand(int genreId)
    {
        GenreId = genreId;
    }
}
