using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;

public class CreateGenreCommand : IRequest
{
    public Genre Genre { get; }
    public CreateGenreCommand(Genre genre)
    {
        Genre = genre;
    }
}