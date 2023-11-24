using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Queries
{
    public class GetAllAlbumsQuery : IRequest<List<Album>>
    {

    }
}