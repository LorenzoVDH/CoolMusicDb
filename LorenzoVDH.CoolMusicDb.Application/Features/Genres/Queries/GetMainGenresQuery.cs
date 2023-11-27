using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Queries;

public class GetMainGenresQuery : IRequest<List<Genre>>
{

}
