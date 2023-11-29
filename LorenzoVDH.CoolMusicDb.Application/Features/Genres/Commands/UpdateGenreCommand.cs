using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;

public class UpdateGenreCommand : IRequest<Genre>
{
    public Genre Genre { get; }
    public UpdateGenreCommand(Genre genre)
    {
        Genre = genre;
    }
}
