using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Genres.Queries;

public class GetAllGenresWithoutHierarchyQuery : IRequest<List<Genre>>
{ }
